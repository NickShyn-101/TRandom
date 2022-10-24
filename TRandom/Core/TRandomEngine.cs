
namespace TRandomLib.Core
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

        List<int> CharList = new List<int>();

        private readonly CharGeneratorSettings charGenerator;
        public TRandomEngine() => this.charGenerator = new CharGeneratorSettings();




        /// <summary>
        /// <para>Данный метод генерирует новый массив случайных символов из ASCII таблицы  при каждом вызове</para>
        /// <para > тоесть каждый раз мы получаем новый массив со значениями из которых другая функция будет выбирать значение </para>
        /// <para > Другими словами это первый этап рандомайзера</para>
        /// <para>На выходе мы генерируем CharList с случайными значениями {48, 65,122,95,100...}</para>
        /// <para>Длина массива так же не имеет привязаного размера, кроме того что он не может быть меньшим чем 3</para>
        /// </summary>
        private void GenerateByteList()
        {
            var resultList = new List<int>();

            for (int i = 0; i < charIndexes.Length; i++)
            {
                TRandomTick random = new();

                // соотношение количества символов из кадого массива (в выборке кратной 10 символам мы получим +3 за каджый шаг)
                var ratio =
                    Math.Sign(
                            charIndexes[i].Length / 3
                            );

                // дополнительная погрешность в количестве символов в массиве для увеличения случайности
                var uncertainty = random.Tick(ratio * -1, ratio);
                // количество символов представленных в массиве
                var instances = (ratio + uncertainty < 1) ? 1 : ratio + uncertainty;

                // генерируем количество символов из каждоей категории (массива) пропорционально
                // количеству символов минимального элемента массива и ммаксимального
                // погрешность и его производная instances задаёт количество символов
                // в представленных будущем массиве, тоесть:
                // сначала берётся перый массив у него из 10 значений должны выбраться 3
                // но uncertainty может получиться от 1 до 6 значений в зависимости от ситуации 
                for (int k = 0; k < instances; k++)
                {

                    var currentArrIndex = random.Tick(0, charIndexes.Length);
                    var currentArrLength = charIndexes[currentArrIndex].Length;
                    var currentArrItemIndex = random.Tick(0, currentArrLength);

                    // при обычном подходе, когда мы не удаляем дубликаты из резульирующего списка, тогда
                    // выпбока получается примерно средней ~[numbers = 329][letters = 343][signs = 328]
                    CharList.Add(charIndexes[currentArrIndex][currentArrItemIndex]);
                    //resultList.Add(charIndexes[currentArrIndex][currentArrItemIndex]);
                }

                // если удаляем дубликаты,из циклического списка и запивыаем уникальные значения в главный список
                // тогда получается соотношение вычисления не равное, где массиву с большим количеством знаков удаётся получить
                // больше знаков в итоге ~[numbers = 281][letters = 349][signs = 370] перекос в меньшее для чисел и в большую для занков
                //CharList = resultList.Union(resultList).ToList();
            }
        }


        /// <summary>
        /// очищает текущий список для следующей операции
        /// Нужно что бы получать случайный массив каждый раз и не накапливать данные
        /// </summary>
        private void ClearByteList() => CharList.Clear();

        /// <summary>
        /// Метод генерурующий значение по ascii символа из массива, который мы сгенерировали внутри
        /// </summary>
        /// <returns>e.g a = 97, 0 = 48 ...</returns>
        public int GetCharCode()
        {
            GenerateByteList();

            TRandomTick randomIndex = new TRandomTick();

            int currentIndex = (int)randomIndex.Tick(0, CharList.Count());
            int result = CharList[currentIndex];

            ClearByteList();


            // включаем развитвление при использовании больших и маленьких букв
            if (result > 96 && result < 123)
            {
                if (charGenerator.UseBigLetters == true && randomIndex.Tick(0, 2) == 1)
                {
                    return result - 32;
                }
                return result;
            }
            return result;
        }


        public T GenerateNumber<T>(T minValue, T MaxValue) where T : struct
        {
            T result = default;
            return (T)result;
        }

        // ToDo => сделать возмодность изменять массивы начальных значений

        // ToDo => // сделать функцию вывода массива случайных значений наверное в реалзации классов и интерфейсов

        // ToDo => Заменить метод Random на свою реализацию TRandomTick.Tick();

        // ToDo => создать конфигурационный статический класс / singleton для возможности выбора основы генератора
        //          например    генерация на основе уникальной выборки  ~[numbers = 281][letters = 349][signs = 370]
        //                      генерация на основе равных шансов       ~[numbers = 329][letters = 343][signs = 328]
    }
}
