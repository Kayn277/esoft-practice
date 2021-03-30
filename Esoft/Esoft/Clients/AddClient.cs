using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Esoft.Clients
{
    public partial class AddClient : Form
    {
        ClientComponent clientComponent;
        ClientsForm parent;
        public AddClient(ClientsForm parentForm)
        {
            InitializeComponent();
            clientComponent = new ClientComponent();
            parent = parentForm;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client addClient = new Client();
            if (maskedTextBox1.Text != "7" || textBox4.TextLength > 3)
            {
                if (textBox4.TextLength > 3)
                {
                    if (Validations.Validators.IsValidEmail(textBox4.Text))
                    {
                        addClient.email = textBox4.Text;
                    }
                    else
                    {
                        MessageBox.Show("Неверно указана почта");
                        return;
                    }
                }
                if (maskedTextBox1.Text != "7")
                {
                    if (maskedTextBox1.Text.Length == 11)
                    {
                        addClient.telephone = maskedTextBox1.Text;
                                                
                    }
                    else
                    {
                        MessageBox.Show("Телефон должен содержать 11 цифр");
                        return;
                    }
                }
                addClient.lastName = textBox1.Text;
                addClient.firstName = textBox2.Text;
                addClient.middleName = textBox3.Text;
                try
                {
                    clientComponent.PostClient(addClient);
                    parent.UpdateDataGrid();
                    MessageBox.Show("Клиент добавлен успешно");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Телефон или почта должны быть указаны");
                return;
            }
        }
    }
}
