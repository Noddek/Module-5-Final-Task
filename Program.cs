namespace Final_Task_5_6_1_Final_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nModule 5.6. Final Task 5.6.1. Final Project. Test of UserData() and PrintUserData() methods.");
            var userDataTuple = UserData();
            // or:
            // (string name, string surname, byte age, bool pet, byte numberOfPets, string[] petNames, byte numberOfFavoriteColors, string[] favoriteColors) userDataTuple = UserData();
            PrintUserData(userDataTuple);
            Console.WriteLine("\n\n>>> End of the program. Press any key to continue..."); Console.ReadKey();
        }


        // ------------------------------------------> METHODS:
        /* Module 5.6. 
            Final Task 5.6.1. Final Project.
            1. Create a method (1) to type in user data from the keyboard (method must return a tuple):
            - name;
            - surname;
            - age;
            - pet availability;
            - number of pets (if any);
            - if there are pets, call a method (2) that takes the number of pets and returns an array of their names (filled from the keyboard);
            - number of favorite colors;
            - call a method (2) that returns an array of favorite colors according to their number (fill with keyboard);
            - create a check if the user has entered correct numbers: age, number of pets, number of favorite colors in a separate method (3). 
                It is considered correct to enter an int number greater than 0;
            - if the input is incorrect, a re-entry request is needed.
            2. Create a method (4) that takes a tuple from the previous method and displays the data on the screen.
            3. Call the appropriate methods from the Main() method.
        */

        // Solution
        // 1. Main method for entering user data from the keyboard:
        static (string name, string surname, byte age, bool pet, byte numberOfPets, string[] petNames, byte numberOfFavoriteColors, string[] favoriteColors) UserData()
        {
            (string name, string surname, byte age, bool pet, byte numberOfPets, string[] petNames, byte numberOfFavoriteColors, string[] favoriteColors) tuple;
            Console.WriteLine("\n\t>>> Start of the UserData() method.");
            Console.Write("\t\tEnter your name: "); tuple.name = Console.ReadLine();
            Console.Write("\t\tEnter your surname: "); tuple.surname = Console.ReadLine();
            Console.Write("\t\tEnter your age: "); tuple.age = GetNumberAndValidate(123);
            Console.Write("\t\tDo you have any pets (Yes/No)? ");
            /*
            QUESTION:
            The program works with a 'while' loop, but it will be an infinite loop in case of incorrect input:
            while (true)
            {
                string yesno = Console.ReadLine();
                if (yesno == "Yes" || yesno == "yes" || yesno == "Y" || yesno == "y" || yesno == "1") { tuple.pet = true; break; }
                else if (yesno == "No" || yesno == "no" || yesno == "N" || yesno == "n" || yesno == "0") { tuple.pet = false; break; }
                else { Console.Write("\t\t\tIncorrect input, please try again: "); }
            }
            */
            // The program also works with the 'for' loop if we don't specify a condition i >=0 :
            for (int i = 3; ; --i)
            // But I don't understand why it doesn't work with the condition (with necessary adjustments):
            // for (int i = 3; i >=0 ; --i)
            // What am I missing?
            {
                string yesno = Console.ReadLine();
                if (yesno == "Yes" || yesno == "yes" || yesno == "Y" || yesno == "y" || yesno == "1") { tuple.pet = true; break; }
                else if (yesno == "No" || yesno == "no" || yesno == "N" || yesno == "n" || yesno == "0") { tuple.pet = false; break; }
                else
                {
                    if (i > 0) { Console.Write("\t\t\tIncorrect input, please try again: "); }
                    else { tuple.pet = false; Console.Write("\t\t\tAttempts failed, please try again later.\n"); break; }
                }
            }
            if (tuple.pet)
            {
                Console.Write("\t\tHow many pets do you have (number)? ");
                tuple.numberOfPets = GetNumberAndValidate(50);
                if (tuple.numberOfPets > 0)
                {
                    Console.Write("\t\tEnter the names of the pets below:\n");
                    tuple.petNames = ArrayViaKeyboard(tuple.numberOfPets);
                }
                else
                {
                    tuple.petNames = new string[1] { "No names" };
                }
            }
            else
            {
                tuple.numberOfPets = 0;
                tuple.petNames = new string[1] { "No names" };
            }

            Console.Write("\t\tHow many favorite colors do you have? ");
            tuple.numberOfFavoriteColors = GetNumberAndValidate(7);
            if (tuple.numberOfFavoriteColors > 0)
            {
                Console.Write("\t\tEnter the names of your favorite colors below:\n");
                tuple.favoriteColors = ArrayViaKeyboard(tuple.numberOfFavoriteColors);
            }
            else
            {
                tuple.favoriteColors = new string[1] { "No favorite colors" };
            }
            Console.WriteLine("\tThanks for participating!\n\t...Press any key to continue..."); Console.ReadKey();
            Console.WriteLine("\t>>> End of the UserData() method\n");
            return tuple;

            // 1.1. Local method to fill an array of pet names:
            string[] ArrayViaKeyboard(byte arrayLength)
            {
                string[] array = new string[arrayLength];
                for (byte i = 0; i <= array.GetUpperBound(0); ++i)
                {
                    Console.Write($"\t\t\t{i + 1}: ");
                    array[i] = Console.ReadLine();
                }
                return array;
            }

            // 1.2. Local method for checking the validity of entering numeric data:
            byte GetNumberAndValidate(byte maxValue = byte.MaxValue)
            {
                byte result = 0;
                for (int i = 3; i >= 0; --i)
                {
                    string stringToConvert = Console.ReadLine();
                    if (Byte.TryParse(stringToConvert, out result) && result > 0 && result <= maxValue) { break; }
                    if (i > 0) { Console.Write("\t\t\tIncorrect input, please try again: "); }
                    else { Console.Write("\t\t\tAttempts failed, please try again later.\n"); }
                }
                return result;
            }
        }

        // 2. Method for printing a tuple of user data:
        static void PrintUserData((string name, string surname, byte age, bool pet, byte numberOfPets, string[] petNames, byte numberOfFavoriteColors, string[] favoriteColors) tuple)
        {
            Console.WriteLine("\n\t>>> Start of the PrintUserData() method");
            Console.WriteLine("\t\tCollected user information:");
            // NAME & SURNAME:
            Console.WriteLine($"\t\t\tName: {tuple.name}");
            Console.WriteLine($"\t\t\tSurname: {tuple.surname}");
            // AGE:
            if (tuple.age <= 0) { Console.WriteLine("\t\t\tAge: Unknown"); }
            else { Console.WriteLine($"\t\t\tAge: {tuple.age}"); }
            // PETS:
            if (tuple.pet)
            {
                Console.WriteLine("\t\t\tPet(s): Yes");
                if (tuple.numberOfPets <= 0) { Console.WriteLine($"\t\t\tNumber of pets: Unknown"); }
                else { Console.WriteLine($"\t\t\tNumber of pets: {tuple.numberOfPets}"); }
                Console.Write("\t\t\tPet names: | ");
                foreach (string i in tuple.petNames)
                {
                    Console.Write(i + " | ");
                }
            }
            else
            {
                Console.Write("\t\t\tPet(s): No or not specified");
            }
            // FAVORITE COLORS:
            if (tuple.numberOfFavoriteColors <= 0) { Console.Write("\n\t\t\tNumber of favorite colors: No or not specified"); }
            else
            {
                Console.WriteLine($"\n\t\t\tNumber of favorite colors: {tuple.numberOfFavoriteColors}");
                Console.Write("\t\t\tNames of favorite colors: | ");
                foreach (string i in tuple.favoriteColors)
                {
                    Console.Write(i + " | ");
                }
            }
            Console.WriteLine("\n\t>>> End of the PrintUserData() method\n");
        }
    }
}
