namespace TRandom.Types
{
    public class TRandomEnum<T> : ITRandom<IEnumerable<T>> 
    {

        //    T Next(IEnumerable<T> values); //return random single object
        //    IEnumerable<T> Next(IEnumerable<T> values, int quantity); // return IEnumerable list or single object
        //    IEnumerable<T> Next(IEnumerable<T> values, int quantity, int startfrom, int endto); // return IEnumerable list or single object in diapasone of list elements 
        //    int Next(IEnumerable<T> values, bool onlyIndex); //return random index in collection
        //    int[] Next(IEnumerable<T> values, bool onlyIndex, int quantity); //return an array of random indexes in collection

        public IEnumerable<T> Next()
        {
            throw new NotImplementedException();
        }
    }
}