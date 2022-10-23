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

        public TRandomTick() => SetRandomStartPoint();

        public void SetNewValues(long maxValue)
        {
            if (maxValue == this.maxValue) return;

            this.maxValue = maxValue;

            UpdateValues();
        }
        public void SetNewValues(long minValue, long maxValue)
        {
            if (maxValue == this.maxValue && minValue == this.minValue) return;

            this.minValue = minValue;
            this.maxValue = maxValue;     

            UpdateValues();
        }

        void SetRandomStartPoint()
        {
            HASH1_TimeStamp = DateTime.Now.Ticks;
            Seed = HASH1_TimeStamp % int.MaxValue;
            if (Seed < 1_000_000) Seed = Seed * 1111;
        }

        void UpdateValues()
        {
            UpdateRange();
            UpdateOffsetCycles();
        }

        void UpdateOffsetCycles()
        {
            offsetCycles = 1;
            var ran = range;
            while (ran > 2)
            {
                ran = ran >> 1;
                offsetCycles++;
            }
        }

        void UpdateRange()
        {
            // нужно переработать, так как есть ошибка при использовании отрицательных чисел    
            range = maxValue - minValue;
        }



        // Генерирует случайное число 0 / 1 
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

        // Генерирует случайное число из заданного диапазона 
        public long GetNumberInt64()
        {
            iterationsCount++;  // временная функция для теста циклов перезагрузки метода

            if (offsetCycles == 1) return TickTack();

            long result = TickTack(); 
            for (byte i = 0; i < offsetCycles; i++)
            {
                if ((result << 1) > range)
                {
                    result = result ^ range;
                   
                
                }
                result <<= 1;           // обязательный сдвиг числа при каждой итерации
                result = (TickTack() == 1)
                    ? result |= 1       // случайно добавляем единицу
                    : result;  
            }

            return (result <= range) ? minValue + result : GetNumberInt64();  // если число в рамках Range и цикл не закончен 
            //return minValue + prevResult;  // если число в рамках Range и цикл не закончен 
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

    }
}
