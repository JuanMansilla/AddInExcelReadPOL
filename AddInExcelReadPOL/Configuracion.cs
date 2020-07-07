using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AddInExcelReadPOL.Class;

namespace AddInExcelReadPOL
{
    public partial class Configuracion : Form
    {

        AppConfigPOL OPath = new AppConfigPOL();


        private string _Origen;
        private string _Destino;

        public string Origen
        {
            get
            {
                return _Origen = OPath.RecuperarConfig("Origen", "C:\\"); ;
            }

            set
            {
                _Origen = value;
            }
        }

        public string Destino
        {
            get
            {
                return _Destino = OPath.RecuperarConfig("Destino", "C:\\"); ;
            }

            set
            {
                _Destino = value;
            }
        }


        public Configuracion()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtOrigen.Text) & string.IsNullOrEmpty(TxtDestino.Text))
            {
                MessageBox.Show("Llenar las rutas de origen y destino", "Error critico",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Close();
            }
        }

        private void BtnOpenOrigen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string foldername = folderBrowserDialog1.SelectedPath;

            TxtOrigen.Text = foldername;
        }

        private void BtnOpenDestino_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string foldername = folderBrowserDialog1.SelectedPath;

            TxtDestino.Text = foldername;
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            TxtDestino.Text = Destino;
            TxtOrigen.Text = Origen;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Class.AppConfigPOL.EstablecerConfig("Origen",TxtOrigen.Text);
            Class.AppConfigPOL.EstablecerConfig("Destino", TxtDestino.Text);
            MessageBox.Show("Se debe reiniciar el libro para guardar los cambios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
    }
}
