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
    public partial class Form2 : Form
    {
        public Model1 db { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vesTextBox.Text == "" || iDTextBox.Text == "" || nameTextBox.Text == "" || vesTextBox.Text == "")
            {
                MessageBox.Show("Введите данные!");
                return;
            }
            int id;
            bool b = int.TryParse(iDTextBox.Text, out id);
            if (b == false)
            {
                MessageBox.Show("Неверный формат id - " + iDTextBox.Text);
                return;
            }
            Menu tr = new Menu();
            tr.ID = id;
            tr.Name = nameTextBox.Text;
            tr.Ves = vesTextBox.Text;
            tr.Price = priceTextBox.Text;
            db.Menu.Add(tr);
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
