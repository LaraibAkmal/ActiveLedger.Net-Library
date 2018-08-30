using System.Configuration;


namespace ActiveLedgerLib
{
    public static class SDKPreferences
    {
        public static void setSettings(string protocol, string address, string port)
        {

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ConfigurationManager.AppSettings["URI"] == null)
            {
                configuration.AppSettings.Settings.Add("URI", protocol + "://" + address + ":" + port);
            }

            configuration.Save();

         ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);

        }
        public static string getSetting()
        {
            return ConfigurationManager.AppSettings["URI"];
        }
    }
}
