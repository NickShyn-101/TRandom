namespace TRandom.Types
{
    public class RandomNumber<T> : ITRandom<T> where T : struct
    {

        private T _startPoint { get; set; }
        private T _endPoint { get; set; }


        public RandomNumber(T endPoint)
        {
            _endPoint = endPoint;
        }

        public RandomNumber(T startPoint, T endPoint)
        {
            _startPoint = startPoint;
            _endPoint = endPoint;
        }

        public T Next()
        {
            // code ...
            return _endPoint;
        }
    }
}