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

        // 1m = 100px
        private double gravity = 980.0;

        private double dy = 0.0;

        public Body(double x, double y)
        {
            this.x = x;
            this.y = y;
            pen = new Pen(Color.Black, 5);
        }

        public double Draw(Graphics g, double deltaTime, Rectangle client)
        {
            var speed = Update(deltaTime, client);
            g.DrawEllipse(pen, (int)x, (int)y, (int)width, (int)height);
            return speed;
        }

        private double Update(double deltaTime, Rectangle client)
        {
            // Apply acceleration (gravity)
            dy += gravity * deltaTime;

            // Update position
            y += dy * deltaTime;

            // Bounce
            if (y + height >= client.Height)
            {
                y = client.Height - height;
                dy = dy * -0.9;
            }
            // dy to m/s to 1dp
            return Math.Round(dy / 100, 1);
        }
    }
}
