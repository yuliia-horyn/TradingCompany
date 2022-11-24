using System;
using System.Text;

namespace TradingCompany
{
    public class Menu
    {
        private Command cmd = new Command();
        public void ShowMenu()
        {
            string userInput = "";
            do
            {
                ShowMainMenu();
                userInput = Console.ReadLine();
            }
            while (userInput != "q");
        }
        void ShowMainMenu()
        {
            string menu = @"Trading Company~Shoe Factory
Please choose the option:
1 - Work with users;
2 - Work with shoes;
3 - Work with orders;
q - Exit";
            Console.WriteLine(menu);
            char userInput = Console.ReadLine()[0];
            MainMenuInput(userInput);

        }
        private void MainMenuInput(char userInput)
        {
            switch (userInput)
            {
                case '1':
                    ShowUsersMenu();
                    break;
                case '2':
                    ShowShoesMenu();
                    break;
                case '3':
                    ShowOrdersMenu();
                    break;
                case 'q':
                    break;
                default:
                    Console.WriteLine("You typed something wrong");
                    break;
            }

        }
        private void ShowUsersMenu()
        {
            string menu = @"Trading Company~Shoe Factory
Please choose the option:
1 - Create new user;
2 - Read all users;
3 - Update existing user;
4 - Delete user;
b - Back to main menu;
q - Exit";
            Console.Clear();
            Console.WriteLine(menu);
            char userInput = Console.ReadLine()[0];
            UsersMenuInput(userInput);
        }
        private void UsersMenuInput(char userInput)
        {
            switch (userInput)
            {
                case '1':
                    InfoForCreateUser();                  
                    ComeBackUsersMenu();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Please wait this action takes time");
                    cmd.ReadAllUsers();
                    ComeBackUsersMenu();
                    break;
                case '3':
                    InfoForUpdateUser();
                    ComeBackUsersMenu();
                    break;
                case '4':                   
                    cmd.DeleteUser(GetId());
                    ComeBackUsersMenu();
                    break;
                case 'b':
                    Console.Clear();
                    ShowMainMenu();
                    break;
                case 'q':
                    break;
                default:
                    Console.WriteLine("You typed something wrong");
                    break;
            }
        }    
        private void ShowShoesMenu()
        {
            string menu = @"Trading Company~Shoe Factory
Please choose the option:
1 - Create new shoes;
2 - Read all shoes;
3 - Update existing shoes;
4 - Delete shoes;
b - Back to main menu;
q - Exit";
            Console.Clear();
            Console.WriteLine(menu);
            char userInput = Console.ReadLine()[0];
            ShoesMenuInput(userInput);
        }
        private void ShoesMenuInput(char userInput)
        {
            switch (userInput)
            {
                case '1':
                    InfoForCreateShoes();                   
                    ComeBackShoesMenu();
                    break;
                case '2':
                    Console.Clear();
                    cmd.ReadAllShoes();
                    ComeBackShoesMenu();
                    break;
                case '3':
                    InfoForUpdateShoes();                  
                    ComeBackShoesMenu();
                    break;
                case '4':
                    cmd.DeleteShoes(GetId());
                    ComeBackShoesMenu();
                    break;
                case 'b':
                    Console.Clear();
                    ShowMainMenu();
                    break;
                case 'q':
                    break;
                default:
                    Console.WriteLine("You typed something wrong");
                    break;
            }
        }
        private void ShowOrdersMenu()
        {
            string menu = @"Trading Company~Shoe Factory
Please choose the option:
1 - Create new order;
2 - Read all orders;
3 - Update existing order;
4 - Delete order;
b - Back to main menu;
q - Exit";
            Console.Clear();
            Console.WriteLine(menu);
            char userInput = Console.ReadLine()[0];
            OrdersMenuInput(userInput);
        }
        private void OrdersMenuInput(char userInput)
        {
            switch (userInput)
            {
                case '1':
                    InfoForCreateOrder();                  
                    ComeBackOrdersMenu();
                    break;
                case '2':
                    Console.Clear();
                    cmd.ReadAllOrders();
                    ComeBackOrdersMenu();
                    break;
                case '3':
                    
                    InfoForUpdateOrder();
                    ComeBackOrdersMenu();
                    break;
                case '4':
                    cmd.DeleteOrder(GetId());
                    ComeBackOrdersMenu();
                    break;
                case 'b':
                    Console.Clear();
                    ShowMainMenu();
                    break;
                case 'q':
                    break;
                default:
                    Console.WriteLine("You typed something wrong");
                    break;
            }
        }
        private int GetId()
        {
            Console.WriteLine("Please enter the id: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        private void InfoForCreateUser()
        {
            Console.Clear();
            Console.WriteLine("Enter first name of user : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name of user : ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter login for user : ");
            string login = Console.ReadLine();
            Console.WriteLine("Enter password user : ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter keyword for user : ");
            string keyword = Console.ReadLine();
            Console.WriteLine("Enter gender of user : ");
            bool gender = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Enter address of user : ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter email of user : ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter phone number of user : ");
            string phonenumber = Console.ReadLine();
            Console.WriteLine("Enter bank card of user : ");
            string bankcard = Console.ReadLine();

            cmd.CreateNewUser(firstName, lastName, login, password, keyword, gender, address, email, phonenumber, bankcard);
        }
        private void InfoForUpdateUser()
        {
            Console.Clear();
            int id = GetId();
            Console.WriteLine("Enter first name of user : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name of user : ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter login for user : ");
            string login = Console.ReadLine();
            Console.WriteLine("Enter password user : ");
            byte[] password = Encoding.ASCII.GetBytes(Console.ReadLine());
            Console.WriteLine("Enter keyword for user : ");
            string keyword = Console.ReadLine();
            Console.WriteLine("Enter gender of user : ");
            bool gender = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Enter address of user : ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter email of user : ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter phone number of user : ");
            string phonenumber = Console.ReadLine();
            Console.WriteLine("Enter bank card of user : ");
            string bankcard = Console.ReadLine();           

            cmd.UpdateUser(id,firstName, lastName, login, password, keyword, gender, address, email, phonenumber, bankcard);
        }
        private void ComeBackUsersMenu()
        {
            Console.Write("Enter b to back to the previous menu: ");
            char user_input = Console.ReadLine()[0];
            if (user_input == 'b') { ShowUsersMenu(); }
            else { Console.WriteLine("You typed something wrong"); }
        }
        private void InfoForCreateShoes()
        {
            Console.Clear();
            Console.WriteLine("Enter name of shoes : ");
            string shoesName = Console.ReadLine();
            Console.WriteLine("Enter size of shoes : ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter color of shoes : ");
            string color = Console.ReadLine();
            Console.WriteLine("Enter price of shoes : ");
            float price = float.Parse(Console.ReadLine());

            cmd.CreateNewShoes(shoesName, size, color, price);
        }
        private void InfoForUpdateShoes()
        {
            Console.Clear();
            int id = GetId();
            Console.WriteLine("Enter name of shoes : ");
            string shoesName = Console.ReadLine();
            Console.WriteLine("Enter size of shoes : ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter color of shoes : ");
            string color = Console.ReadLine();
            Console.WriteLine("Enter price of shoes : ");
            float price = float.Parse(Console.ReadLine());

            cmd.UpdateShoes(id,shoesName, size, color, price);
        }
        private void ComeBackShoesMenu()
        {
            Console.Write("Enter b to back to the previous menu: ");
            char user_input = Console.ReadLine()[0];
            if (user_input == 'b') { ShowShoesMenu(); }
            else { Console.WriteLine("You typed something wrong"); }
        }
        private void InfoForCreateOrder()
        {
            Console.Clear();
            Console.WriteLine("Enter id of shoes : ");
            int shoesId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter id of user : ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter quantity of shoes : ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter date of order in format(yyyy-mm-dd) : ");
            DateTime orderdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter total price : ");
            float price = float.Parse(Console.ReadLine());

            cmd.CreateNewOrder(shoesId, userId, quantity, orderdate, price);
        }
        private void InfoForUpdateOrder()
        {
            Console.Clear();
            int id = GetId();
            Console.WriteLine("Enter id of shoes : ");
            int shoesId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter id of user : ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter quantity of shoes : ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter date of order in format(yyyy-mm-dd) : ");
            DateTime orderdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter total price : ");
            float price = float.Parse(Console.ReadLine());

            cmd.UpdateOrders(id,shoesId, userId, quantity, orderdate, price);
        }
        private void ComeBackOrdersMenu()
        {
            Console.Write("Enter b to back to the previous menu: ");
            char user_input = Console.ReadLine()[0];
            if (user_input == 'b') { ShowOrdersMenu(); }
            else { Console.WriteLine("You typed something wrong"); }
        }  
    }
}
