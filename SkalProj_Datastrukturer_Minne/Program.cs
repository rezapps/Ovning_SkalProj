using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("\nPlease navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice\n"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        CheckRecursive();
                        break;
                    case '6':
                        CheckInterative();
                        break;

                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nPlease enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        // Examines the datastructure List
        static void ExamineList()
        {
            List<string> list = new List<string>();

            while (true)
            {
                // string uInput = GetUserInput("\nEnter + to add, - to remove, or q to quit:\n");
                string uInput = " ";

                while (true)
                {
                    Console.WriteLine("\nEnter + to add, - to remove, or q to quit");
                    if (list.Capacity == 0){
                        Console.WriteLine("ex: +Adam or -Adam");
                    }

                    if (list.Count == list.Capacity)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Count: {list.Count}, Capacity: {list.Capacity}");
                        Console.ResetColor();
                        Console.WriteLine(" ");
                    }


                    string userInput = Console.ReadLine() ?? "";
                    if (userInput.Length > 1 || userInput == "q")
                    {
                        uInput = userInput;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }



                    switch (uInput[0])
                    {
                        case '+':
                            list.Add(uInput.Substring(1));
                            break;
                        case '-':
                            if (list.Remove(uInput.Substring(1)))
                            {
                                break;
                            }
                            Console.WriteLine("Element not found.");
                            break;
                        case 'q':
                            return;
                        default:
                            Console.WriteLine("Invalid operation.");
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Count: {list.Count}, Capacity: {list.Capacity}");
                    Console.ResetColor();
                }
            }
            /*
            1. Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar. 
            2. När ökar listans kapacitet?
                - Kapacitet är det "0" i början
                - man lägger till en element i listan
                - kapacitet ökar till 4 (2^2)
                - när man lägger 4 stycken i listan då är det full kapacitetet
                - när man lägger 5:te element i listan då ökar kapacitetet till 8 (2^3)	
                - när man lägger till 9:de stycken i listan då ökar kapacitet
                    till 16 (2^4) och den ökar enligt 2^x
            3. Med hur mycket ökar kapaciteten?
                - 2^x
            4. Varför ökar inte listans kapacitet i samma takt som element läggs till? 

            5. Minskar kapaciteten när element tas bort ur listan? 
                - Nej.
            6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista? 
                - när man vet array length från början
            */
        }


        // Examines the datastructure Queue
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        // Examines the datastructure Stack
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }


        static void CheckRecursive()
        {

        }

        static void CheckInterative()
        {

        }

    }
}

