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
        //Флаги нажатия клавиш
        static bool keyUpFlag = true;
        static bool keyDownFlag = true;
        static bool keyLeftFlag = true;
        static bool keyRightFlag = true;
        static bool pausedFlag = false;

        //Параметры игры
        static int aidKitsCount = 2;
        static int asteroidCount = 10;
        static int asteroidInGame;
        static int bulletMax = 10;
        static int gameWave = 1;
        static int paddingRight = 200;  //отступ от правой границы для текста с подсказками
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }

        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static BaseObject[] objs;
        static List<Asteroid> asteroid;
        static List<Bullet> bullet;
        static Image bgImg;
        static Ship ship;
        static List<Aidkit> aidKits;
        //static SoundPlayer bgMusic;

        //Вспомогательные переменные
        static Random rnd = new Random();
        private static Timer timer = new Timer();

        
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
            if (width > 1000 || height > 1000 || width < 0 || height < 0) return false; else return true;
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
            bgImg = Image.FromFile("pictures/space_bg.jpg");

            //Фоновый звук игры
            //bgMusic = new SoundPlayer("sounds/music.wav");
            //bgMusic.Play();

            //Таймер запуска отрисовки и обновления
            timer.Interval = 25;
            timer.Start();
            timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;

            form.KeyUp += Form_KeyUp;

            ship.MessageDie += Finish;

        }
        /// <summary>
        /// Метод ставит на паузу или снимает с паузы игру
        /// </summary>
        /// <param name="pausedFlag">Если true ставим на паузу, иначе снимаем</param>
        public static void Paused(bool pausedFlag)
        {
            if (pausedFlag)
            {
                timer.Stop();
                buffer.Graphics.DrawString($"PAUSED.", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
                buffer.Render();
            }
            else
            {
                timer.Start();
            }
            
        }
        /// <summary>
        /// Метод завершает игру
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            buffer.Graphics.DrawString($"The END.", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            buffer.Render();
        }
        /// <summary>
        /// Метод обработки события нажатия клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && bullet.Count < bulletMax) bullet.Add(new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1)));
            if (e.KeyCode == Keys.Up) keyUpFlag = false;
            if (e.KeyCode == Keys.Down) keyDownFlag = false;
            if (e.KeyCode == Keys.Left) keyLeftFlag = false;
            if (e.KeyCode == Keys.Right) keyRightFlag = false;
            if (e.KeyCode == Keys.Escape) Application.Exit();
            if (e.KeyCode == Keys.P)
            {
                if (!pausedFlag)
                {
                    pausedFlag = true;
                    Paused(pausedFlag);
                }
                else
                {
                    pausedFlag = false;
                    Paused(pausedFlag);
                }
            }
        }
        /// <summary>
        /// Метод обработки события отпускания клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) keyUpFlag = true;
            if (e.KeyCode == Keys.Down) keyDownFlag = true;
            if (e.KeyCode == Keys.Left) keyLeftFlag = true;
            if (e.KeyCode == Keys.Right) keyRightFlag = true;
        }
        /// <summary>
        /// Метод обработки таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            foreach (Bullet obj in bullet)
                obj?.Draw();

            ship?.Draw();
            if (ship != null)
                buffer.Graphics.DrawString($"Energy: {ship.Energy}\nPoints: {ship.Point}\nAsteroid: {asteroidInGame}\nWave: {gameWave}", SystemFonts.DefaultFont, Brushes.White, 0, 0);

            buffer.Graphics.DrawString($"Пауза: \"P\".\nВыход из игры: \"ESC\".", SystemFonts.DefaultFont, Brushes.White, Game.Width-paddingRight, 0);

            buffer.Render();
        }
        /// <summary>
        /// Метод обновляет информацию об объектах игры
        /// </summary>
        static public void Update()
        {
            bool currentAsteroid;

            foreach (BaseObject obj in objs)
                obj.Update();

            foreach (Aidkit obj in aidKits)
                obj?.Update();

            for (int i = 0; i < bullet.Count; i++)
            {
                if (bullet[i].InField()) bullet[i].Update(); else bullet.RemoveAt(i);
            }

            if (asteroid.Count != 0)
            {
                currentAsteroid = true;

                for (int i = 0; i < asteroid.Count; i++)
                {
                    asteroid[i].Update();

                    for (int j = 0; j < bullet.Count; j++)
                    {
                        if (bullet[j].Collision(asteroid[i]))
                        {
                            currentAsteroid = false;
                            SystemSounds.Hand.Play();
                            ship.Point += gameWave * asteroid[i].ScoreForDestruction;
                            asteroidInGame--;
                            asteroid.RemoveAt(i);
                            bullet.RemoveAt(j);
                            break;
                        }
                    }

                    if (currentAsteroid)
                    {
                        if (ship.Collision(asteroid[i]))
                        {
                            ship?.EnergyLow(rnd.Next(1, 10));
                            SystemSounds.Asterisk.Play();
                            if (ship.Energy <= 0) ship?.Die();
                        }
                    }
                }
            }
            else
            {
                gameWave++;
                asteroidCount++;
                asteroidInGame = asteroidCount;
                for (int i = 0; i < asteroidCount; i++)
                {
                    asteroid.Add(new Asteroid(new Point(rnd.Next(Game.Width) + Game.Width, rnd.Next(100, Game.Height - 100)), new Point(gameWave, 0), new Size(rnd.Next(25, 75), rnd.Next(25, 75))));
                }
            }

            for (int i = 0; i < aidKits.Count; i++)
            {
                if (ship.Collision(aidKits[i]))
                {
                    ship.EnergyUp(rnd.Next(10, 50));
                    aidKits[i] = new Aidkit(new Point(rnd.Next(Game.Width) + Game.Width, rnd.Next(Game.Height)), new Point(rnd.Next(1, 3), 0), new Size(15, 15));
                }
            }

            if (!keyUpFlag) ship.Up();
            if (!keyDownFlag) ship.Down();
            if (!keyLeftFlag) ship.Left();
            if (!keyRightFlag) ship.Right();
        }
        /// <summary>
        /// Метод загружает все объекты игры
        /// </summary>
        static public void Load()
        {
            asteroid = new List<Asteroid>();
            ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(40, 20));
            objs = new BaseObject[60];
            aidKits = new List<Aidkit>();
            bullet = new List<Bullet>();
            asteroidInGame = asteroidCount;


            for (int i = 0; i < objs.Length / 2; i++)
                objs[i] = new Star(new Point(rnd.Next(Width), rnd.Next(Height)), new Point(rnd.Next(1, 3), 0), new Size(3, 3));

            for (int i = objs.Length / 2; i < objs.Length; i++)
                objs[i] = new Star(new Point(rnd.Next(Width), rnd.Next(Height)), new Point(rnd.Next(2, 5), 0), new Size(5, 5));

            for (int i = 0; i < asteroidCount; i++)
            {
                asteroid.Add(new Asteroid(new Point(rnd.Next(Game.Width) + Game.Width, rnd.Next(100, Game.Height - 100)), new Point(rnd.Next(1, 3), 0), new Size(rnd.Next(25, 75), rnd.Next(25, 75))));
            }

            for (int i = 0; i < aidKitsCount; i++)
                aidKits.Add(new Aidkit(new Point(rnd.Next(Game.Width) + Game.Width, rnd.Next(Game.Height)), new Point(rnd.Next(1, 3), 0), new Size(15, 15)));
        }
    }
}
