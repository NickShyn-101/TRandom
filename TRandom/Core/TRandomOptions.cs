namespace TRandom.Core
{
    public class TRandomOptions
    {
        public bool AllowSmallLetters { get; set; } = true;
        public bool AllowBigLetters { get; set; } = true;
        public bool AllowNumbers { get; set; } = true;
        public bool AllowSpace { get; set; } = true;
        public bool AllowMinusSign { get; set; } = true;
        public bool AllowASCII { get; set; } = true;
    }
}