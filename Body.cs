using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        private double dy;
        private double dx;

        public Body(double x, double y)
        {
            const double maxSpeed = 50.0;
            const double speed = 20.0;

            this.x = x;
            this.y = y;
            dy = (Random.Shared.NextDouble() * maxSpeed) - (maxSpeed/2);
            dx = (Random.Shared.NextDouble() * maxSpeed) - (maxSpeed/2);

            double length = Math.Sqrt((dx * dx + dy * dy));
            dy = (dy/length) * speed;
            dx = (dx/length) * speed;

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
            // Update position
            y += dy * deltaTime;

            x += dx * deltaTime;
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
