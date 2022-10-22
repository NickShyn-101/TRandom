namespace TRandomLib.Core
{
    /// <summary>
    /// Ядро генератора случайных чисел, которое не зависит от Random (в будущем) 
    /// и реализует собственнный способ генерации случайных числел
    /// </summary>
    public class TRandomTick
    {
        public int iterationsCount = 0;

        private HashCode hash = new HashCode();

        public long Seed { get; set; }

        long HASH1_TimeStamp { get; set; }  // takes the current time in ticks
        long HASH2_Input { get; set; }      // takes min and max value with some calculations and => i++
        long HASH3_PrevResult { get; set; }  // takes the current time in ticks




        public long seedMod = 0;


        private long minValue { get; set; } = 0;
        private long maxValue { get; set; } = long.MaxValue;
        private long range { get; set; }
        private string strMax { get; set; } = null!;

        public TRandomTick() => SetValues();

        public TRandomTick(long maxValue)
        {
            this.maxValue = maxValue;

            SetRandomStartPoint();
            SetValues();
        }

        public TRandomTick(long minValue, long maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;

            SetRandomStartPoint();
            SetValues();

        }

        public void SetNewValues(long maxValue)
        {
            this.maxValue = maxValue;
            SetValues();
        }

        public void SetNewValues(long minValue, long maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            SetValues();
        }


        private void SetRandomStartPoint()
        {
            HASH1_TimeStamp = DateTime.Now.Ticks;
            Seed = HASH1_TimeStamp % int.MaxValue;
            if (Seed < 1_000_000) Seed = Seed * 1111;
        }

        private void SetValues()
        {      
            // нужно переработать, так как есть ошибка при использовании отрицательных чисел
            range = maxValue - minValue;

            // нужно переработать, и придумать как без конвертера получить длину байтов в двоичном коде
            // на уме: делать сдвиг range до тех пор пока не будет ноль
            strMax = Convert.ToString(maxValue, 2);
        }


        // Ядро рандомайзера который генерирует случайное число в виде 1/0 
        // Его нужно переделать и ускорить до состояния блискому к стоковому Random (пока что не знаю как)
        private byte TickTack()
        {
            hash.Add(Seed);         // временная функция, нужно избавиться   ~50-100/1m 
            var xv = hash.ToHashCode();// временная функция, нужно избавиться   ~100-200/1m 
            if (xv < 0) xv *= -1;
            xv = xv >> 3;
            xv++;
            Seed = Seed + xv;

            if (Seed % 2 == 1)
                return 1;
            return 0;

        }

        // Генерирует случайное число из заданного диапазона 
        public long GetNumber()
        {
            long prevResult = 0;

            iterationsCount++;      // временная функция, нужно избавиться   ~1/1m 
            hash.Add(range);        // временная функция, нужно избавиться   ~50-100/1m 
            hash.Add(prevResult);   // временная функция, нужно избавиться   ~50-100/1m 

            long calcResult = TickTack(); // StartValue 1/0

            for (byte i = 0; i < strMax.Length - 1; i++)// заменить strmax.length на статику ~4-8ms/1m 
            {
                if (calcResult > range) break;          // если число вышло за рамки Range то прирываем цикл и возвраем результат 

                calcResult = calcResult << 1;           // обязательный сдвиг числа при каждой итерации
                if (TickTack() == 1) calcResult += 1;   // случайно добавляем единицу

                if (calcResult <= range)                // если число в рамках Range и цикл не закончен 
                    prevResult = calcResult;            // то запускаем новую итерацию
                else return GetNumber();                // если число вышло за рамки Range перезапускаем цикл
            }
            return minValue + prevResult;
        }


        public int GetNumberInt32()
        {
            return Convert.ToInt32(GetNumber());
        }

        public uint ToUInt32()
        {
            return Convert.ToUInt32(GetNumber());
        }

        public short ToInt16()
        {
            return Convert.ToInt16(GetNumber());
        }


        public ushort ToUInt16()
        {
            return Convert.ToUInt16(GetNumber());
        }

        public bool GetBool() => (TickTack() == 1) ? true : false;  
        

        // аппендицит, от него нужно избавиться!!!!
        public int Tick(int minvalue, int maxvalue)
        {
            return new Random().Next(minvalue, maxvalue);
        }
    }
}