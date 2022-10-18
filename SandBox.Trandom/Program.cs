

using System.Collections.Generic;
using System.Text;
using TRandom;
using TRandom.Core;
using static System.Net.Mime.MediaTypeNames;
using static TRandom.Core.TRandomEngine;


TRandomEngine random = new TRandomEngine(new()
{
    UseBigLetters = true,
    UseNumbers = true,
    UseSmallLetters = true,
    UseSymbols = true,
    UseSpace = true
});


for (int j = 0; j < 20; j++)
{

    Dictionary<int, int> symbols = new Dictionary<int, int>();
    Dictionary<string, int> resultCategories = new Dictionary<string, int>();
    resultCategories.Add("numbers", 0);
    resultCategories.Add("letters", 0);
    resultCategories.Add("signs", 0);

    for (int i = 0; i < 1000; i++)
    {
        var res = random.GetCharByteCode();
        if (symbols.ContainsKey(res))
        {
            symbols[res]++;
        }
        else
        {
            symbols.Add(res, 0);
        }

        if (res > 47 && res < 58)
        {
            resultCategories["numbers"] += 1;
        }
        else if ((res > 64 && res < 91) || (res > 96 && res < 123))
        {
            resultCategories["letters"] += 1;
        }
        else
        {
            resultCategories["signs"] += 1;
        }

    }
    Console.WriteLine();
    Console.WriteLine($"Результат генерации цикла №{j} ");
    foreach (var item in resultCategories)
    {
        Console.WriteLine($"[{item.Key}]:   {item.Value}");
    }
    Console.WriteLine($"_________________________");
    Console.WriteLine($"Total: {resultCategories.Sum(i => i.Value)} | Min: {resultCategories.Min(i => i.Value)} | Max: {resultCategories.Max(i => i.Value)}");
    
    Console.WriteLine();
}

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