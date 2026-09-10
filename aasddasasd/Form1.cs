using System.Diagnostics;
using System.Media;

namespace aasddasasd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PripravTlacitko();
        }

        private void PripravTlacitko()
        {
            this.BackColor = Color.FromArgb(20, 20, 20);

            button1.Text = "▶ YOUTUBE";
            button1.BackColor = Color.Red;
            button1.ForeColor = Color.White;
            button1.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Size = new Size(200, 60);

            button1.MouseEnter += (s, e) => {
                button1.BackColor = Color.DarkRed;
                button1.Size = new Size(210, 65);
            };

            button1.MouseLeave += (s, e) => {
                button1.BackColor = Color.Red;
                button1.Size = new Size(200, 60);
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Zvukový efekt
            SystemSounds.Exclamation.Play();

            // Záblesk a text BOOM
            this.BackColor = Color.White;
            button1.Text = "💥 BOOM! 💥";
            button1.BackColor = Color.OrangeRed;
            await Task.Delay(100);

            // Třesení oknem
            Point povodniPozice = this.Location;
            Random rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                this.Location = new Point(
                    povodniPozice.X + rand.Next(-12, 12),
                    povodniPozice.Y + rand.Next(-12, 12)
                );
                await Task.Delay(25);
            }

            // Vrácení do původního stavu
            this.Location = povodniPozice;
            this.BackColor = Color.FromArgb(20, 20, 20);
            button1.Text = "OTEVÍRÁM...";

            await Task.Delay(300);

            // Otevření YouTube
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.youtube.com",
                UseShellExecute = true
            });

            button1.Text = "▶ YOUTUBE";
            button1.BackColor = Color.Red;
        }
    }
}