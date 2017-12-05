using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_2_6
{
    public struct TypeDataBase
    {
        static public int FileSystem
        {
            get { return 0; }
        }
        static public int MySQL
        {
            get { return 1; }
        }
        static public int MSSQL
        {
            get { return 2; }
        }
        static public int PostgreSQL
        {
            get { return 3; }
        }
    }

    public class DataBase
    {
        int typeDB;
        string nameDB;

        public DataBase(int typeDB, string nameDB)
        {
            this.typeDB = typeDB;
            this.nameDB = nameDB;
        }


        public Dictionary<string, string[]> ReadDataBase()
        {
            Dictionary<string, string[]> db = new Dictionary<string, string[]>();

            if (this.typeDB == TypeDataBase.FileSystem)
                db = ReadFileSystem(this.nameDB);
            else if (this.typeDB == TypeDataBase.MySQL)
                db = ReadMySQL();

            return db;
        }

        Dictionary<string, string[]> ReadFileSystem(string path)
        {

            return File.ReadAllLines()
        }

        string[] ReadMySQL()
        {
            string[] db = new string[1];
            return db;
        }
    }
}
