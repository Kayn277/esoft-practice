using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Esoft.Rieltors
{
    public partial class UpdateRieltor : Form
    {
        RieltorsComponent rieltorComponent;
        RieltorsForm parent;
        Rieltor updateRieltor;
        int indx = 0;
        public UpdateRieltor(Rieltor rieltor, RieltorsForm parent)
        {
            InitializeComponent();
            rieltorComponent = new RieltorsComponent();
            this.parent = parent;
            updateRieltor = rieltor;
            textBox1.Text = rieltor.lastName;
            textBox2.Text = rieltor.firstName;
            textBox3.Text = rieltor.middleName;
            numericUpDown1.Value = rieltor.comission;
            indx = rieltor.id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rieltor updRieltor = new Rieltor();
            if (textBox1.Text.Length > 1 && textBox2.Text.Length > 1 && textBox3.Text.Length > 1)
            {
                updRieltor.lastName = textBox1.Text;
                updRieltor.firstName = textBox2.Text;
                updRieltor.middleName = textBox3.Text;
                updRieltor.comission = int.Parse(numericUpDown1.Value.ToString());
                updRieltor.id = indx;
                try
                {
                    rieltorComponent.Update(updRieltor);
                    parent.UpdateDataGrid();
                    MessageBox.Show("Клиент обновлен успешно");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("ФИО должны быть заполнены");
                return;
            }
        }
    }
}
