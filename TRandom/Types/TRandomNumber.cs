using TRandomLib.Core;

namespace TRandomLib.Types
{
    public abstract class TRandomNumber<T> : ITRandom<T> where T : struct
    {
        protected T _startPoint { get; set; }
        protected T _endPoint { get; set; }

        public TRandomNumber() { }

        public TRandomNumber(T endPoint) => _endPoint = endPoint;        

        public TRandomNumber(T startPoint, T endPoint) 
        {
            _startPoint = startPoint;
            _endPoint = endPoint;
        }
        public virtual T Next()
        {
            TRandomEngine random = new TRandomEngine();

            return random.GenerateNumber<T>();
        }    
    }

    public class TRandomInt64 : TRandomNumber<long>
    {
        public TRandomInt64() { }
        public TRandomInt64(long endPoint = long.MaxValue) : base(endPoint) => _startPoint = 0;
        public TRandomInt64(long startPoint = 0, long endPoint = long.MaxValue) : base(startPoint, endPoint) { }

        public override long Next()
        {
            return _endPoint;
        }
    }

    public class TRandomUInt64 : TRandomNumber<ulong>
    {
        public TRandomUInt64() { }
        public TRandomUInt64(ulong endPoint = ulong.MaxValue) : base(endPoint) => _startPoint = 0;
        public TRandomUInt64(ulong startPoint = 0, ulong endPoint = ulong.MaxValue) : base(startPoint, endPoint) { }

        public override ulong Next()
        {
            return _endPoint;
        }
    }

    public class TRandomInt32 : TRandomNumber<int>
    {
        public TRandomInt32(){}
        public TRandomInt32(int endPoint = int.MaxValue) : base(endPoint) => _startPoint = 0;
        public TRandomInt32(int startPoint = 0, int endPoint = int.MaxValue) : base(startPoint, endPoint) {}

        public override int Next()
        {
            return _endPoint;
        }
    }

    public class TRandomUInt32 : TRandomNumber<uint>
    {
        public TRandomUInt32() { }
        public TRandomUInt32(uint endPoint = uint.MaxValue) : base(endPoint) => _startPoint = 0;
        public TRandomUInt32(uint startPoint = 0, uint endPoint = uint.MaxValue) : base(startPoint, endPoint) { }

        public override uint Next()
        {
            return _endPoint;
        }
    }

    public class TRandomInt16 : TRandomNumber<short>
    {
        public TRandomInt16() { }
        public TRandomInt16(short endPoint = short.MaxValue) : base(endPoint) => _startPoint = 0;
        public TRandomInt16(short startPoint = 0, short endPoint = short.MaxValue) : base(startPoint, endPoint) { }

        public override short Next()
        {
            return _endPoint;
        }
    }

    public class TRandomUInt16 : TRandomNumber<ushort>
    {
        public TRandomUInt16() { }
        public TRandomUInt16(ushort endPoint = ushort.MaxValue) : base(endPoint) => _startPoint = 0;
        public TRandomUInt16(ushort startPoint = 0, ushort endPoint = ushort.MaxValue) : base(startPoint, endPoint) { }

        public override ushort Next()
        {
            return _endPoint;
        }
    }

}