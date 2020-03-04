using Movisoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Movisoft.Infra.Data.Helper
{
    public class HelperBase
    {
        private string _xmlFile;
        public HelperBase(string fileName)
        {
            _xmlFile = fileName;
        }

        /// <summary>
        /// Obtiene la sentencia SQL del archivo xml
        /// </summary>
        /// <param name="idMessage"></param>
        /// <returns></returns>
        public string GetSqlXml(string idSql)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(_xmlFile);

                XmlNodeList nSqls = xDoc.GetElementsByTagName(ConstantesBase.MainNodeSql);
                XmlNodeList nSql = ((XmlElement)nSqls[0]).GetElementsByTagName(ConstantesBase.SubNodeSql);

                foreach (XmlElement nodo in nSql)
                {
                    XmlNodeList nKey = nodo.GetElementsByTagName(ConstantesBase.KeyNode);

                    if (nKey[0].InnerText == idSql)
                    {
                        XmlNodeList nQuery = nodo.GetElementsByTagName(ConstantesBase.QueryNode);
                        return nQuery[0].InnerText;
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
