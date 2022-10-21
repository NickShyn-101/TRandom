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
