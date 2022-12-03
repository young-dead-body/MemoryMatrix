using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryMatrix
{
    public partial class Form1 : Form
    {
        bool allowClick = false;
        PictureBox firstGuess;
        Random rnd = new Random();
        Timer clickTimer = new Timer();
        int time = 60;
        Timer timer = new Timer { Interval = 1000 };

        public Form1()
        {
            InitializeComponent();
        }

        //public PictureBox[] pictureBox => Controls.OfType<PictureBox>().ToArray();

        PictureBox[] pictureBoxes;

        void arrayInitialization()
        {
            if (checkBox1.Checked) {
                pictureBoxes = new PictureBox[4];
                pictureBoxes[0] = pictureBox1;
                pictureBoxes[1] = pictureBox2;
                pictureBoxes[2] = pictureBox3;
                pictureBoxes[3] = pictureBox4;
            }
            if (checkBox2.Checked)
            {
                pictureBoxes = new PictureBox[16];
                pictureBoxes[0] = pictureBox1;
                pictureBoxes[1] = pictureBox2;
                pictureBoxes[2] = pictureBox3;
                pictureBoxes[3] = pictureBox4;
                pictureBoxes[4] = pictureBox5;
                pictureBoxes[5] = pictureBox6;
                pictureBoxes[6] = pictureBox7;
                pictureBoxes[7] = pictureBox8;
                pictureBoxes[8] = pictureBox9;
                pictureBoxes[9] = pictureBox10;
                pictureBoxes[10] = pictureBox11;
                pictureBoxes[11] = pictureBox12;
                pictureBoxes[12] = pictureBox13;
                pictureBoxes[13] = pictureBox14;
                pictureBoxes[14] = pictureBox15;
                pictureBoxes[15] = pictureBox16;
            }
            for (int i = 0; i < pictureBoxes.Length; i++) 
            {
                pictureBoxes[i].Tag = null;
            }
        }

        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[] {
                    resources.img1,
                    resources.img2,
                    resources.img3,
                    resources.img4,
                    resources.img5,
                    resources.img6,
                    resources.img7,
                    resources.img8
                };
            }
        }

        private void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    MessageBox.Show("Время вышло...");
                    ResetImages();
                }

                var ssTime = TimeSpan.FromSeconds(time);

                int seconds = time;
                if (seconds > 15)
                {
                    label1.ForeColor = Color.Black;
                }
                else
                {
                    label1.ForeColor = Color.Red;
                }
                label1.Text = $"00:{seconds}";
            };
        }

        private void ResetImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }

            HideImages();
            setRandomImages();
            time = 60;
            timer.Start();
            button1.Enabled = true;
        }

        private void HideImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Image = resources.question;
            }
        }

        private PictureBox getFreeSlot()
        {
            int num;

            do
            {
                num = rnd.Next(0, pictureBoxes.Count());
            } while (pictureBoxes[num].Tag != null); // ПОЧЕМУ ТУТ ОШИБКА
            return pictureBoxes[num];
        }

        private void setRandomImages()
        {
            int i = 0;
            foreach (var image in images)
            {
                getFreeSlot().Tag = image;
                i++;
                getFreeSlot().Tag = image;
                i++;
                if (i == pictureBoxes.Length) { return; }
            }
        }


        private void CKLICKTIMER_TICK(object sender, EventArgs e) // хз пока что
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }

        private void clickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;

            var pic = (PictureBox)sender;

            if (firstGuess == null)
            {
                firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }

            pic.Image = (Image)pic.Tag;

            if (pic.Image == firstGuess.Image && pic != firstGuess)
            {
                pic.Visible = firstGuess.Visible = false;
                {
                    firstGuess = pic;
                }
                HideImages();
            }
            else
            {
                allowClick = false;
                clickTimer.Start();
            }

            firstGuess = null;
            if (pictureBoxes.Any(p => p.Visible)) return;

            DialogResult result = MessageBox.Show(
            "Вы выиграли. Хотите продолжить?",
            "Сообщение",
            MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                timer.Stop();
                ResetImages();
            }
            else {
                ResetImages();
                timer.Stop();
                label1.Text = $"00:60";
            }

        }

        private void startGame(object sender, EventArgs e)
        {
            allowClick = true;
            arrayInitialization();
            setRandomImages();
            HideImages();
            startGameTimer();
            clickTimer.Interval = 1000;
            clickTimer.Tick += CKLICKTIMER_TICK;
            button1.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}