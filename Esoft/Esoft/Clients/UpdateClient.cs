using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Esoft.Clients
{
    public partial class UpdateClient : Form
    {
        ClientComponent clientComponent;
        ClientsForm parent;
        int clientIndex = 0;
        public UpdateClient(Client client, ClientsForm parentForm)
        {
            InitializeComponent();
            textBox1.Text = client.lastName;
            textBox2.Text = client.firstName;
            textBox3.Text = client.middleName;
            textBox4.Text = client.email;
            maskedTextBox1.Text = client.telephone;
            clientComponent = new ClientComponent();
            parent = parentForm;
            clientIndex = client.id;
        }

        private void UpdateClient_Load(object sender, EventArgs e)
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
                addClient.id = clientIndex;
                try
                {
                    clientComponent.Update(addClient);
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
                MessageBox.Show("Телефон или почта должны быть указаны");
                return;
            }
        }
    }
}
