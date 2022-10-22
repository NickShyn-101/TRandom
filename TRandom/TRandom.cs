using TRandomLib.Core;
using TRandomLib.Types;

namespace TRandomLib
{

    public class TRandom 
    {
        protected long _minValue { get; set; } = 0;
        protected long _maxValue { get; set; } = long.MaxValue;
        private readonly TRandomTick _tick = new TRandomTick();

        public TRandom() => _tick = new TRandomTick();
        public TRandom(long maxValue)
        {
            _maxValue = maxValue;
            _tick.SetNewValues(_maxValue);
        }
        public TRandom(long minValue, long maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _tick.SetNewValues(_minValue, _maxValue);
        }

        public bool NextBool() => _tick.GetBool(); 
        public long Next() => _tick.GetNumber();
        public long Next(long max)
        {
            _tick.SetNewValues(max);
            return _tick.GetNumber();
        }
        public long Next(long min, long max)
        {
            _tick.SetNewValues(min, max);
            return _tick.GetNumber();
        }
        public int Next(int max)
        {
            _tick.SetNewValues( max);
            return _tick.GetNumberInt32(); ;
        }
        public int Next(int min, int max)
        {
            _tick.SetNewValues(min, max);
            return _tick.GetNumberInt32(); ;
        }   

    }


    public class TRandom<T> : ITRandom<T>
    {

        public readonly ITRandom<T> Service ;

        public TRandom() {}

        public TRandom(ITRandom<T> service) => Service = service;
  

        // /////////////////////////////////////////////////////////////////////////////////////////////////
        //                                          Instances  of TRandom 
        // /////////////////////////////////////////////////////////////////////////////////////////////////


        // Strings
        public TRandom<string> UseRandomString() =>
            new TRandom<string>(new TRandomString());

        public TRandom<string> UseRandomString(TRandomString randomString) =>
            new TRandom<string>(randomString);

        public TRandom<string> UseRandomString(int length) =>
            new TRandom<string>(new TRandomString(length));

        public TRandom<string> UseRandomString(byte[] signature, char divider) =>
            new TRandom<string>(new TRandomString(signature, divider));


        public TRandom<long> UseRandomInt64(T number) =>
            new TRandom<long>(new TRandomInt64());



        public T Next() => Service.Next();

    }
}



//public double Next(double min, double max)
//{
//    _tick.SetNewValues(min, max);
//    return _tick.GetNumberInt32(); ;
//}    

//public float Next(float min, float max)
//{
//    _tick.SetNewValues(min, max);
//    return _tick.GetNumberInt32(); ;
//}   

//public decimal Next(decimal min, decimal max)
//{
//    _tick.SetNewValues(min, max);
//    return _tick.GetNumberInt32(); ;
//}





// integers sbyte > ulong
//public TRandom<int> UseRandomNumber() => new TRandom<int>(new TRandomNumber<int>());



//public TRandom<ulong> UseRandomUInt64(T number) => new TRandom<ulong>(new TRandomUInt64());
//public TRandom<int> UseRandomInt32(T number) => new TRandom<int>(new TRandomInt32());
//public TRandom<uint> UseRandomUInt32( T number) => new TRandom<uint>(new TRandomUInt32());
//public TRandom<short> UseRandomInt16(T number) => new TRandom<short>(new TRandomInt16());
//public TRandom<short> UseRandomUInt16( T number) => new TRandom<short>(new TRandomUInt16());
//public TRandom<byte> UseRandomByte(T number) => new TRandom<byte>(new TRandomByte());
//public TRandom<sbyte> UseRandomSByte(T number) => new TRandom<sbyte>(new TRandomSByte());



// boolean
//public TRandom<bool> UseRandomBool(T number) => new TRandom<bool>(new TRandomBool());



// objects / enums / arrays
// результатом рандомайзера долен быть либо объект / экземпляр выборки либо индекс
//      случайное слово из строки (string) / (index)
//      случайный знак из строки  (char) / (index)
//      случайный обьект из массива типа Array (object) / (index)
//      случайный обьект из массива типа List<T> (object) / (index)
//      случайный обьект из массива типа Dictionary<TKey, TValue> (object) / (index)




// /////////////////////////////////////////////////////////////////////////////////////////////////
//                                          Useful Presets  
// /////////////////////////////////////////////////////////////////////////////////////////////////


//public TRandom<string> PressetPassword(PasswordPresset.Simple, length = 12) => 
//public TRandom<string> PressetGuid() => 
//public TRandom<string> PressetGuidFake() => 
