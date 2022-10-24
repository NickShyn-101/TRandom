namespace TRandomLib
{


    // 1. Генерируем Seed для текущей сессии / экземпляра в конструкторе
    //  - 1. создаём часовую метку по типу DateTime.Now.Tick
    //  - 2. на основе метки получаем специальный множителель для сида 
    //  - 
    // 1. Создаём массив байтов множетеля
    // в операции TickTak мы должны провести операцию изменения сида и путём умножения на числов в массиве + 1

















    //public class TRandom<T>
    //{
    //    ITRandomGenerator<T> generator;

    //    public TRandom(ITRandomGenerator<T> generator)
    //    {
    //        this.generator = generator;
    //    }

    //    public T Next()
    //    {
    //        return generator.Next();    
    //    }

    //}

    //public interface ITRandomEngine<T>
    //{


    //    // ----------------         type of strings         -----------------

    //    // length 8 :   he3jFfG2
    //    // length 12 :  F7gk3fd3fqc6
    //string Next(int length, Func<TRandomOptions>? options); //

    //    // signature [7,5,5,7,7] => sdgsd32-345gw-3422f-3424643-5345466, divider -, 
    //    // signature [3,4,3] => sdg_345w_34f, divider _, 
    //string Next(byte[] signature, char divider, Func<TRandomOptions>? options);

    //    // ----------------         type of bool         -----------------

    //    bool Next(); //  True or false
    //    bool Next(bool AsNumber); // 1 / 0


    //    // ----------------         type of int/short/long         -----------------

    //    T Next(T end); 
    //    T Next(T start, T end); 

    //    // ----------------         type of double, float, decimal         -----------------
    //    T Next(T end, T afterComa);    
    //    T Next(T start, T end, int afterComa);    // 4,100,200 => 135,5134
    //                                                  // 4,100,200 => 189,3549


    //    // ----------------         type of Collection        -----------------

    //    T Next(IEnumerable<T> values); //return random single object
    //    IEnumerable<T> Next(IEnumerable<T> values, int quantity); // return IEnumerable list or single object
    //    IEnumerable<T> Next(IEnumerable<T> values, int quantity, int startfrom, int endto); // return IEnumerable list or single object in diapasone of list elements 
    //    int Next(IEnumerable<T> values, bool onlyIndex); //return random index in collection
    //    int[] Next(IEnumerable<T> values, bool onlyIndex, int quantity); //return an array of random indexes in collection

    //    //byte code
    //    byte[] Next(int quantity);

    //    BigInteger Next();

    //}



    //public class TRandomString { }
    //public class TRandomNumber { }// where T : struct
    //public class TRandomEnum { } // 
    //public class TRandomBool { } // 


}











//public class TRandom<T> : ITRandom<T>
//{

//    public readonly ITRandom<T> Service ;

//    public TRandom() {}

//    public TRandom(ITRandom<T> service) => Service = service;


//    // /////////////////////////////////////////////////////////////////////////////////////////////////
//    //                                          Instances  of TRandom 
//    // /////////////////////////////////////////////////////////////////////////////////////////////////


//    // Strings
//    public TRandom<string> UseRandomString() =>
//        new TRandom<string>(new TRandomString());

//    public TRandom<string> UseRandomString(TRandomString randomString) =>
//        new TRandom<string>(randomString);

//    public TRandom<string> UseRandomString(int length) =>
//        new TRandom<string>(new TRandomString(length));

//    public TRandom<string> UseRandomString(byte[] signature, char divider) =>
//        new TRandom<string>(new TRandomString(signature, divider));


//    public TRandom<long> UseRandomInt64(T number) =>
//        new TRandom<long>(new TRandomInt64());



//    public T Next() => Service.Next();

//}




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
