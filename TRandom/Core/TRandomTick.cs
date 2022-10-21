namespace TRandom.Core
{
    /// <summary>
    /// Ядро генератора случайных чисел, которое не зависит от Random (в будущем) 
    /// и реализует собственнный способ генерации случайных числел
    /// </summary>
    public class TRandomTick
    {
        public int iterationsCount = 0;
        Random random = new Random();

        HashCode hash = new HashCode();


        public long Seed { get; set; }

        long TimeStamp { get; set; }

        public long seedMod = 0;

        public TRandomTick()
        {
            TimeStamp = DateTime.Now.Ticks;
            Seed = TimeStamp % int.MaxValue;
            if (Seed < 100)
                Seed = TimeStamp % 512;
        }

        public byte TickDemo()
        {
            var CalcResult = ((Seed + 1) << 15) % short.MaxValue;

            Seed = Seed + CalcResult;

            if (Seed % 2 == 1) return 1;

            return 0;


            //var CurrentStamp = DateTime.Now.Ticks;

            //var res = CurrentStamp - TimeStamp;



            //var CalcResult = ((Seed + 1) << 15) % short.MaxValue;
            //var offset = CalcResult % 8;
            //Seed = Seed + CalcResult + ((CalcResult + 1)) - Seed ^ CalcResult;


            //if (res % 2 == 1) return 1;

            //return 0;
        }


        private int TickTack()
        {

            hash.Add(Seed);
            var xv = hash.ToHashCode();
            if (xv < 0) xv *= -1;
            xv = xv >> 2 ;
            xv++;
            Seed = Seed + xv  ;

            if (Seed % 2 == 1)
                return 1;
            return 0;

        }

        public long GetNumber(long minValue, long maxValue)
        {
            iterationsCount++;
            
            long range = maxValue - minValue;
            string strMax = Convert.ToString(maxValue, 2);

            long prevResult = 0;

            hash.Add(range);
            hash.Add(prevResult);

            long calcResult = TickTack(); // StartValue 1/0
   
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
                    return GetNumber(minValue, maxValue);
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