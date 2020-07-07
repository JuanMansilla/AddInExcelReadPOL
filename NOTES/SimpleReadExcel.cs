public static DataTable ConvertCSVtoDataTable(string strFilePath)
{
           StreamReader sr = new StreamReader(strFilePath);
           string[] headers = sr.ReadLine().Split(',');
           DataTable dt = new DataTable();
           foreach (string header in headers)
           {
               dt.Columns.Add(header);
           }
           while (!sr.EndOfStream)
           {
               string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
               DataRow dr = dt.NewRow();
               for (int i = 0; i < headers.Length; i++)
               {
                   dr[i] = rows[i];
               }
               dt.Rows.Add(dr);
           }
           return dt;
}



/// Call the ConvertCSVtoDataTable function like below by passing path of the CSV file.
static void Main(string[] args)
{
      string filepath = "d://ConvertedFile.csv";
      DataTable res = ConvertCSVtoDataTable(filepath);
}
