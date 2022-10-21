using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
        Random random = new Random();

        private void ConvertBitStringToArray(ref string bitString, ref byte[] bitArray)
        {
            for (byte i = 0; i < bitArray.Length; i++)
                bitArray[i] = Convert.ToByte(bitString[i].ToString());
        }
       
        private int TickTack() => random.Next(0,2);
       
        public long GetTickResultV2(long minValue, long maxValue)
        {
            iterationsCount++;
            long range = maxValue - minValue;
            string strMax = Convert.ToString(maxValue, 2); //560


            // новый алгоритм на основе сдвига
            long prevResult = 0;
            long calcResult = TickTack(); // стартуем либо с 1 либо 0

            for (byte i = 0; i < strMax.Length - 1; i++)
            {
                if (calcResult > range) break;

                calcResult = calcResult << 1;
                if (TickTack() != 0) calcResult += 1;


                if (calcResult <= range) 
                {
                    prevResult = calcResult;
                }
                else
                {
                    return GetTickResultV2(minValue, maxValue);
                }
            }

            return minValue + prevResult;
        }


        public int Tick(int minvalue, int maxvalue)
        {
            return new Random().Next(minvalue, maxvalue);
        }
    }
}




