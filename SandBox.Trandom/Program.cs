

using System.Text;
using TRandom;
using TRandom.Core;
using static TRandom.Core.TRandomEngine;


TRandomEngine random = new TRandomEngine(new()
{
    UseBigLetters = true,
    UseNumbers = true,
    UseSmallLetters = true,
    UseSymbols = true,
    UseSpace = true
});

Dictionary<int, int> symbols = new Dictionary<int, int>();
random.GetCharByteCode();
//for (int i = 0; i < 1000; i++)
//{
//    var res = random.GetCharByteCode();
//    if (symbols.ContainsKey(res))
//    {
//        symbols[res]++;
//    } else
//    {
//        symbols.Add(res, 0);
//    }
//}

foreach (var item in symbols.OrderBy(p => p.Key))
{
    Console.WriteLine($"[{item.Key}]: {item.Value}");
}


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