using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Projeto_Evangelismo_2024
{
    public partial class frmMusic : Form
    {
        string Music = "";
        string URL = "";
        public frmMusic(string music, string url)
        {
            InitializeComponent();
            Music = music;
            URL = url;
        }

            private void frmMusic_Load(object sender, EventArgs e)
            {
                this.Text = "Evangelismo - Pra ser Feliz 2024 - " + Music;
                if (System.IO.File.Exists(URL))
                {
                    axWindowsMediaPlayer1.URL = URL;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        axWindowsMediaPlayer1.fullScreen = true;
                    }
                }
                else
                {
                    MessageBox.Show("Música não encontrada! Localize o arquivo de vídeo neste computador.", "Evangelismo Pra ser Feliz 2024", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    OpenFileDialog ofdEditMusic = new OpenFileDialog();                
                    if (ofdEditMusic.ShowDialog() == DialogResult.OK)
                    {
                        string novoCaminho = ofdEditMusic.FileName;
                        string caminhoPadrao = @"C:\\Program Files\\Evangelismo Pra ser Feliz 2024\\musics.xml";
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(caminhoPadrao);

                        // Lógica para encontrar e atualizar o caminho da música no XML
                        // Neste exemplo, estou assumindo que o título da música é único
                        string tituloDaMusica = this.Music; //Path.GetFileNameWithoutExtension(novoCaminho);
                        XmlNode musicaNode = xmlDoc.SelectSingleNode($"//musica[titulo='{tituloDaMusica}']/caminho");

                        if (musicaNode != null)
                        {
                            musicaNode.InnerText = novoCaminho;
                            xmlDoc.Save(caminhoPadrao);
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Verifique se o estado de reprodução é "wmppsMediaEnded" (música encerrada)
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                this.Close();
            }
        }

        private void frmMusic_FormClosing(object sender, FormClosingEventArgs e)
        {
            axWindowsMediaPlayer1.fullScreen = false;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void axWindowsMediaPlayer1_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.fullScreen = true;
            }
        }

        private void axWindowsMediaPlayer1_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            if (Convert.ToChar(e.nKeyCode) == Convert.ToChar(Keys.Escape))
            {
                FormClosingEventArgs a = null;
                frmMusic_FormClosing(sender, a);
            }
        }

        private void frmMusic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        private void axWindowsMediaPlayer1_EndOfStream(object sender, AxWMPLib._WMPOCXEvents_EndOfStreamEvent e)
        {
            // Verifica se o estado de reprodução é EndOfStream
            if (e.result == 0)
            {
                FormClosingEventArgs a = null;
                frmMusic_FormClosing(sender, a);
            }
        }
    }
}
