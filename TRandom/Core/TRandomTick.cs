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
        private long range { get; set; } = long.MaxValue;
        private byte offsetCycles { get; set; } = 63;
        private long PreviousResult { get; set; } = 0;

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

        private void UpdateValues()
        {      
            // нужно переработать, так как есть ошибка при использовании отрицательных чисел
            range = maxValue - minValue;

            hash.Add(range);        // временная функция, нужно избавиться   ~50-100/1m 

            offsetCycles = 0;
            var ran = range;
            while (ran > 0)
            {
                ran = ran >> 1;
                offsetCycles++;
            }
        }


        // Ядро рандомайзера который генерирует случайное число в виде 1/0 
        // Его нужно переделать и ускорить до состояния близкому к стоковому Random (пока что не знаю как)
        private byte TickTack()
        {
            hash.Add(Seed);         // временная функция, нужно избавиться   ~50-100/1m 
            var xv = hash.ToHashCode();// временная функция, нужно избавиться   ~100-200/1m 
            if (xv < 0) xv *= -1;

            xv = (xv >> 3) + 1;

            Seed = Seed + xv;
            var x = Seed % 2;
            if (x == 1) return 1;
               
            return 0;

        }


        // Генерирует случайное число из заданного диапазона 
        public long GetNumberInt64()
        {
            iterationsCount++;  // временная функция

            long prevResult = 0;

            PreviousResult = prevResult;
            
            long calcResult = TickTack(); // StartValue 1/0
            if (offsetCycles > 0) {
                for (byte i = 1; i < offsetCycles; i++)
                {
                    if (calcResult > range) break;          // если число вышло за рамки Range то прирываем цикл и возвраем результат 

                    calcResult = calcResult << 1;           // обязательный сдвиг числа при каждой итерации
                    if (TickTack() == 1) calcResult += 1;   // случайно добавляем единицу

                    if (calcResult <= range)                // если число в рамках Range и цикл не закончен 
                        prevResult = calcResult;            // то запускаем новую итерацию
                    else
                        return GetNumberInt64();
                    // если число вышло за рамки Range перезапускаем цикл 
                    // если это исправить это можно ускорить алгоритм на 30% вместо ~530мс/1m => 420мс/1m
                    // пока что не знаю как это реализовать что бы не нарушить баланс

                }
            }
            return minValue + prevResult; 
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