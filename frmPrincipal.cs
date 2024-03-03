using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Projeto_Evangelismo_2024
{
    public partial class frmPrincipal : Form
    {
        frmMusic frm;
        string[] Music = new string[14];
        string[] URL = new string[14];
        public frmPrincipal()
        {
            InitializeComponent();
            LoadMusicFromXML(@"C:\Program Files\Evangelismo Pra Ser Feliz 2024\musics.xml");
        }

        private void LoadMusicFromXML(string caminhoXML)
        {
            try
            {
                XDocument doc = XDocument.Load(caminhoXML);
                try
                {
                    for (int i = 0; i <= 13; i++)
                    {
                        // Use ElementAt(i) para acessar o elemento específico no índice i
                        XElement elementoMusica = doc.Descendants("musica").ElementAt(i);

                        string titulo = elementoMusica.Element("titulo").Value;
                        string caminho = elementoMusica.Element("caminho").Value;

                        Music[i] = titulo;
                        URL[i] = caminho;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar as músicas: " + ex.Message, "Evangelismo Pra ser Feliz 2024", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de músicas: " + ex.Message, "Evangelismo Pra ser Feliz 2024", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://ebs-systems.epizy.com/");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Escape))
            {
                Application.Exit();
            }
        }

        private void lblSorria_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[0], URL[0]);
            frm.ShowDialog();
        }

        private void lblCabodaNau_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[3], URL[3]);
            frm.ShowDialog();
        }

        private void lblEuSouFeliz_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[4], URL[4]);
            frm.ShowDialog();
        }

        private void lblPingoDeChuva_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[1], URL[1]);
            frm.ShowDialog();
        }

        private void lblSonameUsame_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[2], URL[2]);
            frm.ShowDialog();
        }

        private void lblQuaoGrandeEOMeuDeus_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[7], URL[7]);
            frm.ShowDialog();
        }

        private void lblVoceTemValor_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[5], URL[5]);
            frm.ShowDialog();
        }

        private void lblEleNaoDesisteDeVoce_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[6], URL[6]);
            frm.ShowDialog();
        }

        private void lblAAlegriaEstaNoCoracao_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[10], URL[10]);
            frm.ShowDialog();
        }

        private void lblRaridade_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[13], URL[13]);
            frm.ShowDialog();
        }

        private void lblMeuFarol_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[9], URL[9]);
            frm.ShowDialog();
        }

        private void lblEAdorar_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[8], URL[8]);
            frm.ShowDialog();
        }

        private void lblTeuPoder_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[11], URL[11]);
            frm.ShowDialog();
        }

        private void lblMaranata_Click(object sender, EventArgs e)
        {
            frm = new frmMusic(Music[12], URL[12]);
            frm.ShowDialog();
        }
    }
}
