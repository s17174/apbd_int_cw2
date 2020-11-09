using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Cw2
{
    class Writer<T>
    {

        public static void WriteDataToJson(string pathOut, List<T> list)
        {
            var jsonString = JsonSerializer.Serialize(list, new JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
            }) ;
          
            File.WriteAllText(pathOut, jsonString);
        }

        public static void WriteDataToXML(string pathOut, List<T> list, string rootName)
        {
            FileStream writer = new FileStream(pathOut, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootName));
            xmlSerializer.Serialize(writer, list);
        }
    }
}
