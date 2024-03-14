﻿using System;

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
                string uInput = " ";

                while (true)
                {
                    Console.WriteLine("\nEnter + to add, - to remove, or q to quit");
                    if (list.Capacity == 0){
                        Console.WriteLine("ex: +Adam or -Adam");
                    }

                    if (list.Count == list.Capacity)
                    {
                        printColored($"Count: {list.Count}, Capacity: {list.Capacity}", "Cyan");
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

                    printColored($"Count: {list.Count}, Capacity: {list.Capacity}", "Green");
                }
            }
            /*
            1. Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar. 
            2. När ökar listans kapacitet?
                - Kapacitet är det "0" i början
                - man lägger till en element i listan
                - kapacitet ökar till 4 (2^2), om ingen initial kapacitet angiven
                - när man lägger 4 stycken i listan då är det full kapacitetet
                - när man lägger 5:te element i listan då ökar kapacitetet till 8 (2^3)	
                - när man lägger till 9:de stycken i listan då ökar kapacitet
                    till 16 (2^4) och den fördubblas eller 2^x när blir full kapacitetet
            3. Med hur mycket ökar kapaciteten?
                - 2^x
            4. Varför ökar inte listans kapacitet i samma takt som element läggs till? 
                - för att undvika att resize listan varje gång
            5. Minskar kapaciteten när element tas bort ur listan? 
                - Nej.
            6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista? 
                - när man vet array length från början
            */
        }


        // Examines the datastructure Queue
        static void ExamineQueue()
        {
            // int counter = 0;
            List<string> Customers = ["Adam", "Elsa", "Olle", "Greta", "Stina", "Kalle"];
            Queue<string> queue = new Queue<string>();
            while (true) {
                // Console.WriteLine("ICA opens: queue is empty");
                

                if (Customers.Count > 0 && queue.Count == 0)
                {
                    Console.WriteLine("\nEnter + to add one to queue, or q to quit\n");
                }
                else if (queue.Count > 0 && Customers.Count == 0)
                {
                    Console.WriteLine("\nEnter - to remove one, or q to quit\n");
                }
                else if (queue.Count == 0 && Customers.Count == 0)
                {
                    Console.WriteLine("\nGood Job, All customers served! Enter q to Exit\n");
                }
                else
                {
                    Console.WriteLine("\nEnter + to add one to queue, - to remove one, or q to quit\n");
                }

                string userInput = Console.ReadLine() ?? "";

                switch (userInput[0])
                {
                    case '+':
                        if (Customers.Count > 0)
                        {
                            queue.Enqueue(Customers[0]);
                            printColored($"{Customers[0]} is in the line\n", "Green");
                            Customers.RemoveAt(0);
                        }
                        else if ( Customers.Count == 0 && queue.Count == 0)
                        {
                            printColored("No customers in line, Good Job!\n", "Red");
                        }
                        else if (Customers.Count == 0 && queue.Count > 0)
                        {
                            printColored($"There are {queue.Count} customers waiting in line. Please serve them first!\n", "Red");
                        }
                        break;
                    case '-':
                        if (queue.Count == 0)
                        {
                            printColored("Queue is empty\n", "Red");
                        }
                        else
                        {
                            printColored($"{queue.Dequeue()} leaves the line\n", "Cyan");
                        }
                        break;
                    case 'q':
                        return;
                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }

            }

            /*
            source:
            https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-8.0#methods

            Enqueue:
            Adds an object to the end of the Queue<T>.

            Dequeue:
            Removes and returns the object at the beginning of the Queue<T>.

                +-------------------+
                |  Customer Arrives | 
                +-------------------+
                         |
                         |
                         V
           +--------------+-------------+
           | Is cashier serving anyone? | <--------
           +--------------+-------------+         |
             (NO)                (YES)            |
              |                    |              |
              |                    |              | 
              V                    V              |
        +-----------+         +--------------+    |
        |  Serve    |         | Wait in line |    |
        |  Dequeue  |         | Enqueue      |    |
        +-----------+         +--------------+    |                
             |                       |            |
             |                       |            |
             V                       |------------|
    +-------------------+
    |  Customer Leaves  |
    +-------------------+
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




        static void printColored(string msg, string clr)
        {
            switch(clr) {
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                
            }
            
            Console.WriteLine(msg);
            Console.ResetColor();
        }

    }
}

