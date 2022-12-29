using CoreWCF;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace TestWCFInNetCore.ViewModel
{
    [DataContract]
    public class EchoFault
    {
        [AllowNull]
        private string _text;

        [DataMember]
        [AllowNull]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
               

    [DataContract]
    public class EchoMessage
    {
        [AllowNull]
        [DataMember]
        public string Text { get; set; }
    }
}
