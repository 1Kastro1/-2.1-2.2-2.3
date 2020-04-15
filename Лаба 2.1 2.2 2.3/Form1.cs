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
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        public Form1()
       
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuBindingSource.DataSource = db.Menu.ToList();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.db = db;
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                menuBindingSource.DataSource = db.Menu.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            Menu tr = (Menu)menuBindingSource.Current;
            frm.db = db;
            frm.tr = tr;
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                menuBindingSource.DataSource = db.Menu.ToList();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           Menu tr = (Menu)menuBindingSource.Current;

            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить - " + tr.ID.ToString() + "  " + tr.Name.ToString() + "  " + tr.Price.ToString() + "  " + tr.Ves.ToString(), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                db.Menu.Remove(tr);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            menuBindingSource.DataSource = db.Menu.ToList();
        }
    }
}
