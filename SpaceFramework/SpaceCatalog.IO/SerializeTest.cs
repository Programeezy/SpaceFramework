using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace SpaceCatalog.IO
{
    public static class Serializator
    {

        public static void Serialize(object obj, StreamWriter sw)
        {
            Type t = obj.GetType();

            //MessageBox.Show("Сериализация началась.");
            Trace.WriteLine("Cериализацияё");

            if (obj is IEnumerable)
            {
                string name = t.Name;
                if (name.Contains('`'))
                {
                    name = name.Replace("`", "apos");
                }
                sw.WriteLine(Begin(name));
                IEnumerable elem = (IEnumerable)obj;
                foreach (var element in elem)
                {
                    Private_Serialize(element, sw);
                }
                sw.WriteLine(End(name));

            }
            else
                Private_Serialize(obj, sw);


        }

        private static string Begin(string name)
        {
            return "<" + name + ">";
        }

        private static string End(string name)
        {
            return "</" + name + ">";
        }

        private static string FormXmlLine(string name, string value)
        {
            return "<" + name + ">" + value + "</" + name + ">";
        }

        private static void Private_Serialize(object obj, StreamWriter sw)
        {
            Type t = obj.GetType();
            FieldInfo[] fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            sw.WriteLine(Begin(t.Name));
            foreach (FieldInfo field in fi)
            {
                if (typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    IEnumerable elements = (IEnumerable)field.GetValue(obj);
                    foreach (var element in elements)
                    {
                        Private_Serialize(element, sw);
                    }
                }
                sw.WriteLine(FormXmlLine(field.Name, field.GetValue(obj).ToString()));
            }
            sw.WriteLine(End(t.Name));
        }

        public static void Deserialize(object obj, string filepath)
        {

            string name;
            using (XmlReader reader = XmlReader.Create(filepath))
            {
                while (reader.Read())
                {
                    Type t = obj.GetType();
                    if (reader.IsStartElement())
                    {
                        name = reader.Name;
                        if (name.Contains("apos"))
                        {
                            name = name.Replace("apos", "`");
                        }
                        if (name == t.Name)
                        {

                        }
                        else
                        {
                            if (obj is IEnumerable)
                            {
                                IEnumerable elem = (IEnumerable)obj;
                            }
                            // FieldInfo[] Fi = t.GetFields();

                        }
                    }
                }

            }

        }

    }
}
