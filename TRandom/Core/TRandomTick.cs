using static System.Net.Mime.MediaTypeNames;

namespace TRandomLib.Core
{

    /// <summary>
    /// Ядро генератора случайных чисел, которое не зависит от Random или других сторонних методов и библиотек (в будущем) 
    /// и реализует собственнный способ генерации случайных числел
    /// </summary>
    public class TRandomTick
    {
        public int iterationsCount = 0;

        private HashCode hash = new HashCode();  // временная функция, нужно избавиться 

        public long Seed { get; set; }

        long HASH1_TimeStamp { get; set; }  // takes the current time in ticks
        long HASH2_Input { get; set; }      // takes min and max value with some calculations and => i++
        long HASH3_PrevResult { get; set; }  // takes the current time in ticks

        const long RES_MASK = 0b1000;   // изменив маску получим смещение резульатов

        public long seedMod = 0;

        private long minValue = 0;
        private long maxValue = long.MaxValue;
        private long range = long.MaxValue;
        private byte offsetCycles = 63;
        private byte offsetCycleStep = 0;
        private long PreviousResult = 0;

        public TRandomTick() => SetRandomStartPoint();

        public void SetNewValues(long maxValue)
        {
            this.maxValue = maxValue;

            UpdateValues();
        }
        public void SetNewValues(long minValue, long maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;

            UpdateValues();
        }

        private void SetRandomStartPoint()
        {
            HASH1_TimeStamp = DateTime.Now.Ticks;
            Seed = HASH1_TimeStamp % int.MaxValue;
            if (Seed < 1_000_000) Seed = Seed * 1111;
        }



        //private void UpdateValues()
        //{
        //    // нужно переработать, так как есть ошибка при использовании отрицательных чисел
        //    range = maxValue - minValue;

        //    hash.Add(range);        // временная функция, нужно избавиться 

        //    offsetCycles = 0;
        //    var ran = range;
        //    while (ran > 0)
        //    {
        //        ran = ran >> 1;
        //        offsetCycles++;
        //    }
        //}



        //// Генерирует случайное число из заданного диапазона 
        //public long GetNumberInt64()
        //{
        //    iterationsCount++;  // временная функция для теста циклов перезагрузки метода

        //    long prevResult = 0;

        //    PreviousResult = prevResult;

        //    long calcResult = TickTack(); // StartValue 1/0
        //    if (offsetCycles > 0)
        //    {
        //        for (byte i = 1; i < offsetCycles; i++)
        //        {
        //            if (calcResult > range) break;          // если число вышло за рамки Range то прирываем цикл и возвраем результат 

        //            calcResult = calcResult << 1;           // обязательный сдвиг числа при каждой итерации
        //            if (TickTack() == 1) calcResult |= 1;   // случайно добавляем единицу

        //            if (calcResult <= range)                // если число в рамках Range и цикл не закончен 
        //                prevResult = calcResult;            // то запускаем новую итерацию
        //            else
        //            {
        //                return GetNumberInt64();
        //            }

        //        }
        //    }
        //    return minValue + prevResult;
        //}





        //1. вычисляем первый offset => который вычисляется как OffsetCycle на основе range (эту фунцию не нужно менять)
        //2. для полученного Range на основе первого offset - 1 () делаем проверку на равенство

        //var numbder1 = 0b1_0101_0101_0101; // 5461
        //var test1 = 1;

        //for (int n = 1; n < offsetCycles - 1; n++)
        //{
        //    test1 <<= 12;
        //    bool x = (numbder1 & test1) == test1;
        //}

        // если получаем true то записываем в массив число цикла (как в данном примере 13 (номер сдвига)) 
        // полученное число минусуем от первоначального, снова получаем range и запускаем цикл => вычисляем следующий offset
        // рекурсивно

        // после того как мы определим сигнатуру приступаем к TickTack() и формирум число 
        // суммируем полученные числа в целое
        // выводим результат
        // Ядро рандомайзера который генерирует случайное число в виде 1/0 
        // Его нужно переделать и ускорить до состояния близкому к стоковому Random (пока что не знаю как)


        private long[] ranges = new long[63];
        byte rangeIndex = 0;
        private void UpdateValues()
        {
            // нужно переработать, так как есть ошибка при использовании отрицательных чисел
            range = maxValue - minValue;


            GenerateSequence(range);
        }


