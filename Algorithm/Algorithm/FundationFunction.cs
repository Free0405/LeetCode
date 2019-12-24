using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace Algorithm.Algorithm
{
    public class FundationFunction
    {
        public static double[] IEnumerableToDoubleArray(System.Collections.IEnumerable list)
        {
            List<double> doubleList = new List<double>();
            foreach (object o in list)
            {
                doubleList.Add(Convert.ToDouble(o));
            }
            return doubleList.ToArray();
        }
        public static object[] IEnumerableToObjectArray(System.Collections.IEnumerable list)
        {
            List<object> doubleList = new List<object>();
            foreach (object o in list)
            {
                doubleList.Add(o);
            }
            return doubleList.ToArray();
        }
        public static string ListDoubleArrayToString(IEnumerable<double[]> arrayList)
        {
            string[] parts = new string[arrayList.Count()];
            int count = 0;
            foreach (double[] numarray in arrayList)
            {
                parts[count] = DoubleArrayToString(numarray);
                count++;
            }
            string result = String.Join(",", parts);
            return "[" + result + "]";
        }
        public static string ListStringToString(IEnumerable<string> arrayList)
        {
            string[] parts = new string[arrayList.Count()];
            int count = 0;
            foreach (string numarray in arrayList)
            {
                parts[count] = numarray;
                count++;
            }
            string result = String.Join(",", parts);
            return "[" + result + "]";
        }
        public static List<double> StringToListDouble(string str)
        {
            string s = str;
            while (s.StartsWith("["))
            {
                s = s.Remove(0, 1);

            }
            while (s.EndsWith("]"))
            {
                s.Remove(s.Length - 1, 1);
            }
            string[] parts = s.Split(',');
            List<double> numList = new List<double> { };
            for (int i = 0; i < parts.Length; i++)
            {
                numList.Add(Convert.ToDouble(parts[i]));
            }
            return numList;
        }
        public static List<string> StringToListString(string str)
        {
            string s = str;
            while (s.StartsWith("["))
            {
                s = s.Remove(0, 1);

            }
            while (s.EndsWith("]"))
            {
                s = s.Remove(s.Length - 1, 1);
            }
            string[] parts = s.Split(',');
            List<string> stringList = new List<string> { };
            for (int i = 0; i < parts.Length; i++)
            {
                stringList.Add(Convert.ToString(parts[i]));
            }
            return stringList;
        }
        public static List<double[]> StringToListDoubleArray(string str)
        {
            string s = str;
            while (s.StartsWith("["))
            {
                s = s.Remove(0, 1);
            }
            while (s.EndsWith("]"))
            {
                s = s.Remove(s.Length - 1, 1);
            }
            s = s.Replace("],[", "|");
            string[] parts = s.Split('|');
            List<double[]> numarray = new List<double[]>();
            for (int i = 0; i < parts.Length; i++)
            {
                numarray.Add(StringToDoubleArray(parts[i]));
            }
            return numarray;
        }

        public static string DoubleArrayToString(double[] DoubleArray, bool trapped = true)
        {
            string s = "";
            if (DoubleArray.Length == 0) return s;
            s += DoubleArray[0];
            for (int i = 1; i < DoubleArray.Length; i++)
            {
                s += "," + DoubleArray[i];
            }
            return (trapped ? "[" : "") + s + (trapped ? "]" : "");
        }
        public static string ListArrayToString<T>(IEnumerable<T> ListArray, bool trapped = true)
        {
            string s = "";
            if (ListArray.Count() == 0) return s;
            s += ListArray.ElementAt(0).ToString();
            for (int i = 1; i < ListArray.Count(); i++)
            {
                s += "," + ListArray.ElementAt(i).ToString();
            }
            return (trapped ? "[" : "") + s + (trapped ? "]" : "");
        }
        public static double[] StringToDoubleArray(string str)
        {
            string s;
            if (str.StartsWith("[") && str.EndsWith("]"))
            {
                s = str.Remove(str.Length - 1, 1);
                s = s.Remove(0, 1);
            }
            else s = str;
            string[] section = s.Split(',');
            double[] DoubleArray = new double[section.Length];
            for (int i = 0; i < DoubleArray.Length; i++)
            {
                if (isNum(section[i])) DoubleArray[i] = Convert.ToDouble(section[i]);
                else DoubleArray[i] = 0;
            }
            return DoubleArray;
        }

        public static bool isNum(string str)
        {
            bool sign = false;
            bool _decimal = false;
            bool hasE = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e' || str[i] == 'E')
                {
                    if (i == str.Length - 1) return false;
                    if (hasE) return false;
                    hasE = true;
                }
                else if (str[i] == '+' || str[i] == '-')
                {
                    if (sign && str[i - 1] != 'e' && str[i - 1] != 'E')
                        return false;
                    if (!sign && i > 0 && str[i - 1] != 'e' && str[i - 1] != 'E')
                        return false;
                    sign = true;
                }
                else if (str[i] == '.')
                {
                    if (hasE || _decimal) return false;
                    _decimal = true;
                }
                else if (str[i] < '0' || str[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        public static string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }
        public static object deepClone(object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            memoryStream.Position = 0;
            return formatter.Deserialize(memoryStream);
        }
    }
}
