using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace HospitalAnaCosta.Framework
{
    /// <summary>
    /// Classe de Excessão que representa uma excessão de negócio onde a camada de 
    /// apresentação deverá tratar e exibir alerta para o usuário
    /// </summary>
    [Serializable()]
    public class HacException : System.Exception
    {

        public HacException() : base () {}
		public HacException(string Message) : base (Message) {}
        public HacException(string Message, Exception InnerException) : base(Message, InnerException) { }   
        protected HacException(SerializationInfo serializationInfo, StreamingContext streamingContext)
          : base(serializationInfo, streamingContext) { }
    }
}
