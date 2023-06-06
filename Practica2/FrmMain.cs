using Practica2.CLASSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2
{
    public partial class FrmMain : Form
    {

        String principirang, finalrang;
        Boolean rangsipcorrectes = false;

        List<ClPing> llpings = new List<ClPing>();
        Color[] arraycolors = {Color.Red, Color.Green, Color.Blue, Color.Yellow };

        ClPing classepings;
        List<Thread> llThreads = new List<Thread>();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnferPing_Click(object sender, EventArgs e)
        {
            
            agafardadesprincipifinalrang();
            if (rangsipcorrectes)
            {
                ferforminvisible();
                //AQUI FAREM TOTA LA PROGRAMACIO DE FER ELS PINGS I TOT

                int cantitattotalarraycolors = arraycolors.Length;
                Random r = new Random();

                IPAddress ipprincipi = IPAddress.Parse(principirang);
                IPAddress ipfinal = IPAddress.Parse(finalrang);

                // Convertir la dirección IP en un byte array
                
                byte[] bytesprincipi = ipprincipi.GetAddressBytes().Reverse().ToArray();
                byte[] bytesfinal = ipfinal.GetAddressBytes().Reverse().ToArray();

                // Convertir el byte array en un 
                    
                //long end = BitConverter.ToInt64(ipfinal.GetAddressBytes(), 0);
                int ipintprimera = BitConverter.ToInt32(bytesprincipi, 0);
                int ipintultima = BitConverter.ToInt32(bytesfinal, 0);

                for(int i = ipintprimera; i < ipintultima; i++) //El primer valor sempre es més petit que el segon //Per aixo també 
                {
                    string ipreal = new IPAddress(BitConverter.GetBytes(i).Reverse().ToArray()).ToString();
                    classepings = new ClPing(this, ipreal, 5 , arraycolors[r.Next(0, cantitattotalarraycolors - 1)]);
                    llpings.Add(classepings);
                    llThreads.Add(new Thread(classepings.iniciarPing));
                    llThreads[llThreads.Count - 1].IsBackground = true;
                    llThreads[llThreads.Count - 1].Start();
                }
            }
            
        }

        private void agafardadesprincipifinalrang()
        {

            if (validarIP(tbPrincipiRang.Text.Trim()) && validarIP(tbFinalRang.Text.Trim()))
            {
                rangsipcorrectes=true;
                principirang=tbPrincipiRang.Text;
                finalrang= tbFinalRang.Text;
            }
            else
            {
                MessageBox.Show("El rang que has indicat no es correcte", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ferforminvisible()
        {
            this.TransparencyKey = this.BackColor; //AIXO FA INVISIBLE EL FORM
            this.WindowState = FormWindowState.Maximized;
            gpBotonsPing.Visible = false;
            

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ClPing ping in llpings)
            {
                ping.aturarTimer();
            }
            foreach (Thread thread in llThreads)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
            
        }

        Boolean validarIP(String xip)
        {
            IPAddress ip = null;

            return (IPAddress.TryParse(xip, out ip));
        }
    }
}
