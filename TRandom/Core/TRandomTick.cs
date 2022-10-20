using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public byte TickTack()
        {
            /// 
            return 0;
        }

        private void ConvertBitStringToArray(ref string bitString, ref byte[] bitArray)
        {
            for (byte i = 0; i < bitArray.Length; i++)
                bitArray[i] = Convert.ToByte(bitString[i].ToString());
        }

        private void GenerateRandomSequence(byte[] maxValueArray, ref byte[] workingArray)        
        { 
            for (byte j = 0; j < workingArray.Length; j++)
            {           
                workingArray[j] = Convert.ToByte(new Random().Next(0, 2).ToString()); // generate 0/1

            }
        }

        private long[] CalculateBinaryInArray(byte[] workingArray)
        {
            long[] resultArray = new long[workingArray.Length];

            for (int i = 0; i < workingArray.Length; i++)
                    resultArray[i] = workingArray[i];
            
            for (byte j = 0; j < resultArray.Length; j++)            
                 if (resultArray[j] != 0)
                    resultArray[j] = resultArray[j] << resultArray.Length - 1 - j;

            return resultArray;
        }


        private void CheckSafeZeroIndexes(byte[] maxValueArray, ref byte[] workingArray, out int safeZeroStart, out int safeZeroEnd)
        {

            int safeZeroIndexStart = workingArray.Length - 1;
            int safeZeroIndexEnd = workingArray.Length - 1;


            for (int i = 0; i < maxValueArray.Length - 1; i++)
                if (maxValueArray[i] == 0)
                {
                    safeZeroIndexStart = i;
                    break;
                }

            for (int i = safeZeroIndexStart; i < maxValueArray.Length - 1; i++)
                if (maxValueArray[i] == 1)
                {
                    safeZeroIndexEnd = i;
                    break;
                }

            safeZeroStart = safeZeroIndexStart;
            safeZeroEnd = safeZeroIndexEnd;
        }

        private long[] ChangeArrayIfNotSignature(ref byte[] workingArray, ref int iteration)
        {
            iteration++;      

            for (int i = 0; i < workingArray.Length; i++)
                workingArray[i] = Convert.ToByte(new Random().Next(0, 2).ToString()); // generate 0/1
   

            return CalculateBinaryInArray(workingArray); 
        }

        public long GetTickResult(int minValue, int maxValue)
        {
            iterationsCount++;
            string strMin = Convert.ToString(minValue, 2);
            //string strMax = Convert.ToString(maxValue, 2);

            var valueRange = maxValue - minValue;
            string strMax = Convert.ToString(valueRange, 2);
            byte[] workingArray = new byte[strMax.Length];  // main
            byte[] maxValueArray = new byte[strMax.Length]; 
        
            ConvertBitStringToArray(ref strMax, ref maxValueArray);  // заносим каждый знак из строки в отдельный элемент  массива
            GenerateRandomSequence(maxValueArray, ref workingArray);     // генерим значения случайные для каждого элемента рабочего массива в виде 0/1
            var result = CalculateBinaryInArray(workingArray).Sum();


            while (result > valueRange)
                result = ChangeArrayIfNotSignature(ref workingArray, ref iterationsCount).Sum();

            return minValue + result;  // большое количество ложных операций  ~22-56%
        }


        public long GetTickResultV2(int minValue, int maxValue)
        {
            iterationsCount++;

            var valueRange = maxValue - minValue;

            return minValue + valueRange;
        }



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







//// генератор должен быть в безопасной зоне
//// мы можем гененрировать любые числа до первого нуля и первой единицы после первого нуля     
//// в случае если у нас значения превысят максимальные мы просто заменим это диапазон на нули и получим 
//// правильное значение


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

