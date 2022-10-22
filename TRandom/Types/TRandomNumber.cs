using TRandomLib.Core;

namespace TRandomLib.Types
{

    public interface ITRandomNumber
    {

    }


    public abstract class TRandomNumber<T> : ITRandom<T> where T : struct
    {
        protected T _minValue { get; set; }
        protected T _maxValue { get; set; }

        public TRandomNumber() { }

        public TRandomNumber(T maxValue) => _maxValue = maxValue;        

        public TRandomNumber(T minValue, T maxValue) 
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }
        public virtual T Next()
        {
            TRandomEngine random = new TRandomEngine();

            return random.GenerateNumber<T>(_minValue, _maxValue);
        }    
    }


    /* нужно подумать нард реализацией этого могуля */
    public class TRandomInt64 : TRandomNumber<long>
    {
        public TRandomInt64() { }
        public TRandomInt64(long maxValue = long.MaxValue) : base(maxValue) => _minValue = 0;
        public TRandomInt64(long minValue = 0, long maxValue = long.MaxValue) : base(minValue, maxValue) { }

        public override long Next()
        {
            return _maxValue;
        }
    }

    public class TRandomUInt64 : TRandomNumber<ulong>
    {
        public TRandomUInt64() { }
        public TRandomUInt64(ulong maxValue = ulong.MaxValue) : base(maxValue) => _minValue = 0;
        public TRandomUInt64(ulong minValue = 0, ulong maxValue = ulong.MaxValue) : base(minValue, maxValue) { }

        public override ulong Next()
        {
            return _maxValue;
        }
    }

    public class TRandomInt32 : TRandomNumber<int>
    {
        public TRandomInt32(){}
        public TRandomInt32(int maxValue = int.MaxValue) : base(maxValue) => _minValue = 0;
        public TRandomInt32(int minValue = 0, int maxValue = int.MaxValue) : base(minValue, maxValue) {}

        public override int Next()
        {
            return _maxValue;
        }
    }

    public class TRandomUInt32 : TRandomNumber<uint>
    {
        public TRandomUInt32() { }
        public TRandomUInt32(uint maxValue = uint.MaxValue) : base(maxValue) => _minValue = 0;
        public TRandomUInt32(uint minValue = 0, uint maxValue = uint.MaxValue) : base(minValue, maxValue) { }

        public override uint Next()
        {
            return _maxValue;
        }
    }

    public class TRandomInt16 : TRandomNumber<short>
    {
        public TRandomInt16() { }
        public TRandomInt16(short maxValue = short.MaxValue) : base(maxValue) => _minValue = 0;
        public TRandomInt16(short minValue = 0, short maxValue = short.MaxValue) : base(minValue, maxValue) { }

        public override short Next()
        {
            return _maxValue;
        }
    }

    public class TRandomUInt16 : TRandomNumber<ushort>
    {
        public TRandomUInt16() { }
        public TRandomUInt16(ushort maxValue = ushort.MaxValue) : base(maxValue) => _minValue = 0;
        public TRandomUInt16(ushort minValue = 0, ushort maxValue = ushort.MaxValue) : base(minValue, maxValue) { }

        public override ushort Next()
        {
            return _maxValue;
        }
    }

}