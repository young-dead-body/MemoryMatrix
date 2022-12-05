using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MemoryMatrix
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        Button buttonMF;

        public login(GameMenu form, Button button)
        {
            InitializeComponent();
            parentForm = form;
            buttonMF = button;
        }

        public login(GameMenu form, Button button, String nameForm)
        {
            InitializeComponent();
            parentForm = form;
            buttonMF = button;
            this.Text = nameForm;
            this.label1.Text = "Введите ваше имя";
            this.label2.Text = "Придумайте пароль";
        }

        GameMenu parentForm;

        public bool resultLoagin;

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String pass = textBox2.Text;
            var re = new Regex(@"[\[\]+\\':;@#№$%|!^?&*()/_={}.,<>]+");
            name = re.Replace(name, "");
            pass = re.Replace(pass, "");

            if (name != "" && pass != "")
            {
                String login = textBox1.Text;
                String password = textBox2.Text;

                if (this.Text == "Вход")
                {
                    bool start = parser.parsLoader(login, password);
                    resultLoagin = start;
                    if (start)
                    {
                        //=======================================
                        Handler.closeLoginForm(login, parentForm);
                        buttonMF.Enabled = true;
                        parentForm.postLoad();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error login/password", "error");
                    }
                }
                else 
                {
                    bool start = parser.parsRegistrationLoader(login, password);
                    resultLoagin = start;
                    if (start)
                    {
                        //=======================================
                        Handler.closeLoginForm(login, parentForm);
                        buttonMF.Enabled = true;
                        Close();
                        parser.parsRegistrationStatistics(login);
                    }
                    else
                    {
                        MessageBox.Show("Error login/password", "error");
                    }
                }
            }
            else {
                MessageBox.Show("Упс..Наверное вы забыли внести данные", "Ошибка ввода");
            }
        }
    }
}
