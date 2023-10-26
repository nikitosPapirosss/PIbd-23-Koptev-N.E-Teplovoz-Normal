using System.Windows.Forms;

namespace WarmlyLocomotive
{
    public partial class WarmlyLocomotive : Form
    {
        private DrawningTeplovoz? _drawningTeplovoz;
        public WarmlyLocomotive()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Draw()
        {
            if (_drawningTeplovoz == null)
            {
                return;
            }
            Bitmap bmp = new(pictureBoxTeplovoz.Width, pictureBoxTeplovoz.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _drawningTeplovoz.DrawTransport(gr);
            pictureBoxTeplovoz.Image = bmp;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random random = new();
            _drawningTeplovoz = new DrawningTeplovoz();
            _drawningTeplovoz.Init(random.Next(100, 300),
            random.Next(1000, 3000),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            pictureBoxTeplovoz.Width, pictureBoxTeplovoz.Height);
            _drawningTeplovoz.SetPosition(random.Next(10, 100),
            random.Next(10, 100));
            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (_drawningTeplovoz == null)
            {
                return;
            }
            string name = ((Button)sender)?.Name ?? string.Empty;
            switch (name)
            {
                case "buttonUp":
                    _drawningTeplovoz.MoveTransport(DirectionType.Up);
                    break;
                case "buttonDown":
                    _drawningTeplovoz.MoveTransport(DirectionType.Down);
                    break;
                case "buttonLeft":
                    _drawningTeplovoz.MoveTransport(DirectionType.Left);
                    break;
                case "buttonRight":
                    _drawningTeplovoz.MoveTransport(DirectionType.Right);
                    break;
            }
            Draw();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Class1 step = new Class1();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxTeplovoz_Click(object sender, EventArgs e)
        {

        }
    }
}
