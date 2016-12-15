using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SpaceCatalog.IO
{
    public static class SpaceSerializer
    {
        private static Stream GetFile(string filename)
        {
            string dir_path = Path.GetDirectoryName(filename + ".xml");
            Stream st = new FileStream(filename + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            return st;
            
        }

        /*  public static void Serialize<T>(T graph, string filename)
          {
              XmlSerializer serializer = new XmlSerializer(graph.GetType(), filename);
              using (TextWriter tw = new StreamWriter(GetFile(filename)))
              {
                  serializer.Serialize(tw, graph);
              }
          }*/

        private static XmlDocument RecursionSerialize(object graph, XmlDocument xmlDoc, XmlNode rootNode)
        {
            var graphType = graph.GetType();

            if (xmlDoc == null)
                xmlDoc = new XmlDocument();

            if (graph == null)
                return xmlDoc;

            if (rootNode == null)
            {
                rootNode = xmlDoc.CreateElement(string.Empty, graphType.Name, string.Empty);
                xmlDoc.AppendChild(rootNode);
            }

            if (graphType.IsPrimitive || graphType == typeof(decimal) || graphType == typeof(string))
            {
                if (graph != null)
                    rootNode.InnerText = graph.ToString();
            }

            else if (typeof(IEnumerable).IsAssignableFrom(graphType) || graphType.IsGenericType && graphType.GetGenericTypeDefinition() == typeof(List<>))
            {
                XmlNode node = null;

                foreach (var item in (IEnumerable)graph)
                {
                    if (node == null)
                    {
                        node = xmlDoc.CreateElement(string.Empty, item.GetType().Name, string.Empty);
                        node = rootNode.AppendChild(node);
                    }

                    RecursionSerialize(item, xmlDoc, node);
                
                }
            }

            else
            {
                var properties = graphType.GetProperties();

                foreach(var property in properties)
                {
                    XmlNode node = xmlDoc.CreateElement(string.Empty, property.Name, string.Empty);
                    node = rootNode.AppendChild(node);
                    var valor = property.GetValue(graph, null);
                    RecursionSerialize(valor, xmlDoc, node);
                }
            }

            return xmlDoc;
        }

        public static void Serialize<T>(T graph, string filename)
        {
            var xw = XmlWriter.Create(GetFile(filename));

            XmlDocument DocToWrite = RecursionSerialize(graph, null, null);
            DocToWrite.Save(xw);
        }

        public static void Deserialize<T>(string filename, ref T obj)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(GetFile("constellations"));
            XmlNodeList NodeList = XmlDoc.ChildNodes;
            RecursionDeserialize(ref obj, node);
            
        }

        private static void RecursionDeserialize<T>(ref T obj, XmlNode node)
        {
            
        }
       
    }
} 
