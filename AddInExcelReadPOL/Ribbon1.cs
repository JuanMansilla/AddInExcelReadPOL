using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

using System.Windows.Forms;
using AddInExcelReadPOL.Class;
using System.IO;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing;

using System.Diagnostics;
using System.Data.OleDb;


namespace AddInExcelReadPOL
{
    
    public partial class Ribbon1
    {
        

        AppConfigPOL OPath = new AppConfigPOL();

        private string _Origen;
        private string _Destino;
        private DataTable _Archivo;
        private string _NamePol;
        private string _Extra;


        public string Origen
        {
            get
            {
                return _Origen = OPath.RecuperarConfig("Origen", "C:\\"); 
            }
        }

        public string Destino
        {
            get
            {
                return _Destino = OPath.RecuperarConfig("Destino", "C:\\"); 
            }
        }

        public DataTable Archivo
        {
            get
            {
                return _Archivo;
            }

            set
            {
                _Archivo = value;
            }
        }

        public string NamePol
        {
            get
            {
                return _NamePol;
            }

            set
            {
                _NamePol = value;
            }
        }

        public string Extra
        {
            get
            {
                return _Extra;
            }

            set
            {
                _Extra = value;
            }
        }

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            this.BtnGuardar.Enabled = false;
        }

        private void BtnCargar_Click(object sender, RibbonControlEventArgs e)
        {
            // Se crea el objeto "open"
            OpenFileDialog open = new OpenFileDialog();

            // Se inicializa en el directorio Origen
            open.InitialDirectory = Origen;
            //Se setea los archivos permitidos
            open.Filter = "Archivos POL(*.pol)|*.pol";
            open.Title = "Seleccionar el archivo POL";
            open.FilterIndex = 1;
           //open.RestoreDirectory = true;

            // Se habre el directorio, y solo si se da OK Arranca las funciones
            if (open.ShowDialog()==DialogResult.OK)
            {
                // Se obtiene todo el Path 
                string FileExtension = open.FileName;
                // Se obtiene el nombre del archivo
                NamePol = Path.GetFileNameWithoutExtension(open.FileName);
                // Se llena el DataTable Archivo, con la funcion LeerArchivo
                Archivo = LeerArchivo(FileExtension);
                // Se valida que no este vacio
                if (Archivo != null)
                {
                    // Se habilita el boton Guardar
                    this.BtnGuardar.Enabled = true;
                    //Se pasa el nombre del archivo POL y el DataTable
                    WorkHoja(NamePol, Archivo);
                }
            }
            else
            {
                MessageBox.Show("No se cargo ningun archivo .POL", "Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            // Desactivamos la conexion
            open.Dispose();

        }

        private DataTable LeerArchivo(string con)
        {
            // Example: File Name --> 12-4180-006-02-D1 Structure

            // 1 column: Method to have name file

            // 2 Column: Name material, se divide el String por '-', siempre son 5 campos
            string[] Materiales = NamePol.Split('-');
            string Extra = Materiales[1] + "-" + Materiales[2] + "-" + Materiales[3] + "-" + Materiales[4];
            // El material ocupa la quinta posicion --> 4
            string Material = Materiales[4];

            // 3 Column: Object name: POLY
            string Poly = "POLY";

            // 4 Column File name = 1 Column
            // 5 Column number point, autogenerate
            // 6 Column X 
            // 7 Column Y
            // 8 Column Z

            string Nivel = Materiales[1];

            // Creamos una lista para las coordenadas ya que apartir de la 4 Linea solo se escribe X & Y
            List<string> Coordenadas = new List<string>();

            // Creamos un objeto y lo seteamos segun la funcion descrita
            DataTable dt = CreateDataTable();
            //Contador de Lineas
            int i = 0;

            try
            {
                // Empezamos a leer el archivo,
                StreamReader myReader = new StreamReader(con);
                string line = "";
                // Mientras no este vacio
                while (line != null)
                {
                    // Leemos los archivos, uno a uno
                    line = myReader.ReadLine();
                    if(line != null & i>2)
                    {
                        // Dividimos el string por comas X e Y  validamos que no esten vacios o valgan 0
                        Coordenadas = line.Split(',').ToList<string>();
                        if ((Coordenadas[0] != string.Empty || Coordenadas[0] != string.Empty) && 
                            (Convert.ToDouble(Coordenadas[0]) != 0.00 || Convert.ToDouble(Coordenadas[1]) != 0.00))
                        {
                            // Llenamos las filas con los valores.
                            dt.Rows.Add(Extra, Materiales[4], Poly, Extra, (i - 2).ToString(), Coordenadas[0], Coordenadas[1], Nivel);
                            dt.AcceptChanges();
                        }
                    }
                    // Contador de Lineas
                    i++;
                }
                // Una vez q se llena borramos los elementos
                Coordenadas.Clear();
                //Cerramos la conexion
                myReader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            // Regresamos la tabla con los elementos
            return dt;
        }

        private void BtnConfigurar_Click(object sender, RibbonControlEventArgs e)
        {
            Configuracion Windows = new Configuracion();
            Windows.Show();
        }

        private DataTable CreateDataTable()
        {
            // Instanciamos un objeto creando los parametros segun la salida
            DataTable dt = new DataTable();

            dt.Columns.Add("FileName1", typeof(string));  //1
            dt.Columns.Add("Material", typeof(string));  //2
            dt.Columns.Add("Poly", typeof(string));  //3
            dt.Columns.Add("FileName2", typeof(string));  //4
            dt.Columns.Add("Point",typeof(string));  //5
            dt.Columns.Add("X", typeof(string));  //6
            dt.Columns.Add("Y", typeof(string));  //7
            dt.Columns.Add("Z", typeof(string));  //8
            dt.AcceptChanges();
            // Retornamos la tabla formateada
            return dt;
        }


        private void WorkHoja(string Archivo, DataTable Tabla)
        {
            int j = 0;
            bool found = false;

            int Columna = 2;
            int Fila = 4;

            Excel.Worksheet hoja = new Excel.Worksheet();

            foreach (Excel.Worksheet wb in Globals.ThisAddIn.Application.Worksheets)
            {
                j++;
                if (wb.Name == "Polygon")
                {
                    found = true;
                    break;
                }
            }
            if(found)
            {
                hoja = Globals.ThisAddIn.Application.Worksheets[j];
                hoja.Name = "Polygon";
                hoja.Select();
                Clearsheet(hoja.Name);
            }
            else
            {
                hoja = Globals.ThisAddIn.Application.Worksheets.Add();
                hoja.Name = "Polygon";
                hoja.Select();
            }
            
            montacabecera(3, ref hoja, Archivo);

            foreach (DataRow Linea in Tabla.Rows)
            {
                foreach (string Element in Linea.ItemArray)
                {
                    if (String.IsNullOrEmpty(Element))
                    {
                        break;
                    }
                    else
                    {
                        hoja.Cells[Fila, Columna] = Element;
                        Columna++;
                    }
                }
                Fila++;
                Columna = 2;
            }

        }

        private void Clearsheet(string Name)
        {
            Excel.Range rango = null;
            Excel.Worksheet hoja = new Excel.Worksheet();
            hoja = Globals.ThisAddIn.Application.Worksheets[Name];
            hoja.Select();
            rango = hoja.Range["A1", "K150"];
            rango.Clear();
        }

        private void montacabecera(int v, ref Excel.Worksheet hoja,string FileName)
        {
            try
            {
                Excel.Range rango;

                rango = hoja.Range["B1", "I1"];
                rango.Font.Color = ColorTranslator.FromHtml("#199448");
                rango.Interior.Color = ColorTranslator.FromHtml("#FFFABA");
                rango.Font.Bold = true;
                rango.Font.Size = 20;
                rango.VerticalAlignment = 3;
                rango.HorizontalAlignment = 3;

                rango.Merge();

                rango = hoja.Rows[1];
                rango.RowHeight = 25;

                hoja.Cells[1, 2] = FileName;

                hoja.Cells[v, 2] = "Object name";
                hoja.Cells[v, 3] = "Object material name";
                hoja.Cells[v, 4] = "Object material code";
                hoja.Cells[v, 5] = "Element name";
                hoja.Cells[v, 6] = "Point number";
                hoja.Cells[v, 7] = "X";
                hoja.Cells[v, 8] = "Y";
                hoja.Cells[v, 9] = "Z";

                rango = hoja.Range["B3", "I3"];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.Borders.Weight = 2d;

                rango = hoja.Rows[v];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rango = hoja.Columns[1];
                rango.ColumnWidth = 1;
                rango = hoja.Columns[2];
                rango.ColumnWidth = 19;
                rango = hoja.Columns[3];
                rango.ColumnWidth = 20;
                rango = hoja.Columns[4];
                rango.ColumnWidth = 20;
                rango = hoja.Columns[5];
                rango.ColumnWidth = 19;
                rango = hoja.Columns[6];
                rango.ColumnWidth = 15;
                rango = hoja.Columns[7];
                rango.ColumnWidth = 10;
                rango = hoja.Columns[8];
                rango.ColumnWidth = 10;
                rango = hoja.Columns[9];
                rango.ColumnWidth = 7;
                rango = hoja.Columns[10];
                rango.ColumnWidth = 1;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnGuardar_Click(object sender, RibbonControlEventArgs e)
        {

            GuardarDatos();

            Clearsheet("Polygon");
        }

        private void GuardarDatos( )
        {

            string FileSavePath = Path.Combine(Destino, NamePol);
            // string pb = Path.Combine(Destino, Extra);
            Debug.Write("JM");
            Debug.Write(Extra);
            try
            {
                // Comprovamos si el archivo existe, si es asi lo eliminamos 
                if (File.Exists(FileSavePath))
                {
                    File.Delete(FileSavePath);
                }

                // Creamos el archivo segun la ruta y lo llenamos de la tabla
                    StreamWriter swExtLogFile = new StreamWriter(Extra, true);

                    int i;
                    foreach (DataRow row in Archivo.Rows)
                    {
                        object[] array = row.ItemArray;
                        for (i = 0; i < array.Length - 1; i++)
                        {
                            if (!string.IsNullOrEmpty(array[i].ToString()))
                            {
                                swExtLogFile.Write(array[i].ToString() + "    ");
                            }
                        }
                        swExtLogFile.WriteLine(array[i].ToString());
                    }
                    swExtLogFile.Flush();
                    swExtLogFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            BtnGuardar.Enabled = false;
        }
    }
}