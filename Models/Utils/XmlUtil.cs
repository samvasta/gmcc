using System;
using System.IO;
using System.Xml.Serialization;

namespace Models.Utils
{
    public static class XmlUtil
    {
        public static void Save<TRoot>(TRoot obj, string xmlPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TRoot));
            
            using(TextWriter writer = new StreamWriter(xmlPath))
            {
                serializer.Serialize(writer, obj);
            }
        }


        /// <summary>
        /// Deserializes an XML file
        /// </summary>
        /// <param name="xmlPath">path to the XML file</param>
        /// <typeparam name="TRoot">type of the root element of the xml file</typeparam>
        public static TRoot Load<TRoot>(string xmlPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TRoot));

            TRoot obj;
            
            using(FileStream fs = new FileStream(xmlPath, FileMode.Open))
            {
                try
                {
                    obj = (TRoot) serializer.Deserialize(fs);
                }
                catch(Exception e)
                {
                    //TODO
                    Console.WriteLine("Need to catch & handle this exception in XmlUtil!");
                    throw e;
                }
            }

            return obj;
        }


    }
}