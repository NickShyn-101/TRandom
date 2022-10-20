

using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TRandom.Core;
using TRandomLib;
using TRandomLib.Core;
using static System.Net.Mime.MediaTypeNames;
using static TRandomLib.Core.TRandomEngine;


//TRandom<string> random1 = new TRandom<string>().UseRandomString(50); // сделать функцию вывода массива случайных значений
//Console.WriteLine(random1.Next());
//Console.WriteLine(random1.Next());
//Console.WriteLine(random1.Next());
//Console.WriteLine(random1.Service.Next());
//Console.WriteLine(random1.Service.Next());
//Console.WriteLine(random1.Service.Next());
//Console.WriteLine(random1.Service.Next());

//TRandom<int> random2 = new TRandom<int>();
//Console.WriteLine(random1.Next());


//Stopwatch st = Stopwatch.StartNew();
////Random rd = new Random();

//TRandom<string> random1 = new TRandom<string>().UseRandomString(400);
//for (int i = 0; i < 1000; i++)
//{
//    Console.WriteLine(random1.Next());

//}
////for (int i = 0; i < 1000; i++)
////{
////    Console.WriteLine(rd.Next(-222, 99999));

////}
///
//for (int i = 0; i < 50; i++)
//{
//    Stopwatch st = Stopwatch.StartNew();
//    //Random ran = new Random();
//    var x = 1553 / 20;
//    st.Stop();
//    Console.WriteLine($"[{i}] Внутренний стопвоч: Тики {st.ElapsedTicks} | Млс: {st.ElapsedMilliseconds}");
//}

////1100
//var long1 = 0b10000000000;
////110000000011
//long lon2 = 2 << 61;

//long vs3 = lon2 & long1;
//long vs4 = lon2 | long1;
//long vs5 = lon2 ^ long1;
//Console.WriteLine(long1);
//Console.WriteLine(lon2);
//Console.WriteLine(vs3);
//Console.WriteLine(vs4);
//Console.WriteLine(vs5);
//var long10 = 9_223_372_036_854_775_807;
//var long2 = 0b111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111;
//var longm2 = -0b111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111;

//var long100 = 0b1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000;
//  long _seed = 5_234_569;
// const long pi = 314_159_265;
////      9_223_372_036_854_775_807
////    67    1_644_487_721_313_255 => 63
////    68    1_644_488_035_472_520 => 63
////    69    1_644_488_349_631_785 => 81
////    72    1_644_489_292_109_580 => 72
//Console.WriteLine(_seed * pi);
//        387_850_661_756_464_553
//      3_215_284_049_987_464_553
//      9_223_372_036_854_775_807


SortedList<int, int> Engines = new SortedList<int, int>();
for (int i = 0; i < 1000; i++)
{
    TRandomTick tick = new TRandomTick();
    var res = tick.GetTickResult(0, 100);
    if (Engines.ContainsKey(res)) {
        Engines[res] += 1;
    } else
    {
        Engines.Add(res, 1);
    }

}


foreach (var item in Engines)
{
    //if (item.Value > 4)
    //{
    //    Console.WriteLine($"{item.Key} - {item.Value} раз ----------");
    //} else if (item.Value > 5)
    //{
    //    Console.WriteLine($"{item.Key} - {item.Value} раз !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! ");

    //}
        Console.WriteLine($"{item.Key} - {item.Value} раз");
}
Console.WriteLine($"Всего чисел {Engines.Sum(p => p.Value)}, : всего лишних итераций: {TRandomTick.iterationsCount}");
Console.WriteLine($"Максимальное {Engines.Max(p => p.Value)}, :Минимальное {Engines.Min(p => p.Value)}");
Console.WriteLine();

//for (int i = 25; i > 0; i--)
//{
//    Console.WriteLine(Convert.ToString(i, 2));
//}


//long  test = 999999 << 10;
//// 9999 => 10238976
//// 9998 => 10237952
//Console.WriteLine($"{64235 % 10}");
//Console.WriteLine($"{76696 % 10}");
//Console.WriteLine($"{76953 % 10}");
//Console.WriteLine($"{test}");
////for (int i = 0; i < 1000; i++)
////{
////    rd.Next();
////}
//st.Stop();
//Stopwatch stOut = Stopwatch.StartNew();
//Stopwatch st = Stopwatch.StartNew();
//for (int i = 0; i < new Random().Next(1, 10); i++)
//{

