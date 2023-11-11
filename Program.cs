using System.Reflection;

namespace DevelopmentOfAnInteractiveMenuForATelegramBot
{
    internal class Program
    {
        static void Main()
        {
            string? commandValue;
            string? userName = "";

            Console.WriteLine($"Добрый день!\nЭто Telegram Bot.\nКоманды для взаимодействия со мной: {Constants.Start}, {Constants.Help}, {Constants.Info}, {Constants.Exit}");
            do
            {
                commandValue = Console.ReadLine();
                ControllFunction(commandValue);
            }
            while (commandValue != Constants.Exit);

            void ControllFunction(string? command)
            {
                if (command != null)
                {
                    if (userName != "" && command.TrimStart().StartsWith($"{Constants.Echo} "))
                    {
                        List<string> wordsOfCommand = new(command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                        wordsOfCommand.RemoveAt(0);
                        string result = string.Join(" ", wordsOfCommand);
                        Console.WriteLine(result);
                    }
                    switch (command)
                    {
                        case Constants.Start:
                            Console.WriteLine("Введите ваше имя:");
                            userName = Console.ReadLine();
                            break;
                        case Constants.Help:
                            Console.WriteLine($"{(userName != "" ? userName + ",\n" : "")}{Constants.HelpDescription}");
                            break;
                        case Constants.Info:
                            Console.WriteLine(string.Format($"{(userName != "" ? userName + ",\n" : "")}Текущая версия системы: {Assembly.GetExecutingAssembly().GetName().Version}\nДата создания: {Utils.GetBuildDate(Assembly.GetExecutingAssembly()):d}"));
                            break;
                        case Constants.Exit:
                            Console.WriteLine($"Пока{(userName != "" ? ", " + userName : "")}");
                            break;
                    }
                }
            }
        }
    }
}