using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
/*
 * Домашняя Работа АНДРЕЙ АЛЕКСЕЕВ
 * 
 * 
 * 
 * 
 *
 */
namespace HomeWork_2_1
{
    class Game
    {
        static public BaseObject[] objs;

        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        // Свойства
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }
        static Game()
        {
        }
        static public void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics(); // Создаём объект - поверхность рисования и связываем его с формой
                                       // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        static public void Draw()
        {
            // Проверяем вывод графики
            buffer.Graphics.Clear(Color.Black);
            //buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));

            foreach (BaseObject obj in objs)
            {
                obj.Draw();
                buffer.Render();
            }
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
            {
                obj.Update();
            }
        }

        //-------------------------------------------------------------------------------
        static public void Load()
        {
            Random rand = new Random();

            objs = new BaseObject[60];

            for (int i = 0; i < objs.Length / 6; i++)
                objs[i] = new BaseObject(new Point(rand.Next(600), rand.Next(30) * 20), new Point(-i, -i), new Size(10, 10));

            for (int i = objs.Length / 6; i < objs.Length; i++)
                objs[i] = new Star(new Point(rand.Next(600), rand.Next(30) * 20), new Point(-i, i), new Size(5, 5));

            //for (int i = objs.Length / 2; i < objs.Length; i++)
            //    objs[i] = new SpaceStars(new Point(rand.Next(600), rand.Next(30) * 20), new Point(-i, 0), new Size(5, 5));
        }
    }
}
