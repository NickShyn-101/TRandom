using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRandom.Core
{
    public class CharGeneratorSettings
    {
        public bool UseSmallLetters { get; set; } = true;
        public bool UseBigLetters { get; set; } = true;
        public bool UseNumbers { get; set; } = true;
        public bool UseSymbols { get; set; } = false;
        public bool UseSpace { get; set; } = true;
    }

    public class TRandomEngine
    {
        byte[][] charIndexes = new byte[3][]
        {
            new byte[] { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 },   // 0-9  // => 3
            new byte[] { 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122 }, // a-z => 8 // 16 при 
            new byte[] { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 58, 59, 60, 61, 62, 63, 64, 91, 92, 93, 94, 95, 96, 123, 124, 125, 126 } // symbols 
        };

        List<int> ByteList = new List<int>();

        private readonly CharGeneratorSettings charGenerator;
        public TRandomEngine(CharGeneratorSettings charGenerator) => this.charGenerator = charGenerator;


        /// <summary>
        /// данная функция генерирует новый массив из случайных символов при каждом обращении
        /// тоесть каждый раз мы получаем новый массив со значениями из которых уже будем выбирать
        /// нужное нам значение для строки
        /// </summary>
        private void GenerateByteList()
        {
            var resultList = new List<int>();

            for (int i = 0; i < charIndexes.Length; i++)
            {
                Random random = new();

                // соотношение количества символов из кадого массива (в выборке кратной 10 символам мы получим +3 за каджый шаг)
                var ratio = Convert.ToInt32(
                    Math.Round(
                        Convert.ToDecimal(
                            charIndexes[i].Length / 3), 0
                            ));

                // дополнительная погрешность в количестве символов в массиве для увеличения случайности
                var uncertainty = random.Next(ratio * -1, ratio); 

                // количество символов представленных в массиве
                var instances = (ratio + uncertainty < 1) ? 1 : ratio + uncertainty;

                // генерируем количество символов из каждоей категории (массива) пропорционально
                // количеству символов минимального элемента массива и ммаксимального
                // погрешность и его производная instances задаёт количество символов
                // в представленных будущем массиве, тоесть:
                // сначала берётся перый массив у него из 10 значений должны выбраться 3
                // но uncertainty может 
 
                    for (int k = 0; k < instances; k++)
                    {

                        var currentArrIndex = random.Next(0, charIndexes.Length);
                        var currentArrIndexLength = charIndexes[currentArrIndex].Length;
                        var currentArrItemIndex = random.Next(0, currentArrIndexLength);

                    ByteList.Add(charIndexes[currentArrIndex][currentArrItemIndex]);
                        //resultList.Add(charIndexes[currentArrIndex][currentArrItemIndex]);
                    }

                // если удаляем дубликаты,из циклического списка и запивыаем уникальные значения в главный список
                // тогда получается соотношение вычисления не равное, где массиву с большим количеством знаков удаётся получить
                // больше знаков в итоге [numbers = 281][letters = 349][signs = 370] 
                //ByteList = resultList.Union(resultList).ToList();
            }
        }

        /// <summary>
        //// очищает текущий список для следующей операции
        /// Нужно что бы получать случайный массив каждый раз и не накапливать данные
        /// </summary>
        private void ClearByteList() => ByteList.Clear();


        /// <summary>
        /// Метод генерурующий значение по ascii символа из массива, который мы сгенерировали внутри
        /// </summary>
        /// <returns></returns>
        public int GetCharByteCode()
        {
            GenerateByteList();

            //var sb = new StringBuilder();
            //Console.WriteLine(sb.AppendJoin(",", ByteList));
            Random bigOrSmall = new Random();
            Random randomIndex = new Random();

            var currentIndex = randomIndex.Next(0, ByteList.Count());
            var result = ByteList[currentIndex];

            ClearByteList();

            if (result > 96 && result < 123)
            {
                if (charGenerator.UseBigLetters == true && bigOrSmall.Next(0, 2) == 1)
                {
                    return result - 32;
                }
                return result;
            }            
            return result;
        }

        private int GetArrayLength()
        {
            int result = 0;

            if (charGenerator.UseSmallLetters || charGenerator.UseBigLetters)
                result += 1;

            if (charGenerator.UseNumbers)
                result += 1;

            if (charGenerator.UseSymbols)
                result += 1;

            return result;
        }

    }
}

//private int ClusterLength()
//{
//    var min = charIndexes.Min(i => i.Length);
//    var max = charIndexes.Max(i => i.Length);
//    var result = 0;

//    if (min >= 3 && min <= 10)
//        return result = min;

//    return result;
//}


//byte[] symbols = new byte[] { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 58, 59, 60, 61, 62, 63, 64, 91, 92, 93, 94, 95, 96, 123, 124, 125, 126 }; // symbols
//randomArray = new byte[GetArrayLength()];

//public string GetChar()
//{
//    var arrlength = GetArrayLength();

//    byte[] randomArray = new byte[arrlength];

//    return "";
//}


//private int GetArrayLength()
//{
//    int result = 0;

//    if (charGenerator.UseSmallLetters || charGenerator.UseBigLetters)            
//        result += letters.Length;

//    if (charGenerator.UseNumbers)            
//        result += numbs.Length;            

//    if (charGenerator.UseSymbols)
//       result += symbols.Length;            

//    return result;
//}

//private byte[] SetArrayData()
//{


//    if (charGenerator.UseSmallLetters || charGenerator.UseBigLetters)
//        randomArray.Append(letters);

//    if (charGenerator.UseNumbers)
//        result += numbs.Length;

//    if (charGenerator.UseSymbols)
//        result += symbols.Length;

//    return result;
//}

// создаётся массив из значений которые будут использоваться в выборке на основе опций
// где значения являются номерами в таблице ascii

// создаётся новый массив в который случайным образом записываются значения из первого массива
// по случайному индексу формируется новый массив с данными

//выбирается значение на основе нового случайного массива (в который могут включаться символы, цифры и маленькие буквы)

// если у наших опуций включена возможность Больших букв и если наш генератор получил число 1 (использовать большие буквы)
// if options.BigLetters == true and (arr[i] > 96 and arr[i] < 123) то смещаем значение на -32 и return char

// byte[] 
//byte[] 

//var header = new byte[]
//{
//    97
//};
//Console.WriteLine(header[0]);
//Console.WriteLine(String.Join(",", Encoding.ASCII.GetString(header)));
//header[0] -= 32;
//Console.WriteLine(header[0]);
//Console.WriteLine(String.Join(",", Encoding.ASCII.GetString(header)));
//return String.Join(",", Encoding.ASCII.GetString(header));

