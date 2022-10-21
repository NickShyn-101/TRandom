using System.Linq;
using System.Text;
using TRandomLib.Core;

namespace TRandomLib.Types
{
    public class TRandomString : ITRandom<string>
    {

        private TRandomOptions? _randOptions;
        private int _length;
        private byte[] _bytes;
        private byte[]? _signature;
        private byte _divider { get; set; }

        public TRandomString() {
            _length = 8;
            _bytes = new byte[_length];
        }
        public TRandomString(int? length) {
            _length = length ?? 8;
            _bytes = new byte[_length];
        }
        public TRandomString(byte[] signature, char? divider = '-')
        {
            int x = signature.Length - 2;

            foreach (var item in signature)           
                x += item;
           
            _bytes = new byte[x];
            _divider = Convert.ToByte(divider);
            _signature = signature;
        }




        public string Next()
        {
            TRandomEngine random = new TRandomEngine();
            StringBuilder sb = new StringBuilder();
            
            if (_signature == null)
            {
                for (int i = 0; i < _length; i++)
                    _bytes[i] = Convert.ToByte(random.GetCharCode());
                return sb.AppendJoin("", Encoding.ASCII.GetString(_bytes)).ToString();
            }
            foreach (var item in _signature)
            {
                for (int i = 0; i < item; i++)
                {
                    _bytes.Append(Convert.ToByte(random.GetCharCode()));
                 
                }
                _bytes.Append(Convert.ToByte(_divider));

            }

            return sb.AppendJoin("",Encoding.ASCII.GetString(_bytes)).ToString();
        }
    }
}