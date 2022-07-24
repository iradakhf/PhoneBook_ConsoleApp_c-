using CoreLibrary.Constants;
using DataLibrary;
using Manage.Controllers;
namespace Manage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ContactController _contactController = new ContactController();
            while (true)
            {
            ChoosingTheRightDigit: ConsoleHelper.WriteWithColor(ConsoleColor.DarkBlue, "Please, choose one of the options");
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "0-Exit");
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "1-Create");
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "2-Update");
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "3-Delete");
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "4-Get");
                ConsoleHelper.WriteWithColor(ConsoleColor.DarkMagenta, "5-GetAll");
                string option = Console.ReadLine();
                int choosenOption;
                bool result = int.TryParse(option, out choosenOption);
                if (result)
                {
                    if (choosenOption <= 5 && choosenOption >= 0)
                    {

                        switch (choosenOption)
                        {
                            case (int)Options.Exit:
                                ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "you exit");
                               return;
                            case (int)Options.Create:
                                _contactController.Create();
                                break;
                            case (int)Options.Update:
                                _contactController.Update();
                                break;
                            case (int)Options.Delete:
                                _contactController.Delete();
                                break;
                            case (int)Options.Get:
                                _contactController.Get();
                                break;
                            case (int)Options.GetAll:
                                _contactController.GetAll();
                                break;
                            
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "Please, choose the right digit");
                    }
                }
                    else
                    {
                        ConsoleHelper.WriteWithColor(ConsoleColor.DarkRed, "Please, choose the right digit");
                        goto ChoosingTheRightDigit;
                    }


            }

        }
    }
}