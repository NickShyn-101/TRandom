using TRandomLib.Core;
using TRandomLib.Types;

namespace TRandomLib
{
    public class TRandom
    {
        private readonly TRandomTick _tick = new TRandomTick();

        public TRandom() { }

        public bool NextBool() {
            _tick.SetNewValues(0,1);
             return (_tick.Tick() == 0) ? false : true;
        }

        public byte NextBit() {
            _tick.SetNewValues(0, 1);
            return (byte)_tick.Tick();
        }

        public long NextInt64() => _tick.Tick();
        public long NextInt64(long max = long.MaxValue)
        {
            _tick.SetNewValues(max);
            return _tick.Tick();
        }
        public long NextInt64(long min = 0, long max = long.MaxValue)
        {
            _tick.SetNewValues(min, max);
            return _tick.Tick();
        }

        public int NextInt32() => (int)_tick.Tick();
        public int NextInt32(int max = int.MaxValue)
        {
            _tick.SetNewValues((long)max);
            return (int)_tick.Tick();
        }
        public int NextInt32(int min = 0, int max = int.MaxValue)
        {
            _tick.SetNewValues(min, max);
            return (int)_tick.Tick();
        }


    }
}
