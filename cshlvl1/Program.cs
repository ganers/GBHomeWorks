using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cshlvl1
{
    class User
    {
        //public static FName {get;set};

    static List<User> LoadXml(string path)
    {
        string dataXml = System.IO.File.ReadAllText(path);

        var tempCol = XDocument.Parse(dataXml).Descendants("Dep");

        foreach (var item in tempCol)
        {
            Console.WriteLine(item);
        }
        return null;
    }

    class Program
    {
        static void Main(string[] args)
        {
            CreateXML();
        }

        static void CreateXML()
        {
            XElement _dep = new XElement("Dep");

            for (int i = 0; i < 10; i++)
            {
                XElement _user = new XElement("User");
                XElement _fname = new XElement("FirestName");
                _fname.Value = $"Имя {i}";
                XElement _lname = new XElement("LasName");
                _lname.Value = $"Фамилия {i}";
                XAttribute _id = new XAttribute("Id", i);

                _user.Add(_fname, _lname, _id);
                _dep.Add(_user);
            }

            _dep.Save("db.xml");

        }
    }
}
