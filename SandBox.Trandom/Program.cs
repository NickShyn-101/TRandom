using System.Diagnostics;
using System.Text;
using TRandomLib;
using TRandomLib.Core;

//Stopwatch sw1 = Stopwatch.StartNew();
//Console.WriteLine($"Идеёт просчёт...");
//TRandom<string> PasswordGen = new TRandom<string>().UseRandomString(new byte[] { 15, 5, 2, 10 }, '_') ;
//for (int i = 0; i < 1000; i++)
//{
//    PasswordGen.Next();
//    Console.WriteLine(PasswordGen.Next());
//}


//Console.WriteLine();
//sw1.Stop();
//Console.WriteLine($"Затрачено времени {sw1.ElapsedMilliseconds}, :тики {sw1.ElapsedTicks}");
//Console.WriteLine();
//Console.WriteLine();


//TRandom<string> randLong = new TRandom<string>().UseRandomString(15);

//Console.WriteLine(randLong.Next());
//Console.WriteLine(randLong.Next());
//Console.WriteLine(randLong.Next());

//Console.WriteLine();

//TRandom rand = new TRandom();
//Console.WriteLine(rand.Next());
//Console.WriteLine(rand.Next());

//Console.WriteLine(rand.Next(10, 60));
//Console.WriteLine(rand.Next(10, 60));
//Console.WriteLine(rand.Next(10, 60));
//Console.WriteLine(rand.Next(10, 60));
//Console.WriteLine(rand.Next(0, 5));
//Console.WriteLine(rand.Next(0, 5));
//Console.WriteLine(rand.Next(0, 5));
//Console.WriteLine(rand.Next(0, 5));
//Console.WriteLine(rand.Next(0, 5));
//Console.WriteLine(rand.Next(0, 5));
//Console.WriteLine(rand.Next(10, 60));
////Console.WriteLine(rand.Next(10, 60));
////Console.WriteLine(rand.Next(10, 60));
////Console.WriteLine(rand.Next(10, 60));
//Console.WriteLine(rand.NextBool());
//Console.WriteLine(rand.NextBool());
//Console.WriteLine(rand.NextBool());
//Console.WriteLine(rand.NextBool());
//Console.WriteLine(rand.NextBool());
//Console.WriteLine(rand.NextBool());
//Console.WriteLine(rand.NextBool());
//Console.WriteLine(rand.NextBool());


for (int j = 0; j < 5; j++)
{


    Stopwatch sw = Stopwatch.StartNew();


    Console.WriteLine($"Идеёт просчёт...");
    Console.WriteLine();
    SortedList<long, int> Engines = new SortedList<long, int>();
    TRandom tick = new TRandom(0, 10);
    //Random rand = new Random();  // ~!200
    for (int i = 0; i < 1000000; i++)
    {
        //var res = tick.Next();    // 
        //var res = tick.GetNumber();               // При отключённых х конвертерах            ~!316
        var res = tick.Next();                      // При включенный х конвертерах             ~!884
        //var res = rand.Next(0, 100);              // если экземпляр не создаётся каждый раз   ~!196 
        //var res = new Random().Next(0, 100);      // если экземпляр  создаётся каждый раз     ~!390

        if (Engines.ContainsKey(res))
        {
            Engines[res] += 1;
        }
        else
        {
            Engines.Add(res, 1);
        }
    }

    Console.WriteLine();

    foreach (var item in Engines)
    {
        Console.WriteLine($"{item.Key} - {item.Value} раз");
    }
    Console.WriteLine($"Всего чисел {Engines.Sum(p => p.Value)}, : всего лишних итераций: {tick.getIterrations()}");
    Console.WriteLine($"Максимальное {Engines.Max(p => p.Value)}, :Минимальное {Engines.Min(p => p.Value)}");
    Console.WriteLine();
    sw.Stop();
    Console.WriteLine($"Затрачено времени {sw.ElapsedMilliseconds}, :тики {sw.ElapsedTicks}");
    Console.WriteLine();
    Console.WriteLine();
}




//for (int j = 0; j < 5; j++)
//{


//    Stopwatch sw = Stopwatch.StartNew();


//    Console.WriteLine($"Идеёт просчёт...");
//    Console.WriteLine();
//    SortedList<long, int> Engines = new SortedList<long, int>();
//    TRandomTick tick = new TRandomTick(0,10);
//    StringBuilder sb = new();
//    for (int i = 0; i < 1_000_000; i++)
//    {

//        //var res = tick.GetTickResult(95000, 100000);
//        //var res = tick.TickDemo();    //5800 mc передел алгоритма привёл к цифре 335 - 400 тиков    last // 467 - 528
//        var res = tick.GetNumber();    //5800 mc передел алгоритма привёл к цифре 335 - 400 тиков    last // 467 - 528           !850
//        //var res = new Random().Next(10, 15); //640 mc // те же условия но 560 тиков                            last //              ~!320
//        //Console.WriteLine($"seed: {tick.Seed} - seedmod {tick.seedMod}");
//        //Console.WriteLine($"seed_{i}: {res} ");
//        if (Engines.ContainsKey(res))
//        {
//            Engines[res] += 1;
//        }
//        else
//        {
//            Engines.Add(res, 1);
//        }
//        //sb.AppendJoin("-", res.ToString());


//    }

//    //Console.WriteLine(sb.ToString());
//    Console.WriteLine();

//    foreach (var item in Engines)
//    {
//        //if (item.Value > 4)
//        //{
//        //    Console.WriteLine($"{item.Key} - {item.Value} раз ----------");
//        //} else if (item.Value > 5)
//        //{
//        //    Console.WriteLine($"{item.Key} - {item.Value} раз !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! ");

//        //}
//        Console.WriteLine($"{item.Key} - {item.Value} раз");
//    }
//    Console.WriteLine($"Всего чисел {Engines.Sum(p => p.Value)}, : всего лишних итераций: {tick.iterationsCount}");
//    Console.WriteLine($"Максимальное {Engines.Max(p => p.Value)}, :Минимальное {Engines.Min(p => p.Value)}");
//    Console.WriteLine();
//    sw.Stop();
//    Console.WriteLine($"Затрачено времени {sw.ElapsedMilliseconds}, :тики {sw.ElapsedTicks}");
//    Console.WriteLine();
//    Console.WriteLine();
//}












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