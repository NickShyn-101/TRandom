using System.Text;
using TRandomLib.Core;

namespace TRandomLib.Types
{
    public class TRandomString : ITRandom<string>
    {

        private TRandomOptions? _randOptions;
        private int _length;
        private byte[] _bytes;
        private char _divider { get; set; }

        public TRandomString() {
            _length = 8;
            _bytes = new byte[_length];
        }
        public TRandomString(int? length) {
            _length = length ?? 8;
            _bytes = new byte[_length];
        }
        public TRandomString(byte[] signature, char? divider)
        {
            _divider = divider ?? '-';
        }




        public string Next()
        {
            TRandomEngine random = new TRandomEngine();
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < _length; i++) _bytes[i] = Convert.ToByte(random.GetCharCode());

            return sb.AppendJoin("", Encoding.ASCII.GetString(_bytes)).ToString();
        }
    }
}