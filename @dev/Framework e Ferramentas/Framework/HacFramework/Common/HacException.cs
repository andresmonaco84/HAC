using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace HospitalAnaCosta.Framework
{
    /// <summary>
    /// Classe de Excess�o que representa uma excess�o de neg�cio onde a camada de 
    /// apresenta��o dever� tratar e exibir alerta para o usu�rio
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
