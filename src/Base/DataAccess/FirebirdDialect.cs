using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperExtensions.Sql;

namespace SuperPowerEditor.Base.DataAccess
{
    public class FirebirdDialect : ISqlDialect
    {
        public virtual string GetTableName(string schemaName, string tableName, string alias)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("TableName", "tableName cannot be null or empty.");
            }

            StringBuilder result = new StringBuilder();

            result.AppendFormat(QuoteString(tableName));

            //if (!string.IsNullOrWhiteSpace(alias))
            //{
            //    result.AppendFormat(" AS {0}", QuoteString(alias));
            //}
            return tableName;
        }

        public string GetColumnName(string prefix, string columnName, string alias)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException("ColumnName", "columnName cannot be null or empty.");
            }

            StringBuilder result = new StringBuilder();

            result.AppendFormat(QuoteString(columnName));

            //if (!string.IsNullOrWhiteSpace(alias))
            //{
            //    result.AppendFormat(" AS {0}", QuoteString(alias));
            //}

            return result.ToString();
        }

        public string GetIdentitySql(string tableName)
        {
            throw new NotImplementedException("Firebird does not support get last inserted identity.");
        }

        public string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException("Firebird does not support paging.");
        }

        public string GetSetSql(string sql, int firstResult, int maxResults, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException("Firebird does not support set sql.");
        }

        public bool IsQuoted(string value)
        {
            if (value.Trim()[0] == OpenQuote)
            {
                return value.Trim().Last() == CloseQuote;
            }

            return false;
        }

        public string QuoteString(string value)
        {
            if (IsQuoted(value) || value == "*")
            {
                return value;
            }
            return $"{OpenQuote}{value.Trim()}{CloseQuote}";
        }

        public char OpenQuote => '"';
        public char CloseQuote => '"';
        public string BatchSeperator => ";" + Environment.NewLine;
        public bool SupportsMultipleStatements => false;
        public char ParameterPrefix => ':';
        public string EmptyExpression => "1=1";
    }
}