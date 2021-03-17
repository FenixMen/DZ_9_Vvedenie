using System;
using System.Configuration;
using System.Reflection;

namespace DZ_9_Core_3_1
{
    class Program
    {//Создать консольное приложение, которое при старте выводит приветствие, записанное
     //в настройках приложения (application-scope). Запросить у пользователя имя, возраст и
     //род деятельности, а затем сохранить данные в настройках. При следующем запуске отобразить
     //эти сведения. Задать приложению версию и описание.
        
        static void Main(string[] args)
        {
            string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();


            var a = typeof(string).Assembly.GetName().Version;
            do
            {
                Config.GreetengUser();
                Console.WriteLine("1 - Сменить данные");
                Console.WriteLine("2 - Выйти из программы");
                AssemblyVersion();
            }
            while (Config.Next());




            void AssemblyVersion()
            {
                Console.SetCursorPosition(0, 26);
                Console.WriteLine($"Версия сборки {assemblyVersion}");
                Console.SetCursorPosition(0, 3);
            }




        }
    }
}
