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
    public partial class GameMenu : Form
    {
        bool allowClick = false;
        PictureBox firstGuess;
        Random rnd = new Random();
        Timer clickTimer = new Timer();
        int time = 60;
        Timer timer = new Timer { Interval = 1000 };

        public GameMenu()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        //public PictureBox[] pictureBox => Controls.OfType<PictureBox>().ToArray();

        PictureBox[] pictureBoxes;

        int LEVEL=0;

        void first_level()
        {
            LEVEL = 1;
            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
        }
        void second_level()
        {
            LEVEL = 2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
        }
        void third_level()
        {
            LEVEL = 3;
            pictureBoxes[4] = pictureBox6;
            pictureBoxes[5] = pictureBox7;
        }
        void fourth_level()
        {
            LEVEL = 4;
            pictureBoxes[6] = pictureBox6;
            pictureBoxes[7] = pictureBox7;
        }
        void fifth_level() 
        {
            LEVEL = 5;
            pictureBoxes[8] = pictureBox6;
            pictureBoxes[9] = pictureBox7;
        }
        void sixth_level() 
        {
            LEVEL = 6;
            pictureBoxes[10] = pictureBox6;
            pictureBoxes[11] = pictureBox7;
        }
        void seventh_level()
        {
            LEVEL = 7;
            pictureBoxes[12] = pictureBox6;
            pictureBoxes[13] = pictureBox7;
        }
        void eighth_level()
        {
            LEVEL = 8;
            pictureBoxes[14] = pictureBox6;
            pictureBoxes[15] = pictureBox7;
        }
        
        void arrayInitialization()
        {
            if (checkBox1.Checked) {
                pictureBoxes = new PictureBox[2];
                first_level();
            }
            if (checkBox2.Checked)
            {
                pictureBoxes = new PictureBox[4];
                first_level();
                second_level();
            }
            if (checkBox3.Checked)
            {
                pictureBoxes = new PictureBox[6];
                first_level();
                second_level();
                third_level();
            }
            if (checkBox4.Checked)
            {
                pictureBoxes = new PictureBox[8];
                first_level();
                second_level();
                third_level();
                fourth_level();
            }
            if (checkBox5.Checked)
            {
                pictureBoxes = new PictureBox[10];
                first_level();
                second_level();
                third_level();
                fourth_level();
                fifth_level();
            }
            if (checkBox6.Checked)
            {
                pictureBoxes = new PictureBox[12];
                first_level();
                second_level();
                third_level();
                fourth_level();
                fifth_level();
                sixth_level();
            }
            if (checkBox7.Checked)
            {
                pictureBoxes = new PictureBox[14];
                first_level();
                second_level();
                third_level();
                fourth_level();
                fifth_level();
                sixth_level();
                seventh_level();
            }
            if (checkBox8.Checked)
            {
                pictureBoxes = new PictureBox[16];
                first_level();
                second_level();
                third_level();
                fourth_level();
                fifth_level();
                sixth_level();
                seventh_level();
                eighth_level();
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
                switch (LEVEL) 
                {
                    case 1: checkBox1.Checked = false;
                            checkBox2.Checked = true;
                        start();
                            break;
                    case 2:
                        checkBox2.Checked = false;
                        checkBox3.Checked = true;
                        start();
                        break;
                    case 3:
                        checkBox3.Checked = false;
                        checkBox4.Checked = true;
                        start();
                        break;
                    case 4:
                        checkBox4.Checked = false;
                        checkBox5.Checked = true;
                        start();
                        break;
                    case 5:
                        checkBox5.Checked = false;
                        checkBox6.Checked = true;
                        start();
                        break;
                    case 6:
                        checkBox6.Checked = false;
                        checkBox7.Checked = true;
                        start();
                        break;
                    case 7:
                        checkBox7.Checked = false;
                        checkBox8.Checked = true;
                        start();
                        break;
                    case 8:
                        start();
                        break;
                }
            }
            else {
                ResetImages();
                timer.Stop();
                label1.Text = $"00:60";
            }

        }

        private void startGame(object sender, EventArgs e)
        {
            start();
        }

        void start() 
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

        login login;
        private void войтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login = new login(this, button1);
            login.ShowDialog();
        }

        public void successfulLogin()
        {
            if (login.resultLoagin)
            {
                button1.Enabled = true;
            }
        }

        StatisticsForm statics;
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statics == null)
            {
                statics = new StatisticsForm();
                statics.FormClosed += (x, y) => { statics = null; }; //для избежания проблем с повторным открытием после закрытия
            }
            statics.Owner = this;
            statics.Show();
        }

        private void зарегистрироватьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login = new login(this, button1, "Регистрация");
            login.ShowDialog();
        }
    }
}