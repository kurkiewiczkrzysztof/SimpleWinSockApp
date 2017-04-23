using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlientCSharp
{
    public partial class PotwierdzenieZakupu : Form
    {
        Polaczenie pn2 = new Polaczenie();
        public PotwierdzenieZakupu(Polaczenie pn)
        {
            InitializeComponent();
            pn2 = pn;
        }

        private void btnKup_Click(object sender, EventArgs e)
        {
            String id = txtID.Text;
            pn2.SocketSend(id);
            MessageBox.Show("Dziekujemy za zakup!");
            this.Close();
        }
    }
}
