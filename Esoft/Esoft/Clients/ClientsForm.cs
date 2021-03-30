using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Esoft.Clients
{
    public partial class ClientsForm : Form
    {
        ClientComponent client;
        int index = 0;
        public ClientsForm()
        {
            InitializeComponent();
            client = new ClientComponent();
            UpdateDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        void CheckVisibleToolFlags(bool to)
        {
            toolStripMenuItem2.Visible = to;
            toolStripMenuItem3.Visible = to;
        }



        public void UpdateDataGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();
                Client[] clients = client.GetAll();
                BindingSource bs = new BindingSource();
                bs.DataSource = typeof(Client);
                if(clients != null)
                {
                    foreach (Client cl in clients)
                    {
                        bs.Add(cl);
                    }
                    dataGridView1.DataSource = bs;
                    dataGridView1.AutoGenerateColumns = true;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem == toolStripMenuItem1)
            {
                new AddClient(this).Show();
            }
            else if(e.ClickedItem == toolStripMenuItem2)
            {
                try
                {
                    client.Delete(index);
                    MessageBox.Show("Клиент " + index + " успешно удален");
                    UpdateDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else if (e.ClickedItem == toolStripMenuItem3)
            {
                try
                {
                    Client updClient = client.GetById(index);
                    new UpdateClient(updClient, this).Show();
                    UpdateDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                index = int.Parse(row.Cells[0].Value.ToString());
                toolStripStatusLabel2.Text = "Выбранный клиент: " + index;
            }
            else
            {
                index = 0;
                toolStripStatusLabel2.Text = "Выбранный клиент: ";
            }
            if (index != 0)
            {
                CheckVisibleToolFlags(true);
            }
            else
            {
                CheckVisibleToolFlags(false);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                index = int.Parse(row.Cells[0].Value.ToString());
                toolStripStatusLabel2.Text = "Выбранный клиент: " + index;
                break;
            }
            if (index != 0)
            {
                CheckVisibleToolFlags(true);
            }
            else
            {
                CheckVisibleToolFlags(false);
                toolStripStatusLabel2.Text = "Выбранный клиент: ";
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
