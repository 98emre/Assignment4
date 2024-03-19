using System;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
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
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>

        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> list = new List<string>();
            bool running = true;

            while (running)
            {

                try
                {
                    Console.WriteLine("Use (+) for adding, (-) is for remove and (0) to exit ");

                    string input = Console.ReadLine()!;
                    char nav = input[0];
                    string value = input.Substring(1).Trim();


                    switch (nav)
                    {
                        case '+':

                            if (string.IsNullOrEmpty(value))
                            {
                                throw new ArgumentException("The input was invalid");
                            }

                            list.Add(value);
                            Console.WriteLine($"Capacity: {list.Capacity}, Count: {list.Count}");
                            break;

                        case '-':
                            if (list.Count == 0)
                            {
                                throw new ArgumentException("The list is empty");
                            }

                            list.Remove(value);
                            Console.WriteLine($"Capacity: {list.Capacity}, Count: {list.Count}");
                            break;


                        case '0':
                            Console.WriteLine("Existing the list session");
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }


        static string PrintTheQueue(Queue<string> queue)
        {
            if (queue.Count == 0)
            {
                return "Empty";
            }

            StringBuilder sb = new StringBuilder();

            foreach (string item in queue)
            {
                sb.Append(item);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2); // Ta bort sista kommatecknet och tomma ytan
            return sb.ToString();
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> queue = new Queue<string>();
            bool running = true;

            while (running)
            {
                try
                {
                    Console.WriteLine("\n0. Exit \n1. Enqueue\n2. Dequeue item");

                    Console.Write("Enter a number: ");
                    string input = Console.ReadLine()!.Trim();

                    switch (input)
                    {
                        case "0":
                            Console.WriteLine("Existing queue session");
                            running = false;
                            break;

                        case "1":
                            Console.Write("Enter a person: ");
                            string item = Console.ReadLine()!;

                            if (string.IsNullOrEmpty(item) || item.Trim().Length <= 0)
                            {
                                throw new ArgumentException("Entering was not valid");
                            }

                            queue.Enqueue(item);
                            Console.WriteLine($"{item} got enqueue.");
                            Console.WriteLine($"Current queue: {PrintTheQueue(queue)}");
                            break;

                        case "2":
                            string dequeueItem = queue.Dequeue();
                            Console.WriteLine($"\n{dequeueItem} got dequeue.");
                            Console.WriteLine($"Current queue: {PrintTheQueue(queue)}");
                            break;

                        default:
                            Console.WriteLine("Invalid input choose a number between 0-2");
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }
        }


        static string PrintTheStack( Stack<string> stack )
        {
            if(stack.Count == 0)
            {
                return "Empty";
            }

            StringBuilder sb = new StringBuilder();

            foreach( string item in stack)
            {
                sb.Append(item);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */


            Stack<string> stack = new Stack<string>();
            bool running = true;


            while (running)
            {
                try
                {
                    Console.WriteLine("\n0.Exit the stack \n1.Push \n2.Pop");
                    Console.Write("Choose a number: ");
                    string input = Console.ReadLine()!;

                    switch (input) 
                    {
                        case "0":
                            Console.WriteLine("Exit the stack system");
                            running = false;
                            break;

                        case "1":
                            Console.Write("Enter what you want to push: ");
                            string item = Console.ReadLine()!;


                            if(string.IsNullOrEmpty(item) || item.Trim().Length <= 0)
                            {
                                throw new ArgumentException("Entering was invalid");
                            }

                            string reversed = new string(item.Reverse().ToArray());
                            stack.Push(reversed);

                            Console.WriteLine($"You entered {item}, which was reversed to {reversed} and then got pushed to ");
                            break;

                        case "2":
                            if(stack.Count == 0)
                            {
                                throw new ArgumentException("The stack is empty");
                            }

                            string itemPop = stack.Pop();
                            Console.WriteLine($"Item got pop is {itemPop}");
                            Console.WriteLine($"Current Stack: {PrintTheStack(stack)}");
                            break;

                        default:
                            Console.WriteLine("Invalid input, try again and choose a number between 0-2");
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }

        }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Stack<char> stack = new Stack<char>();

            try
            {
                Console.Write("What do you want to enter: ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(input) || input.Trim().Length <= 0)
                {
                    throw new ArgumentException("You cannot enter an empty value.");
                }

                foreach (char c in input)
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        stack.Push(c);
                    }
                    else if (c == ')' || c == ']' || c == '}')
                    {
                        if ((c == ')' && stack.Pop() != '(') || (c == ']' && stack.Pop() != '[') || (c == '}' && stack.Pop() != '{'))
                        {
                            throw new ArgumentException("It is not well-formed");
                        }
                    }
                }

                Console.WriteLine(stack.Count == 0 ? "It is well-formed." : "It is not well-formeds");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

