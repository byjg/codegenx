using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CodeGenX.Classes
{
    public class ExtraPropertiesXML : BaseXML
    {
        public ExtraPropertiesXML(string xml)
            : base(xml)
        { }

        public ExtraPropertiesXML(string xml, string xsd) 
            : base(xml, xsd)
        { }

        public Dictionary<string, string> GetPropertyValues(string tableName)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            XmlNodeList nodes = this._nodeRoot.SelectNodes("allAttributes/attribute");
            foreach (XmlNode node in nodes)
            {
                result.Add(node.Attributes["name"].Value, node.Attributes["defaultValue"].Value);
            }

            nodes = this._nodeRoot.SelectNodes("table[@name='" + tableName + "']/attribute");
            foreach (XmlNode node in nodes)
            {
                result[node.Attributes["name"].Value] = node.Attributes["value"].Value;
            }


            return result;
        }

        public string GetSaveTo(string table)
        {
            return this.GetParameterFromTable(table, "saveTo");
        }

        public string GetFileName(string table)
        {
            return this.GetParameterFromTable(table, "filename");
        }

        protected string GetParameterFromTable(string tableName, string parameter)
        {
            string result = "";
            XmlNode node = this._nodeRoot.SelectSingleNode("table[@name='" + tableName + "']");
            if (node != null)
            {
                XmlAttribute attr = node.Attributes[parameter];
                if (attr != null)
                {
                    result = attr.Value;
                }
            }

            if (result == "")
            {
                node = this._nodeRoot.SelectSingleNode("allAttributes");
                if (node != null)
                {
                    XmlAttribute attr = node.Attributes[parameter];
                    if (attr != null)
                    {
                        result = attr.Value;
                    }
                }
            }

            return result;
        }

    }
}
