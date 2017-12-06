using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_5
{
    class HandBook
    {
    }
    /// <summary>
    /// Справочник типов используемых СУБД
    /// </summary>
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
}
