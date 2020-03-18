using System;


namespace UnitTestingAndDoc
{
    class Program
    {

        //create atm in console app
        // methods main, testable external method, userinterface method,
        // implement try/catch
        //do not include write or readline methods other than user interface

        public static decimal Balance = 9000.00m;

        /// <summary>
        /// Main method simply displays the menu and catches any exceptions not handled by the other methods.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your ATM!");
            try
            {
            bool menu = true;
            while (menu)
            {
                menu = showMenu();
            }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sorry! Something went wrong: {e.Message}");

            }
            finally
            {
                Console.WriteLine("Thank you! Goodbye!");
            }
        }


        /// <summary>
        /// UserInterFace method. User chooses their option and each option will either run a different method 
        /// or just let user view their balance or exit the atm.
        /// </summary>
        /// <returns>A boolean</returns>
        public static bool showMenu()
        {
            try
            {
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1. View balance");
                Console.WriteLine("2. Withdrawl");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Exit");

                string userInput = Console.ReadLine();
                int input = Convert.ToInt32(userInput);


                if (input == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Your balance is {Balance}");

                }
                // User chose to withdraw. If user tries to take out more than balance, they are prompted they can do that and to try again.
                // Otherwise, it will be able to.
                else if (input == 2)
                {
                    Console.Clear();
                    Console.WriteLine("How much would you like to withdraw?");
                    string amount = Console.ReadLine();
                    decimal userWithdrawl = Convert.ToDecimal(amount);

                    //if (userWithdrawl > Balance)
                    //{
                    //    Console.WriteLine($"Sorry, you cannot take money that you don't have! Try again");
                    //    return true;
                    //}
                    //else
                    //{
                    decimal newAmount = Withdrawl(userWithdrawl);
                    Console.WriteLine($"You withdrew {userWithdrawl}. Your new balance is {newAmount}");
                    //}
                }
                else if (input == 3)
                {
                    Console.Clear();
                    Console.WriteLine("How much would you like to deposit?");
                    string amount = Console.ReadLine();
                    decimal userDeposit = Convert.ToDecimal(amount);
                    decimal newAmount = Deposit(userDeposit);
                    Console.WriteLine($"You deposited {userDeposit}. Your new balance is {newAmount}");
                }
                else if (input == 4)
                {
                    return false;
                }
                else if (input > 4)
                {
                    Console.WriteLine("Please enter a valid response. Either numberical value: 1,2,3,4");
                    return true;
                }


       
                Console.WriteLine("Would you like another transaction? yes/no");
                string anotherTransaction = Console.ReadLine().ToLower();
                if (anotherTransaction == "yes" || anotherTransaction == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Sorry, invalid response. Try again.");
                    return true;

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry! Your input only takes numerical values.");
                return true;
            }


            static decimal Withdrawl(decimal withdrawlAmount)
            {               
                Balance = Balance - withdrawlAmount;
                if (withdrawlAmount > Balance)
                {
                    throw new Exception ($"Sorry, you cannot take money that you don't have! Try again");
                }
                return Balance;
            }

            static decimal Deposit(decimal depositAmount)
            {
                Balance += depositAmount;
                return Balance;
            }


        }
    }
}
