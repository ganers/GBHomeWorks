using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork_2_1
{
    class Ship : BaseObject
    {
        private int energy = 100;
        public int Energy => energy;
        public int Point { get; set; }

        public event Message MessageDie;

        public void EnergyLow(int n)
        {
            energy -= n;
        }

        public void EnergyUp(int n)
        {
            if (energy + n <= 100)
                energy += n;
            else
                energy = 100;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Point = 0;
        }

        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
        }

        public void Left()
        {
            if (pos.X > 0) pos.X = pos.X - dir.X;
        }

        public void Right()
        {
            if (pos.X < Game.Width) pos.X = pos.X + dir.X;
        }

        public void Up()
        {
            if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
        }

        public void Down()
        {
            if (pos.Y < Game.Height) pos.Y = pos.Y + dir.Y;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
