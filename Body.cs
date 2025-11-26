using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncing
{
    public class Body
    {
        private double x;
        private double y;
        private double width = 50;
        private double height = 50;
        private Pen pen;

        private double speed = 200.0;

        public Body(double x, double y)
        {
            this.x = x;
            this.y = y;
            pen = new Pen(Color.Black, 5);
        }

        public void Draw(Graphics g, double deltaTime)
        {
            Update(deltaTime);
            g.DrawEllipse(pen, (int)x, (int)y, (int)width, (int)height);
        }

        private void Update(double deltaTime)
        {
            y = y + this.speed * deltaTime;
        }
    }
}
