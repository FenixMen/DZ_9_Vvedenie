using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DZ_9_Core_3_1
{
    class Config
    {

        static Configuration GetConfig() => ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static bool Next()
        {
            char userCommand = Console.ReadKey().KeyChar;
            if (userCommand == '1')
            {
                ResetUserConfig();
                Console.Clear();
                return true;
            }
            if (userCommand == '2') return false;
            Console.Clear();
            return true;
        }
        static void CheckConfigValueEmpty()
        {
            if (string.IsNullOrEmpty(GetConfig().AppSettings.Settings["userName"].Value)) CreateUserValue();
        }
        public static void CreateUserValue()
        {
            var config = GetConfig();
            Console.WriteLine("Введите Ваше имя");
            SetUserName(config);
            Console.WriteLine("Введите Ваш Возраст");
            SetUserAge(config);
            Console.WriteLine("Введите название вашей организации");
            SetUserWork(config);
            SaveConfig(config);
            Console.Clear();
        }
        public static void GreetengUser()
        {
            CheckConfigValueEmpty();
            Console.WriteLine($"Пользователь {GetUserName()}, возраст {GetUserAge()} лет, организация {GetUserWork()}");
        }
        
        static void SaveConfig(Configuration config)
        {
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        static string CheckUserAnswer(int lenght)
        {
            do
            {
                string userAnswer = Console.ReadLine();
                if (string.IsNullOrEmpty(userAnswer)) Console.WriteLine("Значение не может быть пустым, введите еще раз");
                else if (userAnswer.Length < lenght) Console.WriteLine("Слишком короткое значение, введите еще раз");
                else return userAnswer;
            }
            while (true);
        }
        static void SetUserName(Configuration config) 
            => config.AppSettings.Settings["userName"].Value = CheckUserAnswer(3);
        static void SetUserAge(Configuration config) 
            => config.AppSettings.Settings["userAge"].Value = CheckUserAnswer(1);
        static void SetUserWork(Configuration config) 
            => config.AppSettings.Settings["userWork"].Value = CheckUserAnswer(3);
        static string GetUserName() => GetConfig().AppSettings.Settings["userName"].Value;
        static string GetUserAge() => GetConfig().AppSettings.Settings["userAge"].Value;
        static string GetUserWork() => GetConfig().AppSettings.Settings["userWork"].Value;
        static void ResetUserConfig()
        {
            var config = GetConfig();
            foreach (var item in config.AppSettings.Settings.AllKeys)
            {
                config.AppSettings.Settings[item].Value = "";
            }
            //config.AppSettings.Settings.
            SaveConfig(config);
        }
    }
}
