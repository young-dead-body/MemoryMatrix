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
            checkBoxesInitsialization();
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
            pictureBoxes[4] = pictureBox5;
            pictureBoxes[5] = pictureBox6;
        }
        void fourth_level()
        {
            LEVEL = 4;
            pictureBoxes[6] = pictureBox7;
            pictureBoxes[7] = pictureBox8;
        }
        void fifth_level() 
        {
            LEVEL = 5;
            pictureBoxes[8] = pictureBox9;
            pictureBoxes[9] = pictureBox10;
        }
        void sixth_level() 
        {
            LEVEL = 6;
            pictureBoxes[10] = pictureBox11;
            pictureBoxes[11] = pictureBox12;
        }
        void seventh_level()
        {
            LEVEL = 7;
            pictureBoxes[12] = pictureBox13;
            pictureBoxes[13] = pictureBox14;
        }
        void eighth_level()
        {
            LEVEL = 8;
            pictureBoxes[14] = pictureBox15;
            pictureBoxes[15] = pictureBox16;
        }

        bool check = false;
        bool arrayInitialization()
        {
            if (checkBox1.Checked) {
                pictureBoxes = new PictureBox[2];
                first_level();
                check = true;
            }
            if (checkBox2.Checked)
            {
                pictureBoxes = new PictureBox[4];
                first_level();
                second_level();
                check = true;
            }
            if (checkBox3.Checked)
            {
                pictureBoxes = new PictureBox[6];
                first_level();
                second_level();
                third_level();
                check = true;
            }
            if (checkBox4.Checked)
            {
                pictureBoxes = new PictureBox[8];
                first_level();
                second_level();
                third_level();
                fourth_level();
                check = true;
            }
            if (checkBox5.Checked)
            {
                pictureBoxes = new PictureBox[10];
                first_level();
                second_level();
                third_level();
                fourth_level();
                fifth_level();
                check = true;
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
                check = true;
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
                check = true;
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
                check = true;
            }
            if (check == false)
            {
                return check;
            }

            for (int i = 0; i < pictureBoxes.Length; i++) 
            {
                pictureBoxes[i].Tag = null;
                pictureBoxes[i].Image = null;
            }
            return check;
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


        int checkTime = 0;
        private void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();

                    MessageBox.Show("Время вышло...",
                                "Сообщение");
                    time = 60;
                    label1.Text = "00:60";
                    for (int i = 0; i < pictureBoxes.Length; i++)
                    {
                        pictureBoxes[i].Tag = null;
                        pictureBoxes[i].Image = null;
                    }
                    button1.Enabled = true;
                    updateLevel();
                }

                var ssTime = TimeSpan.FromSeconds(time);

                var security = resources.question;
                if (checkTime <= 5)
                {
                    if (checkTime == 0) 
                    {
                        
                        foreach (var pic in pictureBoxes)
                        {
                            pic.Image = (Image)pic.Tag;
                        }
                    }
                    label1.Text = $"00:{5 - checkTime}";
                    checkTime++;
                    time = 60;
                    if (checkTime == 5) 
                    {
                        foreach (var pic in pictureBoxes)
                        {
                            pic.Image = security;
                        }
                    }
                }
                else 
                {
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
                }
               
            };
        }

        CheckBox[] checkBoxes;

        void checkBoxesInitsialization() 
        {
            checkBoxes = new CheckBox[8];
            checkBoxes[0] = checkBox1;
            checkBoxes[1] = checkBox2;
            checkBoxes[2] = checkBox3;
            checkBoxes[3] = checkBox4;
            checkBoxes[4] = checkBox5;
            checkBoxes[5] = checkBox6;
            checkBoxes[6] = checkBox7;
            checkBoxes[7] = checkBox8;
        }

        void checkBoxesUpdate() 
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }
        private void checkLevel() //проверка на каком уровне был пользователь
        {

            int level = parser.parsGettingValue("level", userName());

            var result = MessageBox.Show($"{userName()}, выхотели бы продолжить с {level} уровня?","Сообщение",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                switch (level)
                {
                    case 1:
                        checkBoxesUpdate();
                        checkBox1.Checked = true;
                        break;
                    case 2:
                        checkBoxesUpdate();
                        checkBox2.Checked = true;
                        break;
                    case 3:
                        checkBoxesUpdate();
                        checkBox3.Checked = true;
                        break;
                    case 4:
                        checkBoxesUpdate();
                        checkBox4.Checked = true;
                        break;
                    case 5:
                        checkBoxesUpdate();
                        checkBox5.Checked = true;
                        break;
                    case 6:
                        checkBoxesUpdate();
                        checkBox6.Checked = true;
                        break;
                    case 7:
                        checkBoxesUpdate();
                        checkBox7.Checked = true;
                        break;
                    case 8:
                        checkBoxesUpdate();
                        checkBox8.Checked = true;
                        break;
                }
            }  
        }

        public void postLoad() 
        {
            checkBoxesInitsialization();
            checkLevel();
        }

        private void updateLevel() 
        {
            switch (LEVEL) 
            {
                case 1:
                    checkBox2.Checked = false;
                    checkBox1.Checked = true;
                    break;
                case 2:
                    checkBox3.Checked = false;
                    checkBox2.Checked = true;
                    break;
                case 3:
                    checkBox4.Checked = false;
                    checkBox3.Checked = true;
                    break;
                case 4:
                    checkBox5.Checked = false;
                    checkBox4.Checked = true;
                    break;
                case 5:
                    checkBox6.Checked = false;
                    checkBox5.Checked = true;
                    break;
                case 6:
                    checkBox7.Checked = false;
                    checkBox6.Checked = true;
                    break;
                case 7:
                    checkBox8.Checked = false;
                    checkBox7.Checked = true;
                    break;
            }
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
                switch (LEVEL) 
                {
                    case 1:
                        checkBox1.Checked = false;
                            checkBox2.Checked = true;
                            start();
                            break;
                    case 2:
                        if (parser.parsGettingValue("level", userName()) < LEVEL)
                        {
                            parser.parsChangeValue("level", userName(), LEVEL);
                        }
                        checkBox2.Checked = false;
                        checkBox3.Checked = true;
                        start();
                        break;
                    case 3:
                        if (parser.parsGettingValue("level", userName()) < LEVEL)
                        {
                            parser.parsChangeValue("level", userName(), LEVEL);
                        }
                        checkBox3.Checked = false;
                        checkBox4.Checked = true;
                        start();
                        break;
                    case 4:
                        if (parser.parsGettingValue("level", userName()) < LEVEL)
                        {
                            parser.parsChangeValue("level", userName(), LEVEL);
                        }
                        checkBox4.Checked = false;
                        checkBox5.Checked = true;
                        start();
                        break;
                    case 5:
                        if (parser.parsGettingValue("level", userName()) < LEVEL)
                        {
                            parser.parsChangeValue("level", userName(), LEVEL);
                        }
                        checkBox5.Checked = false;
                        checkBox6.Checked = true;
                        start();
                        break;
                    case 6:
                        if (parser.parsGettingValue("level", userName()) < LEVEL)
                        {
                            parser.parsChangeValue("level", userName(), LEVEL);
                        }
                        checkBox6.Checked = false;
                        checkBox7.Checked = true;
                        start();
                        break;
                    case 7:
                        if (parser.parsGettingValue("level", userName()) < LEVEL)
                        {
                            parser.parsChangeValue("level", userName(), LEVEL);
                        }
                        checkBox7.Checked = false;
                        checkBox8.Checked = true;
                        start();
                        break;
                    case 8:
                        int seconds = time;
                        if (parser.parsGettingValue("mintime", userName()) > 60 - seconds)
                        {
                            parser.parsChangeValue("mintime", userName(), 60 - seconds);
                        }
                        if (parser.parsGettingValue("maxtime", userName()) < seconds)
                        {
                            parser.parsChangeValue("maxtime", userName(), seconds);
                        }
                        if (parser.parsGettingValue("level", userName()) < LEVEL)
                        {
                            parser.parsChangeValue("level", userName(), LEVEL);
                        }
                        start();
                        break;
                }
                ResetImages();
            }
            else {
                if (LEVEL == 8) 
                {
                    int seconds = time;
                    if (parser.parsGettingValue("mintime", userName()) > 60 - seconds)
                    {
                        parser.parsChangeValue("mintime", userName(), 60 - seconds);
                    }
                    if(parser.parsGettingValue("maxtime", userName()) < seconds)
                    {
                        parser.parsChangeValue("maxtime", userName(), seconds);
                    }
                }
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
            if (arrayInitialization())
            {
                checkTime = 0;
                setRandomImages();
                //HideImages();
                startGameTimer();
                clickTimer.Interval = 1000;
                clickTimer.Tick += CKLICKTIMER_TICK;
                button1.Enabled = false;
                parser.parsChangeValue("totalgames", $"{userName()}");
            }
            else 
            {
                MessageBox.Show("Выберите уровень");
            }
            
            
        }

        private string userName() 
        {
            string name = "";
            int firstPos = parser.parsPos('[', this.Text);
            int secondPos = parser.parsPos(']', this.Text);
            for (int i = firstPos+1; i < secondPos; i++) 
            {
                name += this.Text[i];
            }
            return name;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            //checkBoxesUpdate();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            //checkBoxesUpdate();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            //checkBoxesUpdate();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            //checkBoxesUpdate();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            //checkBoxesUpdate();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            //checkBoxesUpdate();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox8.Checked = false;
            //checkBoxesUpdate();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            //checkBoxesUpdate();
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

        private void информацияОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данное программное приложение было разработано студентом группы 18ВО1 Савиным Дмитрием", "Информация о программе");
        }

        int START = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            START++;
        }
    }
}