        int iter = 0; // длина массива получившигося
        private void GenerateSequence(long range)
        {

            if (range == 0) return;

            var startValue = range;
            var ran = range;

            offsetCycles = 0;

            while (ran > 0)
            {
                ran = ran >> 1;
                offsetCycles++;
            }
            offsetCycles--;
            ran = 1;                    // сбрасываем число что бы привести к степени

            var mask = 1;
            for (int n = offsetCycles; n > 0; n--)
            {
                iter++;
                mask = 1;
                mask <<= offsetCycles;
                if ((range & mask) == mask) break;

            }
            //Console.WriteLine($"{iter} - {mask}");
            ranges[rangeIndex] = offsetCycles;
            rangeIndex++;
            startValue -= mask;  // вычисляем новое число
            GenerateSequence(startValue);

        }

        // Генерирует случайное число из заданного диапазона 
        public long GetNumberInt64()
        {
            iterationsCount++;  // временная функция для теста циклов перезагрузки метода

            long prevResult = 0;

            PreviousResult = prevResult;
            long result = 0;

            for (int z = 0; z < iter ; z++)
            {
                long calcResult = TickTack(); // StartValue 1/0

                for (byte i = 1; i < ranges[z]; i++)
                {
                    calcResult = calcResult << 1;           // обязательный сдвиг числа при каждой итерации
                    if (TickTack() == 1) calcResult |= 1;   // случайно добавляем единицу


                }
                result += calcResult;
                calcResult = 0;

            }

            return minValue + result;
        }



        public int GetNumberInt32() => unchecked((int)GetNumberInt64());


        public uint ToUInt32()
        {
            return Convert.ToUInt32(GetNumberInt64());
        }

        public short ToInt16()
        {
            return Convert.ToInt16(GetNumberInt64());
        }


        public ushort ToUInt16()
        {
            return Convert.ToUInt16(GetNumberInt64());
        }

        public bool GetBool() => (TickTack() == 1) ? true : false;


        // аппендицит, от него нужно избавиться!!!!
        public int Tick(int minvalue, int maxvalue)
        {
            return new Random().Next(minvalue, maxvalue);
        }


        private byte TickTack()
        {
            hash.Add(Seed);         // временная функция, нужно избавиться   ~50-100/1m 
            var xv = hash.ToHashCode();// временная функция, нужно избавиться   ~100-200/1m 
            if (xv < 0) xv = ~xv + 1;   // инвертируем число 
            xv = (xv >> 3) + 1;
            Seed = Seed + xv;

            // если изменить маску(0b1000) то измениться распределение и резултат будет смещаться
            if ((RES_MASK & Seed) != 0)
                return 1;
            return 0;
        }
    }
}







// если число вышло за рамки Range перезапускаем цикл  (в итоге получается много рекурсивных запусков метода)
// что в свою очередь может влиять на результат от 40 - 300% затрат времени
// если это исправить это можно ускорить алгоритм на 30% вместо ~530мс/1m => 420мс/1m
// пока что не знаю как это реализовать что бы не нарушить баланс
// !Idea: сделать анализатор предсказатель будущего числа 
//  = если число в следующей иерации выходит за рамки, то меняем предыдущий бит на 0 и добавлям 1

// !Idea что если схранять предыдущие значения в массив, и если значение только вышло за пределы максимльного, 
// обращаемся к массиву и выбираем число


// Idea! Нужно разбить число Range на составные части (2,4,8,16,32 ...) что бы не вылезать за приделы чисел и мы помещались в формат 1111_1111...
// далее для каждой части провести операцию TickTack а потом все эти числа сложить 
// тогда мы не вылезем за пределы диапазона и ускорим алгоритм в несколько раз!!


//var numbder1 = 0b1_0101_0101_0101; // 5461
//var numbder11 = 0b1_0000_0000_0000; // 4096 => добавляем в массив // остаток 465 > следующий шаг =>

//var number2 = 0b1_1101_0001; // 465
//var number21 = 0b1_0000_0000; // 256 => добавляем в массив // остаток 209 > следующий шаг =>

//var number3 = 0b1101_0001; // 209
//var number31 = 0b1000_0000; // 128 => добавляем в массив // остаток 81 > следующий шаг =>

//var number4 = 0b101_0001; // 81
//var number41 = 0b100_0000; // 64 => добавляем в массив // остаток 17 > следующий шаг =>

//var number5 = 0b1_0001; // 17
//var number51 = 0b1_0000; // 16 => добавляем в массив // остаток 1 > следующий шаг =>

//var number6 = 0b1; // 17





