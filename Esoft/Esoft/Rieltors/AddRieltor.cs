using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Esoft.Rieltors
{
    public partial class AddRieltor : Form
    {
        RieltorsComponent rieltorComponent;
        RieltorsForm parent;
        public AddRieltor(RieltorsForm parentForm)
        {
            InitializeComponent();
            rieltorComponent = new RieltorsComponent();
            parent = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rieltor addRieltor = new Rieltor();
            if (textBox2.Text.Length > 1 && textBox3.Text.Length > 1 && textBox4.Text.Length > 1)
            {
                addRieltor.lastName = textBox2.Text;
                addRieltor.firstName = textBox3.Text;
                addRieltor.middleName = textBox4.Text;
                addRieltor.comission = int.Parse(numericUpDown1.Value.ToString());
                try
                {
                    rieltorComponent.PostClient(addRieltor);
                    MessageBox.Show("Риэлтор добавлен!");
                    parent.UpdateDataGrid();
                }
                catch(Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("ФИО должны быть указаны");
                return;
            }
        }
    }
}