//    var l2 = 125324534;
//    //var l2 = new Random().Next(1000, 51000);
//    var s = Convert.ToString(l2);

//}
//st.Stop();
//var currentTick = st.ElapsedTicks;
//var cuSdvig = currentTick << 2;
//var tickstring = Convert.ToString(st.ElapsedTicks);
//char[] arr = new char[tickstring.Length];
//for (int j = 0; j < tickstring.Length; j++)
//{
//    arr.SetValue(tickstring[j], j);
//}
//stOut.Stop();

//Console.WriteLine(cuSdvig);
//Console.WriteLine($"Внутренний стопвоч: Тики {st.ElapsedTicks} | Млс: {st.ElapsedMilliseconds}") ;
//Console.WriteLine($"Внешний стопвоч: Тики {stOut.ElapsedTicks} | Млс: {stOut.ElapsedMilliseconds}") ;

//7792139 при простых числах!
//7250670 при строке 4 мой быстрее!!! 
//8637072 при строке 10
//9510718 при 50
//13176803 при 100 символах в строке
//43929247 при 400 символах
//for (int j = 0; j < 20; j++)
//{

//    Dictionary<int, int> symbols = new Dictionary<int, int>();
//    Dictionary<string, int> resultCategories = new Dictionary<string, int>();
//    resultCategories.Add("numbers", 0);
//    resultCategories.Add("letters", 0);
//    resultCategories.Add("signs", 0);

//    for (int i = 0; i < 1000; i++)
//    {
//        var res = random.GetCharCode();
//        if (symbols.ContainsKey(res))
//        {
//            symbols[res]++;
//        }
//        else
//        {
//            symbols.Add(res, 0);
//        }

//        if (res > 47 && res < 58)
//        {
//            resultCategories["numbers"] += 1;
//        }
//        else if ((res > 64 && res < 91) || (res > 96 && res < 123))
//        {
//            resultCategories["letters"] += 1;
//        }
//        else
//        {
//            resultCategories["signs"] += 1;
//        }

//    }
//    Console.WriteLine();
//    Console.WriteLine($"Результат генерации цикла №{j} ");
//    foreach (var item in resultCategories)
//    {
//        Console.WriteLine($"[{item.Key}]:   {item.Value}");
//    }
//    Console.WriteLine($"_________________________");
//    Console.WriteLine($"Total: {resultCategories.Sum(i => i.Value)} | Min: {resultCategories.Min(i => i.Value)} | Max: {resultCategories.Max(i => i.Value)}");

//    Console.WriteLine();
//}

//foreach (var item in symbols.OrderBy(p => p.Key))
//{
//    byte[] test = new byte[1];
//    test[0] = (byte)item.Key;
//    if (test[0] > 47 && test[0] < 58)
//    {
//        resultCategories["numbers"] += 1;
//    }
//    else if ((test[0] > 64 && test[0] < 91) || (test[0] > 96 && test[0] < 123))
//    {
//        resultCategories["letters"] += 1;
//    }
//    else
//    {
//        resultCategories["signs"] += 1;
//    }
//    Console.WriteLine($"[{item.Key}]: {Encoding.ASCII.GetString(test)} -  {item.Value}");
//}



//StringBuilder sb = new StringBuilder();
//for (int i = 33; i < 48; i++)
//{
//    sb.Append($"{i},");
//}
//for (int i = 58; i < 65; i++)
//{
//    sb.Append($"{i},");
//}

//for (int i = 91; i < 97; i++)
//{
//    sb.Append($"{i},");
//}

//for (int i = 123; i < 127; i++)
//{
//    sb.Append($"{i},");
//}
//Console.WriteLine(sb.ToString());
//Random randomTest = new Random();
//int[] countArray = new int[10];
//for (int i = 0; i < 10000; i++)
//{
//    var current = randomTest.Next(0,10);

//    countArray[current] = countArray[current] + 1;
//}

//for (int i = 0; i < countArray.Length; i++)
//{
//    Console.WriteLine($"Value {i} повторилось {countArray[i]} раз");
//}