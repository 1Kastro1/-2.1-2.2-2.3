using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_2._1_2._2_2._3
{
    public partial class Form3 : Form
    {
        public Model1 db { get; set; }
        public Menu tr { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            iDTextBox.Text = tr.ID.ToString();
            nameTextBox.Text = tr.Name.ToString();
            priceTextBox.Text = tr.Price.ToString();
            vesTextBox.Text = tr.Ves.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tr.Name = nameTextBox.Text;
            tr.Ves = vesTextBox.Text;
            tr.Price = priceTextBox.Text;

            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
    }
}