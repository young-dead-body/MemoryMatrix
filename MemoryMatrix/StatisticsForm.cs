using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MemoryMatrix
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            List<Statistics> statistic = parser.parsStatistic();
            dataGridView1.Columns.AddRange(
                new DataGridViewTextBoxColumn() { Name = "login", HeaderText = "Игрок", DataPropertyName = "login" },
                new DataGridViewTextBoxColumn() { Name = "maxtime", HeaderText = "Максимальное время", DataPropertyName = "maxtime" },
                new DataGridViewTextBoxColumn() { Name = "mintime", HeaderText = "Рекорд", DataPropertyName = "mintime" },
                new DataGridViewTextBoxColumn() { Name = "totalgames", HeaderText = "Всего игр", DataPropertyName = "totalgames" },
                new DataGridViewTextBoxColumn() { Name = "level", HeaderText = "Уровень", DataPropertyName = "level" }
            );
           
            foreach (var st in statistic)
            {
                dataGridView1.Rows.Add();                
            }

            int i = 0;
            foreach (var st in statistic) 
            {
                dataGridView1.Rows[i].Cells["login"].Value = st.login;
                dataGridView1.Rows[i].Cells["maxtime"].Value = st.maxtime;
                dataGridView1.Rows[i].Cells["mintime"].Value = st.mintime;
                dataGridView1.Rows[i].Cells["totalgames"].Value = st.totalgames;
                dataGridView1.Rows[i].Cells["level"].Value = st.level;
               
                i++;
            }
        }
    }
}
