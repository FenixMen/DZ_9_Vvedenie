using System;
using System.Configuration;

namespace DZ_9_Core_3_1
{
    class Program
    {//Создать консольное приложение, которое при старте выводит приветствие, записанное
     //в настройках приложения (application-scope). Запросить у пользователя имя, возраст и
     //род деятельности, а затем сохранить данные в настройках. При следующем запуске отобразить
     //эти сведения. Задать приложению версию и описание.
        static void Main(string[] args)
        {
            //Create the object
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //make changes
           // config.AppSettings.Settings["Key2"].Value = "ddd";

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            var sAll = ConfigurationManager.AppSettings;

            foreach (string s in sAll.AllKeys)
            { 
            Console.WriteLine("Key: " + s + " Value: " + sAll.Get(s));
            }
            Console.ReadLine();

            //save to apply changes
            


        }
    }
}
