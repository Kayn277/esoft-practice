using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Esoft.Rieltors
{
    public partial class RieltorsForm : Form
    {
        RieltorsComponent client;
        int index = 0;
        public RieltorsForm()
        {
            InitializeComponent();
            client = new RieltorsComponent();
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();
                Rieltor[] clients = client.GetAll();
                BindingSource bs = new BindingSource();
                bs.DataSource = typeof(Rieltor);
                if (clients != null)
                {
                    foreach (Rieltor cl in clients)
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
        private void RieltorsForm_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripMenuItem1)
            {
                new AddRieltor(this).Show();
            }
            else if (e.ClickedItem == toolStripMenuItem3)
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
            else if (e.ClickedItem == toolStripMenuItem2)
            {
                try
                {
                    Rieltor updClient = client.GetById(index);
                    new UpdateRieltor(updClient, this).Show();//updClient, this
                    UpdateDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        void CheckVisibleToolFlags(bool to)
        {
            toolStripMenuItem3.Visible = to;
            toolStripMenuItem2.Visible = to;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                index = int.Parse(row.Cells[0].Value.ToString());
                toolStripStatusLabel1.Text = "Выбранный риэлтор: " + index;
                break;
            }
            if (index != 0)
            {
                CheckVisibleToolFlags(true);
            }
            else
            {
                CheckVisibleToolFlags(false);
                toolStripStatusLabel1.Text = "Выбранный риэлтор: ";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                index = int.Parse(row.Cells[0].Value.ToString());
                toolStripStatusLabel1.Text = "Выбранный риэлтор: " + index;
            }
            else
            {
                index = 0;
                toolStripStatusLabel1.Text = "Выбранный риэлтор: ";
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
    }
}
