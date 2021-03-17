using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_9_Framework
{
    class Program
    {//Создать консольное приложение, которое при старте выводит приветствие, записанное
     //в настройках приложения (application-scope). Запросить у пользователя имя, возраст и
     //род деятельности, а затем сохранить данные в настройках. При следующем запуске отобразить
     //эти сведения. Задать приложению версию и описание.
        static void Main(string[] args)
        {
            do
            {
                if (CheckUserValue()) GreetingUser();
                else CreateUserValue();

                Console.WriteLine("1 - Изменить свои данные");
                Console.WriteLine("2 - Выйти из программы");
            }
            while (Next());


            bool Next()
            {
                char key = Console.ReadKey().KeyChar;
                if (key == '1')
                {
                    Properties.Settings.Default.Reset();
                    Console.Clear();
                    return true;
                }
                else if (key == '2')
                {
                    return false;
                }
                return true;
            }
            void GreetingUser() => Console.WriteLine($"Полльзователь: {GetUserName()}, {GetUserAge()} лет, место работы: {GetUserWork()}\n");
            bool CheckUserValue()
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.userName)) return false;
                return true;
            }
            void CreateUserValue()
            {
                Console.WriteLine("Введите ваше имя");
                SaveUserName();
                Console.WriteLine("Сколько вам лет?");
                SaveUserAge();
                Console.WriteLine("Где вы работаете?");
                SaveUserWork();
                Console.Clear();
                GreetingUser();
            }
            string GetUserAnswer(int lenghtValue)
            {
                while (true)
                {
                    string userAnswer = Console.ReadLine();
                    if (string.IsNullOrEmpty(userAnswer))
                    {
                        Console.WriteLine("Значение не может быть пустым, введите заново");
                    }
                    else if (userAnswer.Length < lenghtValue)
                    {
                        Console.WriteLine("Слишком короткое значение, введите заново");
                    }
                    return userAnswer;
                }
            }
            void SaveUserName()
            {
                string userName = GetUserAnswer(3);
                Properties.Settings.Default.userName = userName;
                Properties.Settings.Default.Save();
            }
            void SaveUserAge()
            {
                string userAge = GetUserAnswer(1);
                Properties.Settings.Default.userAge = userAge;
                Properties.Settings.Default.Save();
            }
            void SaveUserWork()
            {
                string userWork = GetUserAnswer(3);
                Properties.Settings.Default.userWork = userWork;
                Properties.Settings.Default.Save();
            }
            string GetUserName() => Properties.Settings.Default.userName;
            string GetUserAge() => Properties.Settings.Default.userAge;
            string GetUserWork() => Properties.Settings.Default.userWork;
        }
    }
}
