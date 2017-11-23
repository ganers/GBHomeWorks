using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_1
{
    class GameObjectException:Exception
    {
        public GameObjectException()
        {
            System.Windows.Forms.MessageBox.Show("Собственное исключение GameObjectException");
        }
    }
}
