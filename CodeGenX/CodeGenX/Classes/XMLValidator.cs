using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace CodeGenX.Classes
{

    public struct ValidateResult
    {
        public bool valid;
        public string errorMessage;
        public int errorCount;
    }

    public class XMLValidator
    {
        protected static string _errorMessage = "";
        protected static int _errorCount = 0;

        protected static void ValidationHandler(object sender, ValidationEventArgs args)
        {
            XMLValidator._errorMessage += args.Message + "\r\n";
            XMLValidator._errorCount++;
        }

        public static ValidateResult Validate(string XMLPath, string XSDPath)
        {
            XMLValidator._errorMessage = "";
            XMLValidator._errorCount = 0;

            try
            {
                // 1- Read XML file content
                XmlTextReader reader = new XmlTextReader(XMLPath);

                // 2- Read Schema file content
                StreamReader SR = new StreamReader(XSDPath);

                // 3- Create a new instance of XmlSchema object
                XmlSchema Schema = new XmlSchema();
                // 4- Set Schema object by calling XmlSchema.Read() method
                Schema = XmlSchema.Read(SR, new ValidationEventHandler(ValidationHandler));

                // 5- Create a new instance of XmlReaderSettings object
                XmlReaderSettings ReaderSettings = new XmlReaderSettings();
                // 6- Set ValidationType for XmlReaderSettings object
                ReaderSettings.ValidationType = ValidationType.Schema;
                // 7- Add Schema to XmlReaderSettings Schemas collection
                ReaderSettings.Schemas.Add(Schema);

                // 8- Add your ValidationEventHandler address to
                // XmlReaderSettings ValidationEventHandler
                ReaderSettings.ValidationEventHandler +=
                    new ValidationEventHandler(ValidationHandler);

                // 9- Create a new instance of XmlReader object
                XmlReader objXmlReader = XmlReader.Create(reader, ReaderSettings);


                // 10- Read XML content in a loop
                while (objXmlReader.Read())
                { /*Empty loop*/}

            }//try
            // Handle exceptions if you want
            catch (UnauthorizedAccessException AccessEx)
            {
                throw AccessEx;
            }//catch
            catch (Exception Ex)
            {
                throw Ex;
            }//catch

            ValidateResult vr = new ValidateResult();
            vr.errorCount = XMLValidator._errorCount;
            vr.valid = vr.errorCount == 0;
            vr.errorMessage = XMLValidator._errorMessage;
            return vr;
        }
    }
}
