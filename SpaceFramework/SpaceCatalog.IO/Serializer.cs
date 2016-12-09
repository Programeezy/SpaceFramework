using System.Collections;
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

        private static void RecursionSerialize(object graph, XmlWriter xw)
        {
            var graphType = graph.GetType();

            if (typeof(IEnumerable).IsAssignableFrom(graphType))
            {
                foreach (var item in (IEnumerable)graph)
                {
                    RecursionSerialize(item, xw);
                }
            }

            else if (graphType.IsContextful)
            {
                var properties = graphType.GetProperties();

                foreach (var property in properties)
                {
                    RecursionSerialize(property.GetValue(graph), xw);
                }
            }

            else
            {
                var prop = graphType.GetProperty(graphType.Name);
                xw.WriteElementString(graphType.Name, prop.GetValue(graph).ToString());
            }
        }

        public static void Serialize<T>(T graph, string filename)
        {
            var xw = XmlWriter.Create(GetFile(filename));
            RecursionSerialize(graph, xw);
        }

        public static T Deserialize<T>(string filename)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T), filename);
            using (TextReader tr = new StreamReader(GetFile(filename)))
            {
                try
                {
                    return (T)deserializer.Deserialize(tr);
                }
                catch(FileLoadException)
                {
                    throw new FileLoadException();
                }
            }
        }
       
    }
} 
