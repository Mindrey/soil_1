using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 센서값따로받기
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            label1.Text = "도깨비고비";
            label2.Text = "드라세나산데리아나";
        }


        private void 도깨비고비ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            도깨비고비 form = new 도깨비고비();
            form.Show();
        }

        private void 드라세나산데리아나ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            드라세나산데리아 form = new 드라세나산데리아();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
