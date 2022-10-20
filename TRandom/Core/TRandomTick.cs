using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRandom.Core
{
    /// <summary>
    /// Ядро генератора случайных чисел, которое не зависит от Random (в будущем) 
    /// и реализует собственнный способ генерации случайных числел
    /// как идея - генерация чисел на уровне бинарного кода
    /// - задаётся шаблон
    /// - делается сдвиг (право или лево)
    /// - выводиться результат в виде массива байтов
    /// </summary>
    public class TRandomTick
    {
        public static int iterationsCount = 0;
        // создаём переменные 
        // встраиваем их создание в конструкцию StopWhatch
        // на основе тиков из стопвоч, делаем что то
        // сумируем все цифры массива и привести к модулю %
        //      например получили 1553 => 1 + 5 + 5 + 3 = 14 => % 2 => 1 или 0
        //  получившиеся значение возвращаем 

        private static long _seed = 1_234_567;
        private const long pi = 314_159_265_359;

        public int GetTickResult(int minValue, int maxValue)
        {
            iterationsCount++;
            // переводим числа в бинарный код
            var strMin = Convert.ToString(minValue, 2);
            var strMax = Convert.ToString(maxValue, 2);

            StringBuilder result = new StringBuilder();

            // конвертируем всё в массив байт
            byte[] workingArrayMax = new byte[strMax.Length];
            for (int i = 0; i < workingArrayMax.Length; i++)
                workingArrayMax[i] = Convert.ToByte(strMax[i].ToString());

            // сам процесс генерации случайных чисел
            for (int j = 0; j < workingArrayMax.Length - 1; j++)
                workingArrayMax[j] = Convert.ToByte(new Random().Next(0, 2).ToString());

            // получение и вывод результата            
            int outInt = Convert.ToInt32(result.AppendJoin("", workingArrayMax).ToString(), 2);
                       
            Console.WriteLine($"{maxValue}] число: {Convert.ToString(maxValue, 2)} => {result.ToString()} : {Convert.ToInt32(result.ToString(), 2)}  || >> {outInt} | {Convert.ToString(outInt, 2)}");
        
            return (outInt > maxValue) ? GetTickResult(minValue, maxValue) : outInt; // большое количество ложных операций  ~22-32%
        }



 
        //// генератор должен быть в безопасной зоне
        //// мы можем гененрировать любые числа до первого нуля и первой единицы после первого нуля     
        //// в случае если у нас значения превысят максимальные мы просто заменим это диапазон на нули и получим 
        //// правильное значение
        //int safeZeroIndexStart = workingArrayMax.Length - 1;
        //int safeZeroIndexEnd = workingArrayMax.Length - 1;


        //    for (int i = 0; i<workingArrayMax.Length - 1; i++)            
        //        if (workingArrayMax[i] == 0)
        //        {
        //            safeZeroIndexStart = i;
        //            break;
        //        }
            
        //    for (int i = safeZeroIndexStart; i<workingArrayMax.Length - 1; i++)
        //        if (workingArrayMax[i] == 1)
        //        {
        //            safeZeroIndexEnd = i;
        //            break;
        //        }


// проверяем индексы на 1 если у них обоих 1 то мы можем ставить любое число в них, в противном случае 
// если у первого есть 1 а у второго нет то второе число не может получить единицу

//разлаживаем входящие числа мин и макс по отдельности на двоичный код 722 => 1011010010 в string builder
// каждый индекс проверяем на единицу кроме первого, так как нам нельзая
// 

//1011010010 => 
// если [n] индекс == 1 то мы проводим генерацию числа, если он меняется на 0, то следующий [n+1]  может замениться на 1 или 0
// в противном случае [n+1] автоматически становиться 0 
// остался неизменным то  


//Stopwatch time = Stopwatch.StartNew();

//time.Stop();


//long tick = time.ElapsedTicks;
//var str = Convert.ToString(tick, 2);
//result = Convert.ToByte(time.ElapsedTicks % 2);
//Console.WriteLine($"[] Внутренний стопвоч: Тики {tick}  | Результат: {result} | binary: {str}");


public int Tick(int minvalue, int maxvalue)
        {
            return new Random().Next(minvalue, maxvalue);
        }

        public int TickDouble(int minvalue, int maxvalue)
        {
            return new Random().Next(minvalue, maxvalue);
        }
    }
}
