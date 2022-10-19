using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRandom.Core
{
    /// <summary>
    /// Ядро генератора случайных чисел, которое не зависит от Random (в будущем) 
    /// и реализует собственнный способ генерации случайных числел
    /// как идея - генерация чисел на уровне бинарного кода
    /// - задаётся шаблон
    /// - делается сдвиг (право или лево)
    /// - выводиться результат в виде массива байтов
    /// </summary>
    public class TRandomTick
    {

        public int Tick(int minvalue, int maxvalue)
        {
            return new Random().Next(minvalue, maxvalue);    
        }
    }
}
