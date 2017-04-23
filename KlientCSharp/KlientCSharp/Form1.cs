using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace KlientCSharp
{
    public partial class Form1 : Form
    {
        int x;

        Polaczenie pn = new Polaczenie();

        public Form1()
        {
            InitializeComponent();
            pn.ConnectSocket("192.168.1.103",5000);
            string[] ssize = (pn.SocketReceive()).Split(null);
            for (int i = 0; i < ssize.Length-1; i = i + 2)
            {
                dataGridView.Rows.Add(ssize[i], ssize[i + 1]);
            }
            this.dataGridView.AllowUserToAddRows = false;

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            x = dataGridView.CurrentRow.Index;
            x += 1;

            string wyslij = Convert.ToString(x);
            pn.SocketSend(wyslij);
            string[] ssize = (pn.SocketReceive()).Split(null);
            dataGridView.Rows.Clear();
            dataGridView.Columns.Add("Cena","Cena");
            for (int i = 0; i < ssize.Length-1; i = i + 3)
            {
                dataGridView.Rows.Add(ssize[i], ssize[i + 1], ssize[i + 2]);
            }
            btnWroc.Enabled = true;
            btnHistoria.Enabled = false;
            btnKup.Enabled = true;
            dataGridView.Enabled = false;
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            x = 0;
            string wyslij = Convert.ToString(x);
            pn.SocketSend(wyslij);
            string[] ssize = (pn.SocketReceive()).Split(null);
            try
            {
                dataGridView.Columns.Remove("Cena");
                dataGridView.Columns.Remove("Data zakupu");
            }
            catch (Exception)
            {
                Console.WriteLine("blad");
            }
            for (int i = 0; i < ssize.Length-1; i = i + 2)
            {
                dataGridView.Rows.Add(ssize[i], ssize[i + 1]);
            }
            btnWroc.Enabled = false;
            btnHistoria.Enabled = true;
            btnKup.Enabled = false;
            dataGridView.Enabled = true;
        }
        private void btnHistoria_Click(object sender, EventArgs e)
        {
            dataGridView.Enabled = false;
            dataGridView.Rows.Clear();
            x = 5;
            string wyslij = Convert.ToString(x);
            pn.SocketSend(wyslij);
            string[] ssize = (pn.SocketReceive()).Split(null);
            dataGridView.Columns.Add("Cena","Cena");
            dataGridView.Columns.Add("Data zakupu", "Data zakupu");
            for (int i = 0; i < ssize.Length - 1; i = i + 4)
            {
                dataGridView.Rows.Add(ssize[i], ssize[i + 1],ssize[i+2],ssize[i+3]);
            }
            btnWroc.Enabled = true;
        }
        private void btnZakoncz_Click(object sender, EventArgs e)
        {
            pn.DisconnectSocket();
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            x = 8;
            string wyslij = Convert.ToString(x);
            pn.SocketSend(wyslij);
            PotwierdzenieZakupu pz = new PotwierdzenieZakupu(pn);
            pz.Show();
        }


    }
}
