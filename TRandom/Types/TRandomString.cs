using TRandom.Core;

namespace TRandom.Types
{
    public class TRandomString : ITRandom<string>
    {

        private TRandomOptions _randOptions;
        private int _length;
        private byte[] _bytes;
        private char _divider;

        public TRandomString()
        {

        }

        public TRandomString(int length, TRandomOptions options)
        {

        }

        public TRandomString(byte[] signature, char divider, TRandomOptions? options)
        {
            //_randOptions = options ?? new TRandomOptions();
        }

        public string Next()
        {
            throw new NotImplementedException();
        }
    }
}