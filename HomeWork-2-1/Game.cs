using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
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
        static Image bgImg;
        static Ship ship;
        static Aidkit[] aidKits;
        static Random rnd = new Random();
        private static Timer timer = new Timer();
        //static SoundPlayer bgMusic;

        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        // Свойства
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }
        static Game()
        {
        }
        /// <summary>
        /// Метод проверяет на соответствие требованиям размера формы
        /// </summary>
        /// <param name="width">Ширина формы</param>
        /// <param name="height">Высота формы</param>
        /// <returns></returns>
        static public bool VerifyFormSize(int width, int height)
        {
            if (width > 1000 || height > 1000 || width < 0 || height < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Метод инициализации игры
        /// </summary>
        /// <param name="form">Форма для игры</param>
        static public void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            // Создаём объект - поверхность рисования и связываем его с формой
            g = form.CreateGraphics();

            // Запоминаем размеры формы
            try
            {
                if (!VerifyFormSize(form.Width, form.Height))
                {
                    throw new GameObjectException();
                }
                else
                {
                    Width = form.Width;
                    Height = form.Height;
                }
            }
            catch (GameObjectException)
            {

                MessageBox.Show("Неправильно задан размер формы.\nРамзер будет задан по умолчанию 800x600.");
                Width = 800;
                Height = 600;
                form.Width = 800;
                form.Height = 600;
            }

            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            //Загружаем объекты игры
            Load();

            //Загружаем задний фон игры
            bgImg = Image.FromFile("space_bg.jpg");

            //Фоновый звук игры
            //bgMusic = new SoundPlayer("sounds/music.wav");
            //bgMusic.Play();

            //Таймер запуска отрисовки и обновления
            timer.Interval = 25;
            timer.Start();
            timer.Tick += Timer_Tick;

            //Обработка клика мыши по форме
            //form.MouseClick += Mouse_Click;

            form.KeyDown += Form_KeyDown;

            ship.MessageDie += Finish;

        }

        public static void Finish()
        {
            timer.Stop();
            buffer.Graphics.DrawString($"The END.", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            buffer.Render();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) bullet = new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
            if (e.KeyCode == Keys.Left) ship.Left();
            if (e.KeyCode == Keys.Right) ship.Right();
        }

        //private static void Mouse_Click(object sender, MouseEventArgs e)
        //{
        //    bullet.UpdateAfterMouseClick(e.X, e.Y);
        //}

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
            buffer.Graphics.DrawImage(bgImg, 0, 0, Width, Height);

            foreach (BaseObject obj in objs)
                obj.Draw();

            foreach (Aidkit obj in aidKits)
                obj?.Draw();

            foreach (Asteroid obj in asteroid)
                obj?.Draw();

            bullet?.Draw();
            ship?.Draw();
            if (ship != null)
                buffer.Graphics.DrawString($"Energy: {ship.Energy}\nPoints: {ship.Point}", SystemFonts.DefaultFont, Brushes.White, 0, 0);

            buffer.Render();
        }
        /// <summary>
        /// Метод обновляет информацию об объектах игры
        /// </summary>
        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();

            foreach (Aidkit obj in aidKits)
                obj?.Update();

            bullet?.Update();

            for (int i = 0; i < asteroid.Length; i++)
            {
                if (asteroid[i] == null) continue;
                asteroid[i].Update();

                if (bullet != null && bullet.Collision(asteroid[i]))
                {
                    SystemSounds.Hand.Play();
                    asteroid[i] = null;
                    bullet = null;
                    ship.Point++;
                    continue;
                }
                if (!ship.Collision(asteroid[i])) continue;
                ship?.EnergyLow(rnd.Next(1, 10));
                SystemSounds.Asterisk.Play();
                if (ship.Energy <= 0) ship?.Die();
            }

            for (int i = 0; i < aidKits.Length; i++)
            {
                if (aidKits[i] == null) continue;
                if (ship.Collision(aidKits[i]))
                {
                    ship.EnergyUp(rnd.Next(10, 50));
                    aidKits[i] = null;
                }
            }

            //bullet.Update();
        }
        /// <summary>
        /// Метод загружает все объекты игры
        /// </summary>
        static public void Load()
        {
            Random rand = new Random();
            ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
            objs = new BaseObject[60];
            asteroid = new Asteroid[10];
            aidKits = new Aidkit[3];


            for (int i = 0; i < objs.Length / 2; i++)
                objs[i] = new Star(new Point(rand.Next(Width), rand.Next(Height)), new Point(rand.Next(1, 3), 0), new Size(3, 3));

            for (int i = objs.Length / 2; i < objs.Length; i++)
                objs[i] = new Star(new Point(rand.Next(Width), rand.Next(Height)), new Point(rand.Next(2, 5), 0), new Size(5, 5));

            for (int i = 0; i < asteroid.Length; i++)
            {
                asteroid[i] = new Asteroid(new Point(rand.Next(Game.Width) + Game.Width, rand.Next(Game.Height)), new Point(rand.Next(1, 3), 0), new Size(rand.Next(15, 50), rand.Next(15, 50)));
            }

            for (int i = 0; i < aidKits.Length; i++)
                aidKits[i] = new Aidkit(new Point(rand.Next(Game.Width) + Game.Width, rand.Next(Game.Height)), new Point(rand.Next(1, 3), 0), new Size(15, 15));
        }
    }
}
