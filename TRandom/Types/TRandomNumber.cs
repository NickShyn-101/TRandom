using TRandomLib.Core;

namespace TRandomLib.Types
{

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

}