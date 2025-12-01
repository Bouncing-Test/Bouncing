using System.Diagnostics;

namespace Bouncing
{
    public partial class Form1 : Form
    {
        private Font font = new Font("Arial", 20, FontStyle.Bold);
        private Brush brush = Brushes.Black;
        private Stopwatch stopwatch = Stopwatch.StartNew();
        private Body body = new Body(100, 100);

        private TimeSpan previousTime = TimeSpan.Zero;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var elapsed = stopwatch.Elapsed;
            var deltaTime = (elapsed - previousTime).TotalSeconds ;
            previousTime = elapsed;

           var speed = body.Draw(e.Graphics, deltaTime, ClientRectangle);
            e.Graphics.DrawString(speed.ToString() + "m/s", font, brush, new Point(50, 50));
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
