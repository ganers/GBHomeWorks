using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_2_5
{
    class DataBase
    {
        public DataBase()
        {
        }
        /// <summary>
        /// Метод считывает данные из файла
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static public string[] ReadDb(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
        /// <summary>
        /// Метод записывает данные в файл
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="db"></param>
        static public void WriteDb(string filePath, string[] db)
        {
            File.WriteAllLines(filePath, db);
        }
    }
}
