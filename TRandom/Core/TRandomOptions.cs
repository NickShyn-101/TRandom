namespace TRandomLib.Core
{
    public class TRandomOptions
    {

        private byte[] _buffer;

        public TRandomOptions() { }

        public TRandomOptions(byte[] buffer)
        {
            _buffer = buffer;
        }

        public bool AllowSmallLetters { get; set; } = true; // 97-122

        public bool AllowBigLetters { get; set; } = true; // 65-90

        public bool AllowNumbers { get; set; } = true; // 48-57

        public bool AllowSpace { get; set; } = false; // 32

        public bool AllowMinusSign { get; set; } = true;

        public bool AllowASCII { get; set; } = true;


    }
}