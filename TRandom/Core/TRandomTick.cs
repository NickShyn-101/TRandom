using Microsoft.Win32.SafeHandles;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace TRandomLib.Core
{
    public class TRandomTick
    {
        // данных два поля генерируют начальное состояние генератора
        // и позволяют повторно воссоздать числа при необходимости 
        // указав нужный Seed (0..int.Maxvalue) и Special (0..long.maxValue)
        private const long pi = 314159265359;

        private long? _seed; 
        private string? _key;

        // производное число основанное на seed и special; 
        private long _derivate = 1; 

        // Следующее число для перебора
        private long _nextValue = 0;
        private int _multiplier = 1;

        // Пользовательские параметры 
        private long _minValue = 0;
        private long _maxValue = long.MaxValue;
        private ulong _range = ulong.MaxValue;

        public TRandomTick() => SetRandomStartPoint();

        public void SetNewValues(long maxValue) => SetNewValues(0, maxValue);      
        public void SetNewValues(long minValue, long maxValue)
        {
            if (maxValue == _maxValue && minValue == _minValue) return;

            _minValue = minValue;
            _maxValue = maxValue;

            UpdateRange();
        }

        void SetRandomStartPoint()
        {
            if (_seed == null)
                _seed = DateTime.Now.Ticks; 
           
            if (_key == null)
                _key = " ";

            var xv = Encoding.UTF8.GetBytes(_key);

            var sum = 0;
            for (int i = 0; i < xv.Length; i++) sum += xv[i];

            _derivate = (long)_seed * sum * pi;
            _nextValue = _derivate * _multiplier;
        }

        void UpdateRange()
        {
            if (_maxValue == _minValue) throw new ArgumentOutOfRangeException("the minimum value cannot equal the maximum value");

            if (_maxValue < _minValue)
            {
                var rMax = _maxValue;
                var rMin = _minValue;
                _maxValue = rMin;
                _minValue = rMax;
            }

            _range = (ulong)((_maxValue + 1) - _minValue);
        }

        public long Tick()
        {
            _nextValue = (_nextValue * _multiplier * pi) ^ _derivate;
            _nextValue = (_nextValue < 0) ? ~_nextValue : _nextValue;
            _nextValue++;
            _multiplier++;

            return _minValue + (_nextValue % (long)_range);
        }
        public long Tick(long minValue, long maxValue)
        {
            SetNewValues(minValue, maxValue);

            return Tick();

        }

    }
}