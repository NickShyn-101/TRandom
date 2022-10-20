using TRandomLib.Core;
using TRandomLib.Types;

namespace TRandomLib
{
    public class TRandom<T>
    {
        public readonly ITRandom<T>? Service ;

        public TRandom() {}

        public TRandom(ITRandom<T> service)
        { 
            Service = service;
        }



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



        // integers sbyte > ulong
        //public TRandom<int> UseRandomNumber() => new TRandom<int>(new TRandomNumber<int>());
    
        //public TRandom<long> UseRandomInt64(T number) => new TRandom<long>(new TRandomInt64());
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



        public T Next() => Service.Next();

    }
}
