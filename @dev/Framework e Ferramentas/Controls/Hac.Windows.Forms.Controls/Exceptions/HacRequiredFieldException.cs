using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using HospitalAnaCosta.Framework;

namespace Hac.Windows.Forms.Controls.Exceptions
{
    class HacRequiredFieldException : HacException
    {        
        public HacRequiredFieldException() : base () {}
		public HacRequiredFieldException(string Message) : base (Message) {}
        public HacRequiredFieldException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected HacRequiredFieldException(SerializationInfo serializationInfo, StreamingContext streamingContext)
          : base(serializationInfo, streamingContext) { }
    }
}
