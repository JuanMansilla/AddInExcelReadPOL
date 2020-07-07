using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;


namespace AddInExcelReadPOL.Class
{
    public class AppConfigPOL
    {
        public static void EstablecerConfig(string pLlave, string pValor)
        {
            //Crear el objeto de configuracion
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //Borrar la configuracion actual
            config.AppSettings.Settings.Remove(pLlave);

            //Guardar cambios
            config.Save(ConfigurationSaveMode.Modified);

            // Forzar la recarga de la seccion
            ConfigurationManager.RefreshSection("appSetting");

            //Guardar la configuracion
            config.AppSettings.Settings.Add(pLlave, pValor);

            //Guardar Cambios
            config.Save(ConfigurationSaveMode.Modified);

            //Forzar la recarga de la seccion
            ConfigurationManager.RefreshSection("appSetting");
        }


        public string RecuperarConfig(string pLlave, string pPredeterminado)
        {
            string retorno = ConfigurationManager.AppSettings[pLlave];
            if (retorno == null) { retorno = pPredeterminado; }
            return retorno;

        }
    }
}
