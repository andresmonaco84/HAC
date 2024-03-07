using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Reflection;

namespace HospitalAnaCosta.Framework.Data
{
    /// <summary>
    /// Classe base para acesso ao banco de dados
    /// </summary>
    /// 
    [Serializable()]
    public class BaseData
    {

        #region "Métodos Auxiliares IDataReader"

        /// <summary>
        /// Converte o campo desejado de um DataReader para Binary (Image)
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public byte[] GetAsBinary(string name, IDataReader reader)
        {            
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return (Byte[])reader[name];
        }


        /// <summary>
        /// Converte o campo desejado de um DataReader para Short
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public short? GetAsShort(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt16(reader[name]);
        }


        /// <summary>
        /// Converte o campo desejado de um DataReader para Byte
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public byte? GetAsByte(string name, IDataReader reader)
        {            
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToByte(reader[name]);
        }


        /// <summary>
        /// Converte o campo desejado de um DataReader para Int
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public int? GetAsInt(string name, IDataReader reader)
        {            
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt32(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para Int64 (long)
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public Int64? GetAsLong(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt64(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para string
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public string GetAsString(string name, IDataReader reader)
        {
            string sRetorno = (reader[name] == System.DBNull.Value ? "" : reader[name]).ToString();
            return sRetorno.Trim();
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para float
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public float? GetAsFloat(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return (float)Convert.ToDecimal(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para double
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public double? GetAsDouble(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDouble(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para decimal
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public decimal? GetAsDecimal(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDecimal(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para DateTime
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public DateTime? GetAsDateTime(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado "S" ou "N" de um DataReader para Booleano
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public bool GetAsBoolean(string name, IDataReader reader)
        {
            string result = reader[name] == System.DBNull.Value || reader[name].ToString().Trim().Equals("") ? "N" : reader[name].ToString();
            return result.Equals("S") ? true : false;
        }

        #endregion

        #region "Métodos Auxiliares DataRow"

        /// <summary>
        /// Converte o campo desejado de um DataRow para Binary (Image)
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public byte[] GetAsBinary(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return (Byte[])row[name];
        }


        /// <summary>
        /// Converte o campo desejado de um DataRow para Short
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public short? GetAsShort(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt16(row[name]);
        }


        /// <summary>
        /// Converte o campo desejado de um DataRow para Byte
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public byte? GetAsByte(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToByte(row[name]);
        }


        /// <summary>
        /// Converte o campo desejado de um DataRow para Int
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public int? GetAsInt(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt32(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para Int64 (long)
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public Int64? GetAsLong(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt64(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para string
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public string GetAsString(string name, DataRow row)
        {
            string sRetorno = (row[name] == System.DBNull.Value ? "" : row[name]).ToString();
            return sRetorno.Trim();
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para float
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public float? GetAsFloat(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return (float)Convert.ToDecimal(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para double
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public double? GetAsDouble(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDouble(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para decimal
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public decimal? GetAsDecimal(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDecimal(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para DateTime
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public DateTime? GetAsDateTime(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado "S" ou "N" de um DataRow para Booleano
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public bool GetAsBoolean(string name, DataRow row)
        {
            string result = row[name] == System.DBNull.Value || row[name].ToString().Trim().Equals("") ? "N" : row[name].ToString();
            return result.Equals("S") ? true : false;
        }

        #endregion
    }
}
