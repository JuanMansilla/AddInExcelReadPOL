using Excel = Microsoft.Office.Interop.Excel;

namespace ChrExcel
{
    public partial  class Form1:Form
    {
        public Fom1()
        {
            InitializeComponent();
        }

        private void Btn_Click()
        {
            string filetest = "C:\Ruta.xlsx";
            if (file.Exists(filetest)) {
                file.Delete(filetest)
            }

            Excel.Application oApp;
            Excel.Worksheet oSheet;
            Excel.Workbook eBook;

            oApp = new Excel.Application();
            oBook = oApp.Workbooks.Add();
            oSheet = (Excel.Worksheet)oBook.Worksheets.get_Item(1);
            oSheet.Cells[1, 1] = "some value";

            oBook.SaveAs(fileTest);
            oBook.Close();
            oApp.Quit();

        }
    }

}
