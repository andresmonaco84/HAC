using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;
using System.Runtime.Serialization;

namespace HospitalAnaCosta.Services.BeneficiarioACS.DTO
{
    [Serializable()]
    public class CadastroBeneficiarioNotFoundException : HacException
    {
        public CadastroBeneficiarioNotFoundException() : base() { }
        public CadastroBeneficiarioNotFoundException(string Message) : base(Message) { }
        public CadastroBeneficiarioNotFoundException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected CadastroBeneficiarioNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }
    }
}