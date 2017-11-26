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
        private int _energy = 100;
        public int Energy => _energy;
        public int Point { get; set; }

        public event Message MessageDie;

        public void EnergyLow(int n)
        {
            _energy -= n;
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
