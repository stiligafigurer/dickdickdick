using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanochJoseftest.Data
{
    public static class XMLCategoryHandler
    {
        public static string ReadCategoryFromXML(string keyword)
        {
            if (File.Exists("Kategorier.xml"))
            {
                StreamReader reader = new StreamReader("Kategorier.xml");
                var hej = reader.ReadToEnd().Split('\n');
                reader.Close();
                return "hej";

            }
            else
            {
                File.Create("Kategorier.xml");
                StreamWriter Writer = new StreamWriter("Kategorier.xml");
                Writer.Close();
                return "hej";
            }
        }

        public static bool WriteToXML(string text)
        {
            if (File.Exists("Kategorier.xml"))
            {
                StreamReader reader = new StreamReader("Kategorier.xml");
                var lineSplit = new string[] {"\r\n"};
                var ArrOfCategories = reader.ReadToEnd().Split(lineSplit, StringSplitOptions.None);
                reader.Close();
                StreamWriter writer = File.AppendText("Kategorier.xml");
                bool exists = false;
                
                foreach(string item in ArrOfCategories)
                {
                    if(item == text)
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    writer.WriteLine(text);
                    writer.Close();
                    return true;
                }
                writer.Close();
                return false;
            }
            File.Create("Kategorier.xml");
            return false;
            
        }

        public static string[] ReadAllCategoriesFromXML()
        {
            if(File.Exists("Kategorier.xml"))
            {
                StreamReader reader = new StreamReader("Kategorier.xml");
                var SplitOn = new string[] { "\r\n" };
                var ArrOfCategories = reader.ReadToEnd().ToString().Split(SplitOn, StringSplitOptions.None);
                reader.Close();
                return ArrOfCategories;
            }
            throw new Exception();
        }

        public static bool RemoveCategoryFromXML(string name)
        {
            List<string> ListOfCategories = ReadAllCategoriesFromXML().ToList();
            bool HasLine = false;
            int LineToDelete = 0;
            for(int i = 0; i < ListOfCategories.Count; i++)
            {
                if (ListOfCategories.ElementAt(i) == name)
                {
                    HasLine = true;
                    LineToDelete = i;
                }
            }
            if(HasLine)
            {
                ListOfCategories.RemoveAt(LineToDelete);
                File.WriteAllLines(("Kategorier.xml"), ListOfCategories.ToArray());
                return true;
            }
            return false;
        }
    }
}
