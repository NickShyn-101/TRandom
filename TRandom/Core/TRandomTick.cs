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

        public byte TickTack()
        {
            /// 
            return 0;
        }

        //private byte[]

        public int GetTickResult(int minValue, int maxValue)
        {
            iterationsCount++;
            // переводим числа в бинарный код
            var strMin = Convert.ToString(minValue, 2);
            var strMax = Convert.ToString(maxValue, 2);

            StringBuilder result = new StringBuilder();

            // конвертируем всё в массив байт
            long[] workingArray = new long[strMax.Length];
            long[] TestArray = new long[strMax.Length];

            // Convert string into array => return array
            // workingArray.
            for (byte i = 0; i < workingArray.Length; i++)
                workingArray[i] = Convert.ToByte(strMax[i].ToString());

            // //////////////////////////////////////////////////////////////////////
            //                сам процесс генерации случайных чисел
            //                  (преобразовать в функцию TickTack)
            // //////////////////////////////////////////////////////////////////////

            // сам процесс генерации случайных чисел
            for (byte j = 0; j < workingArray.Length; j++)
            {
                workingArray[j] = Convert.ToByte(new Random().Next(0, 2).ToString());
                TestArray[j] = workingArray[j];
            }

            //workingArray[j] = TickTack(); // мой метод реализации случайного числа
            for (byte i = 0; i < TestArray.Length - 1; i++)
            {
                if (TestArray[i] != 0)
                    TestArray[i] = TestArray[i] << TestArray.Length - 1 - i;
            }

            // //////////////////////////////////////////////////////////////////////
            //                      проверяем число на максимум
            //           (преобразовать в void функцию с out значениями)
            // //////////////////////////////////////////////////////////////////////

            int safeZeroIndexStart = workingArray.Length - 1;
            int safeZeroIndexEnd = workingArray.Length - 1;


            for (int i = 0; i < strMax.Length - 1; i++)
                if (strMax[i] == '0')
                {
                    safeZeroIndexStart = i;
                    break;
                }

            for (int i = safeZeroIndexStart; i < strMax.Length - 1; i++)
                if (strMax[i] == '1')
                {
                    safeZeroIndexEnd = i;
                    break;
                }


            // суммируем все значения из массива и выводим число результат учитывая проверки на максимум и минимум
            long testResult = 0;
            for (int j = 0; j < TestArray.Length; j++)
            {// проверитьт сумму следующих комбинаций на рсумму и равенство 


                bool isSafety = true;
                // если наш первый индек получает единицу
                // если значение на безопасном индексе меняется на 1 то мы предолагаем что есть возможность увеличения суммы за приделы
                // максимального числа, сложив сумму уже полученную с суммой значений после безопасного индекса
                var checker = 0;
                do
                {
                    isSafety = false;


                    checker++;
                    //TestArray[checker] == 1
                } while (TestArray[checker] != 1 && checker < safeZeroIndexStart);
                //for (int i = 0; i < safeZeroIndexStart; i++)
                //{
                //    if (TestArray[i] == 1) break;                        
                   
                //    isSafety = false;
                //}



                if (isSafety == false)
                {
                    for (int z = safeZeroIndexStart; z < safeZeroIndexEnd; z++)
                    {
                        if (TestArray[z].Equals(0) == true) break;

                        long sum = 0;
                        // если индекс равен одному  и сумма значений плюс сумма уже готовая больше чем максимальное число 
                        // заменяем текущий индекс на ноль, а следующий на 1
                        for (int k = z; k < TestArray.Length; k++)
                        {
                            if (TestArray[k] == 1)
                            {
                                sum += TestArray[k]; // !!!!!! error
                            }
                        }
                        //если значение больше то включаем заменяем текущий индекс массива на 0
                        if (testResult + sum > maxValue)
                        {
                            TestArray[z] = 0;
                            TestArray[z + 1] = 1;
                        }
                    }
                }


                testResult += TestArray[j];
            }
            // получение и вывод результата          
            int outInt = Convert.ToInt32(result.AppendJoin("", workingArray).ToString(), 2);
            // нужно избавиться от строки и переделать всё под массив байт, где мы преобразуем число 2^n           
            //тоесть нужно избавиться от result и сделать следующие инструкции
            // - берём workingArray и поочереди каждое значение в ячеки вовводим в степень 
            // - суммируем все значения из ячейки и по очереди сравниваем полученную сумму,     // эксперементально попробовать кажется 
            // --- если n + (n+1) будут больше чем максимальное значение то присваиваем n+1 ноль и суммируем и идём дальше //
            // - выводи результат

            Console.WriteLine($"{maxValue}] число: {Convert.ToString(maxValue, 2)} => {result.ToString()} : {Convert.ToInt32(result.ToString(), 2)}  || >> {outInt} | {Convert.ToString(outInt, 2)}");

            return  outInt; // большое количество ложных операций  ~22-32%
            //return (outInt > maxValue) ? GetTickResult(minValue, maxValue) : outInt; // большое количество ложных операций  ~22-32%
        }




        //// генератор должен быть в безопасной зоне
        //// мы можем гененрировать любые числа до первого нуля и первой единицы после первого нуля     
        //// в случае если у нас значения превысят максимальные мы просто заменим это диапазон на нули и получим 
        //// правильное значение
        //int safeZeroIndexStart = workingArray.Length - 1;
        //int safeZeroIndexEnd = workingArray.Length - 1;


        //    for (int i = 0; i<workingArray.Length - 1; i++)            
        //        if (workingArray[i] == 0)
        //        {
        //            safeZeroIndexStart = i;
        //            break;
        //        }

        //    for (int i = safeZeroIndexStart; i<workingArray.Length - 1; i++)
        //        if (workingArray[i] == 1)
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
