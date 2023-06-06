using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Timer = System.Timers.Timer;

namespace Practica2.CLASSES
{
    public class ClPing
    {

        Color color;
        int dx, dy, velocitat, velocitatx, velocitaty;
        Label etq; //BackColor ,  PaDIING I MARING
        Form fpare;
        String ip;
        Timer tm,tm2;
        Ping p = new Ping();
        Random r = new Random();


        Boolean habiapogutferping = false, entratperprimercop = false;

        delegate void delegacio();


        public ClPing(Form xpare, string xip, int xvel, Color xcolor)
        {
            fpare = xpare;
            ip = xip;
            velocitat = velocitaty = velocitatx = xvel;
            color = xcolor;

            //Aqui creo l'etiqueta pero NO LA POSO A DINS DEL FORM
            iniEtiqueta(color);

            //Aqui tenim tota la configuracio dels timers

            //Aqui tenim la configuracio del primer timer
            tm = new Timer();
            tm.Interval = velocitat;
            tm.Elapsed += PerCadaTickFaraAixo;

            //Aqui tenim la configuracio del segon timer
            tm2 = new Timer();
            tm2.Interval = 15000;
            tm2.Elapsed += CadaXTempsReferPing;
            
        }

        private void CadaXTempsReferPing(object sender, System.Timers.ElapsedEventArgs e)
        {
            nouPing();
        }

        public void aturarTimer()
        {
            //Aqui parem els dos timers
            tm.Stop();
            tm2.Stop();
        }

        public void iniciarPing()
        {
            //Aqui haurem de fer per saber si la ip esta disponible o no
            nouPing();
            tm2.Start();
        }

        private void eliminarEtiqueta()
        {
            //Aquesta funcio s'hauria d'accedit mitjançant un delegat?
            fpare.Controls.Remove(etq);
        }

        private void iniEtiqueta(Color xcolor)
        {
            //Aqui farem la creacio de la etiqueta, nomes la creacio i despres l'haurem de posar a dins del form?
            etq = new Label();
            etq.BackColor = xcolor;
            etq.BorderStyle = BorderStyle.FixedSingle;
            etq.AutoSize = true;
            etq.Text = ip;
            etq.Font = new Font(etq.Font.FontFamily, 16);
            etq.Location = new Point(r.Next(0, fpare.Width), r.Next(0, fpare.Height));
            etq.Padding = new Padding(3); //Aqui hem de saber millor com es fa el padding

        }

        private void inserirEtiqueta()
        {
            //Aqui haurem d'accedir amb un delegat o com?
            //Simplement és un fmain.COntrols.ADD(label/panell)
            fpare.Controls.Add(etq);
        }

        private void moureEtiqueta()
        {
            //AQUESTA ES LA FUNCIO QUE HAUREM DE CONTROLAR LES CANTONADES I ANAR FENT EL MOVIMENT

            //Aqui hem d'accedir amb un delegat (Estem tocant coses del formMain)

            //Treballar amb locationa partir de les dx dy de la classe
            etq.Location = new Point(etq.Location.X + velocitatx, etq.Location.Y + velocitaty);
            
            
            
        }

        private void nouPing()
        {
            //Aqui farem  un ping a la adreça que tenim a la classe, si no la trobem haurem de fer una cosa, si la trobem haurem de fer una altre

            //Haurem de fer un if per saber si la ip esta disponible o no, si no ho esta hauriem de cirdar a la funcio de eliminarEtiqueta()
            tm2.Stop();
            if (p.Send(ip).Status == IPStatus.Success)
            {
                //Aqui es si ha pogut fer ping
                if (!habiapogutferping) //Si no havia pogut fer ping, entrara aqui, si abans ya havia pogut fer ping, NO entrara aqui
                {
                    fpare.Invoke(new delegacio(inserirEtiqueta));
                    habiapogutferping = true;
                    if (!entratperprimercop)
                    {
                        tm.Start();
                    }
                }
            }
            else
            {
                //Aqui es si no ha pogut fer ping
                if (habiapogutferping) //Si havia pogut fer ping i ara no, entrara aqui
                {
                    fpare.Invoke(new delegacio(eliminarEtiqueta));
                    habiapogutferping = false;
                }
            }
            tm2.Start();

        }

        private void PerCadaTickFaraAixo(object sender, System.Timers.ElapsedEventArgs e)
        {
            tm.Stop();
            try
            {
                fpare.Invoke(new delegacio(moureEtiqueta));
            }
            catch
            {

            }
            if (etq.Location.X < 0 || etq.Location.X > fpare.Width)
            {
                velocitatx = -velocitatx;
            }
            if (etq.Location.Y < 0 || etq.Location.Y > fpare.Height)
            {
                velocitaty = -velocitaty;
            }
            tm.Start();
        }
    }
}
