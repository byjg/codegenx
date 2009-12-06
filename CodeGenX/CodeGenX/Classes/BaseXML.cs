using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace CodeGenX.Classes
{
    public class BaseXML
    {
        protected XmlDocument _xmlDoc;
        protected XmlElement _nodeRoot;
        protected string _xmlFileName;

        public BaseXML(string xml)
            : this(xml, null)
        { }

        public BaseXML(string xml, string xsd)
        {
            if (!String.IsNullOrEmpty(xsd))
            {
                string xsdPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + Platform.Slash() + "Xsd" + Platform.Slash() + xsd + ".xsd";
                if (System.IO.File.Exists(xsdPath))
                {
                    ValidateResult vr = XMLValidator.Validate(xml, xsdPath);
                    if (!vr.valid)
                    {
                        throw new Exception("O documento XML não foi validado pelo XSD. \r\nErros:\r\n" + vr.errorMessage);
                    }
                }
                else
                {
                    throw new Exception("O documento XSD localizado em: '" + xsdPath + "' não existe");
                }
            }

            this._xmlDoc = new XmlDocument();
            this._xmlDoc.Load(xml);
            this._nodeRoot = this._xmlDoc.DocumentElement;

            this._xmlFileName = xml;
        }

        public string Transform(string xslfile)
        {
            return this.Transform(xslfile, null);
        }

        public string Transform(string xslfile, XsltArgumentList xslArg)
        {
            //Create a IO Stream
            System.IO.StringWriter oSW = new System.IO.StringWriter();
            try
            {
                System.Xml.XmlTextReader oXR = new System.Xml.XmlTextReader(this._xmlFileName);

                System.Xml.Xsl.XslTransform oXSLT = new System.Xml.Xsl.XslTransform();

                oXSLT.Load(xslfile);

                System.Xml.XPath.XPathDocument oXPath = new System.Xml.XPath.XPathDocument(oXR);

                oXSLT.Transform(oXPath, xslArg, oSW);
            }
            catch (System.Exception e)
            {
                //Put in custom error handler here...
                throw e;
            }
            return oSW.ToString();
        }
    }

}
