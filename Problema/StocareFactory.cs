using NivelAccesDate;
using System.Configuration;

namespace Problema
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER = "NumeFisier";
        public static IStocareData GetAdministratorStocare()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisier = ConfigurationManager.AppSettings[NUME_FISIER];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:                  
                    case "txt":
                        return new AdministrareAutomobile_FisierText(numeFisier + "." + formatSalvare);
                }
            }

            return null;
        }
    }
}
