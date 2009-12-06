using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace CodeGenX.Classes
{
    public class TorqueXML : BaseXML
    {
        public TorqueXML(string xml)
            : base(xml)
        { }

        public TorqueXML(string xml, string xsd)
            : base(xml, xsd)
        { }

        public string[] GetAllTables()
        {
            XmlNodeList nodeList = this._nodeRoot.SelectNodes("table");
            string[] ret = new string[nodeList.Count];

            int i = 0;
            foreach (XmlNode node in nodeList)
            {
                ret[i++] = node.Attributes["name"].Value;
            }
            return ret;
        }
    }

}
