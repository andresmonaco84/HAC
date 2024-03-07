using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace HospitalAnaCosta.Framework.ValueObject
{
    /// 
    /// Classe responsável por serializar/deserializar entidades ValueObject.
    /// 
    public class VOSerializer<T>
    {
        public VOSerializer()
        {
        }

        /// <summary>
        /// Cria xml string a partir de uma entidade VO.
        /// Ex: VOSerializer<EnderecoVO> oVOSerializer = new VOSerializer<EnderecoVO>();
        /// EnderecoVO enEnderecoVO = new EnderecoVO(1, "Rua 1"); 
        /// string strXml = oVOSerializer.SerializeVO(enEnderecoVO);
        /// </summary>
        /// <param name="enVO">Entidade do tipo genérico T já instanciada</param>
        /// <returns>String de Xml</returns>
        public string SerializeVO(T enVO)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(enVO.GetType());                
                StringWriter sWriter = new StringWriter();
                
                // Serializa a entidade enVO para xml.
                xmlSer.Serialize(sWriter, enVO);
                
                // Retorna a string de xml
                return sWriter.ToString();
            }
            catch (Exception ex)
            {
                // Propaga a exception.
                throw ex;
            }
        }

        /// <summary>
        /// Cria xml string a partir de uma entidade VO.
        /// </summary>        
        /// <param name="lstVO">Lista de entidades do tipo genérico T já instanciada</param>
        /// <returns>String de Xml</returns>
        public string SerializeVO(List<T> lstVO)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(lstVO.GetType());
                StringWriter sWriter = new StringWriter();

                // Serializa a entidade enVO para xml.
                xmlSer.Serialize(sWriter, lstVO);

                // Retorna a string de xml
                return sWriter.ToString();
            }
            catch (Exception ex)
            {
                // Propaga a exception.
                throw ex;
            }
        }

        /// <summary>
        /// Deserializar o xml na entidade VO especificada.
        /// Exemplo: ProdutoVO enProdutoVO = (ProdutoVO)oVOSerializer.DeserializeXml(strXml, new ProdutoVO());
        /// </summary>
        /// <param name="xml">String xml a ser Deserializada</param>
        /// <param name="enVO">Entidade do tipo genérico T já instanciada</param>        
        /// <returns>Instancia VO do tipo informado</returns>
        /// <example>ProdutoVO enProdutoVO = (ProdutoVO)oVOSerializer.DeserializeXml(strXml, new ProdutoVO());</example>
        public T DeserializeXml(string xml, T enVO)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(enVO.GetType());
                // Lê o XML
                StringReader sReader = new StringReader(xml);
                // Cast do deserializado xml para o tipo VO.
                T retVO = (T)xmlSer.Deserialize(sReader);                
                // Retorna o Value Object
                return retVO;
            }
            catch (Exception ex)
            {
                // Propaga a exception.
                throw ex;
            }
        }

        /// <summary>
        /// Deserializar o xml na lista de entidades VO especificada.
        /// </summary>
        /// <param name="xml">String xml a ser Deserializada</param>
        /// <param name="lstVO">Lista de entidades do tipo genérico T já instanciada</param>
        /// <returns>Instancia VO do tipo informado</returns>
        /// <example>List.ProdutoVO. lstProdutoVO = (List.ProdutoVO.)DeserializeXml(strXml, new List.ProdutoVO.());</example>
        public List<T> DeserializeXml(string xml, List<T> lstVO)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(lstVO.GetType());
                // Lê o XML
                StringReader sReader = new StringReader(xml); 
                List<T> lstRetVO = (List<T>)xmlSer.Deserialize(sReader);

                // Retorna o Value Object
                return lstRetVO;
            }
            catch (Exception ex)
            {
                // Propaga a exception
                throw ex;
            }
        }
    }
}
