using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using Json.Net;
using Newtonsoft.Json;
namespace Esoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Clients.ClientsForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Rieltors.RieltorsForm().ShowDialog();
        }
    }
}
