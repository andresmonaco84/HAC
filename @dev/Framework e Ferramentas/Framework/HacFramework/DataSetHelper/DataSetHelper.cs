using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HospitalAnaCosta.Framework.DataSetHelper
{
    public class DataSetHelper
    {
        public DataSet ds;

        public DataSetHelper(ref DataSet DataSet)
        {
            ds = DataSet;
        }
        public DataSetHelper()
        {
            ds = null;
        }

        private System.Collections.ArrayList m_FieldInfo; 
        private string[] m_FieldList;

        private void ParseFieldList(bool AllowRelation, string[] FieldList)
        {
            /*
             * This code parses FieldList into FieldInfo objects  and then 
             * adds them to the m_FieldInfo private member
             * 
             * FieldList systax:  [SourceTable].[relationname.]fieldname[ alias], ...
            */
            if (m_FieldList == FieldList) return;
            m_FieldInfo = new System.Collections.ArrayList();
            m_FieldList = FieldList;
            FieldInfo Field; 
            string[] FieldParts;
            string[] Fields = FieldList;
            int i;
            for (i = 0; i <= Fields.Length - 1; i++)
            {
                Field = new FieldInfo();
                //parse FieldAlias
                FieldParts = Fields[i].Trim().Split(' ');
                switch (FieldParts.Length)
                {
                    case 1:
                        //to be set at the end of the loop
                        break;
                    case 2:
                        Field.FieldAlias = FieldParts[1];
                        break;
                    default:
                        throw new Exception("Too many spaces in field definition: '" + Fields[i] + "'.");
                }
                //parse FieldName and RelationName
                FieldParts = FieldParts[0].Split('.');
                switch (FieldParts.Length)
                {
                    case 1:
                        Field.FieldName = FieldParts[0];
                        break;
                    case 2:
                        if (AllowRelation == false)
                            throw new Exception("Relation specifiers not permitted in field list: '" + Fields[i] + "'.");
                        Field.RelationName = FieldParts[0].Trim();
                        Field.FieldName = FieldParts[1].Trim();
                        break;
                    case 4:
                        if (AllowRelation == false)
                            throw new Exception("Relation specifiers not permitted in field list: '" + Fields[i] + "'.");
                        Field.RelationName = FieldParts[0].Trim();
                        Field.SourceTable2 = FieldParts[1].Trim();
                        Field.RelationName2 = FieldParts[2].Trim();
                        Field.FieldName = FieldParts[3].Trim();
                        break;
                    default:
                        throw new Exception("Invalid field definition: " + Fields[i] + "'.");
                }
                if (Field.FieldAlias == null)
                    Field.FieldAlias = Field.FieldName;
                m_FieldInfo.Add(Field);
            }
        }

        public DataTable CreateJoinTable(string TableName, DataTable SourceTable, string[] FieldList)
        {
            /*
             * Creates a table based on fields of another table and related parent tables
             * 
             * FieldList syntax: [relationname.]fieldname[ alias][,[relationname.]fieldname[ alias]]...
            */
            if (FieldList == null)
            {
                throw new ArgumentException("You must specify at least one field in the field list.");
                //return CreateTable(TableName, SourceTable);
            }
            else
            {
                DataTable dt = new DataTable(TableName);
                ParseFieldList(true, FieldList);
                foreach (FieldInfo Field in m_FieldInfo)
                {
                    if (Field.RelationName == null)
                    {
                        DataColumn dc = SourceTable.Columns[Field.FieldName];
                        dt.Columns.Add(dc.ColumnName, dc.DataType, dc.Expression);
                    }
                    else
                    {
                        DataColumn dc;
                        if (Field.SourceTable2 == null)
                        {
                            dc = SourceTable.ParentRelations[Field.RelationName].ParentTable.Columns[Field.FieldName];
                        }
                        else
                        {
                            dc = ds.Tables[Field.SourceTable2].ParentRelations[Field.RelationName2].ParentTable.Columns[Field.FieldName];
                        }
                        dt.Columns.Add(dc.ColumnName, dc.DataType, dc.Expression);
                    }
                }
                //if (ds != null)
                //    ds.Tables.Add(dt);
                return dt;
            }
        }

        public void InsertJoinInto(DataTable DestTable, DataTable SourceTable, string RowFilter, string Sort, string[] FieldList)
        {
            /*
            * Copies the selected rows and columns from SourceTable and inserts them into DestTable
            * FieldList has same format as CreatejoinTable
            */
            if (FieldList == null)
            {
                throw new ArgumentException("You must specify at least one field in the field list.");
                //InsertInto(DestTable, SourceTable, RowFilter, Sort);
            }
            else
            {
                ParseFieldList(true, FieldList);
                DataRow[] Rows = SourceTable.Select(RowFilter, Sort);
                foreach (DataRow SourceRow in Rows)
                {
                    DataRow DestRow = DestTable.NewRow();
                    foreach (FieldInfo Field in m_FieldInfo)
                    {
                        if (Field.RelationName == null)
                        {
                            DestRow[Field.FieldName] = SourceRow[Field.FieldName];
                        }
                        else
                        {
                            if (Field.SourceTable2 == null)
                            {
                                DataRow ParentRow = SourceRow.GetParentRow(Field.RelationName);
                                if (ParentRow != null)
                                {
                                    DestRow[Field.FieldName] = ParentRow[Field.FieldName];
                                }
                            }
                            else
                            {
                                //Utilizado quando temos um relacionamento em segundo nivel 
                                DataRow ParentRow = SourceRow.GetParentRow(Field.RelationName).GetParentRow(Field.RelationName2);
                                if (ParentRow != null)
                                {
                                    DestRow[Field.FieldName] = ParentRow[Field.FieldName];
                                }
                            }
                        }
                    }
                    DestTable.Rows.Add(DestRow);
                }
            }
        }

        public DataTable SelectJoinInto(string TableName, DataTable SourceTable, string RowFilter, string Sort, string[] FieldList)
        {
            /*
             * Selects sorted, filtered values from one DataTable to another.
             * Allows you to specify relationname.fieldname in the FieldList to include fields from
             *  a parent table. The Sort and Filter only apply to the base table and not to related tables.
            */
            DataTable dt = CreateJoinTable(TableName, SourceTable, FieldList);
            InsertJoinInto(dt, SourceTable, RowFilter, Sort, FieldList);
            return dt;
        }
    }

    public class FieldInfo
    {
        public string SourceTable2;
        public string RelationName2;

        public string RelationName;
        public string FieldName;	//source table field name
        public string FieldAlias;	//destination table field name
        public string Aggregate;
    }
}
