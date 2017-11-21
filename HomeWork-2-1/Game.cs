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
        static BaseObject[] objs;
        static Asteroid[] asteroid;
        static Bullet bullet;

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
        /// <summary>
        /// Метод рисует все объекты на форме
        /// </summary>
        static public void Draw()
        {
            //Рисуем задний фон
            Image bgImg = Image.FromFile("space_bg.jpg");
            buffer.Graphics.DrawImage(bgImg, 0,0, Width, Height);

            foreach (BaseObject obj in objs)
                obj.Draw();

            foreach (Asteroid obj in asteroid)
                obj.Draw();

            bullet.Draw();

            buffer.Render();

        }
        /// <summary>
        /// Метод обновляет информацию об объектах игры
        /// </summary>
        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();

            foreach (Asteroid obj in asteroid)
                obj.Update();

            bullet.Update();
        }
        /// <summary>
        /// Метод загружает ............................................ ???
        /// </summary>
        static public void Load()
        {
            Random rand = new Random();
            objs = new BaseObject[30];
            bullet = new Bullet(new Point(0,200), new Point(5,0), new Size(4,1));
            asteroid = new Asteroid[10];


            for (int i = 0; i < objs.Length / 2; i++)
                objs[i] = new Star(new Point(rand.Next(Width), rand.Next(Height)), new Point(rand.Next(1, 10), 0), new Size(3, 3));

            for (int i = objs.Length / 2; i < objs.Length; i++)
                objs[i] = new Star(new Point(rand.Next(Width), rand.Next(Height)), new Point(rand.Next(10, 20), 0), new Size(5, 5));

            for (int i = 0; i < asteroid.Length; i++)
            {
                asteroid[i] = new Asteroid(new Point(rand.Next(Game.Width) + Game.Width, rand.Next(Game.Height)), new Point(rand.Next(5, 15), rand.Next(-2, 2)), new Size(rand.Next(5, 50), rand.Next(5, 50)));
            }
        }
    }
}
