using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

        public login(Form form, Button button)
        {
            InitializeComponent();
            parentForm = form;
            buttonMF = button;

        }
        Form parentForm;

        public bool resultLoagin;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                String login = textBox1.Text;
                String password = textBox2.Text;

                bool start = parser.parsLoader(login, password);
                resultLoagin = start;
                if (start)
                {
                    //=======================================
                    Handler.closeLoginForm(login, parentForm);
                    buttonMF.Enabled = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error login/password", "error");
                }
            }
        }
    }
}
