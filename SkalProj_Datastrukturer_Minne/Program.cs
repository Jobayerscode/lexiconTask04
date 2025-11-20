using System;

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

        // Reads a command like "+Adam", "-Greta"  and returns (key, rest)
        static (char key, string text) ReadCommand(string prompt = "> ")
        {
            while (true)
            {
                Console.Write(prompt);
                string? line = Console.ReadLine(); 
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                line = line.Trim();
                char key = line[0];
                string text = line.Length > 1 ? line.Substring(1).Trim() : string.Empty;
                return (key, text);
            }
        }

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

        static void ExamineList()
                    {
            /*
             Controls:
             +Name  -> add "Name"
             -Name  -> remove "Name"
             ?      -> print current items
             x      -> exit to main menu
             */
            var theList = new List<string>();
            Console.WriteLine("List examiner. Use +Name to add, -Name to remove, ? to show, x to exit.");

            while (true)
            {
                var (key, text) = ReadCommand();

                switch (char.ToLowerInvariant(key))
                {
                    case 'x':
                        return;

                    case '?':
                        PrintList(theList);
                        break;

                    case '+':
                        AddToList(theList, text);
                        break;

                    case '-':
                        RemoveFromList(theList, text);
                        break;

                    default:
                        Console.WriteLine("Use +Name to add, -Name to remove, ? to show, x to exit.");
                        break;
                }
            }
        }

        static void AddToList(List<string> list, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Provide a value after '+' (e.g., +Adam)");
                return;
            }

            list.Add(value);
            Console.WriteLine($"Added \"{value}\". Count={list.Count}");
        }

        static void RemoveFromList(List<string> list, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Provide a value after '-' (e.g., -Adam)");
                return;
            }

            bool removed = list.Remove(value);
            string msg = removed ? $"Removed \"{value}\"." : $"\"{value}\" not found.";
            Console.WriteLine($"{msg} Count={list.Count}");
        }

        static void PrintList(List<string> list)
        {
            Console.WriteLine($"Items (Count={list.Count}):");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"  [{i}] {list[i]}");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */

        static void ExamineQueue()
                {
            /*
             Controls:
             +Name -> enqueue
             -     -> dequeue
             ?     -> show
             x     -> exit
             */
            var queue = new Queue<string>();
            Console.WriteLine("Queue examiner (FIFO). Use +Name to enqueue, - to dequeue, ? to show, x to exit.");

            while (true)
            {
                var (key, text) = ReadCommand();

                switch (char.ToLowerInvariant(key))
                {
                    case 'x':
                        return;

                    case '?':
                        PrintQueue(queue);
                        break;

                    case '+':
                        Enqueue(queue, text);
                        break;

                    case '-':
                        Dequeue(queue);
                        break;

                    default:
                        Console.WriteLine("Use +Name (enqueue), - (dequeue), ? (show), x (exit).");
                        break;
                }
            }
        }

        static void Enqueue(Queue<string> queue, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Provide a value after '+' (e.g., +Kalle)");
                return;
            }

            queue.Enqueue(value);
            Console.WriteLine($"Enqueued \"{value}\". Count={queue.Count}");
        }

        static void Dequeue(Queue<string> queue)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            string item = queue.Dequeue();
            Console.WriteLine($"Dequeued \"{item}\". Count={queue.Count}");
        }

        static void PrintQueue(Queue<string> queue)
        {
            Console.WriteLine($"Queue (Count={queue.Count}):");
            foreach (var item in queue)
                Console.WriteLine($"  {item}");
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
        */
        static void ExamineStack()
        {
            /*
             Controls:
             +Text -> push
             -     -> pop
             r     -> reverse text (reads a new line to reverse)
             ?     -> show
             x     -> exit
             */
            var stack = new Stack<string>();
            Console.WriteLine("Stack examiner (LIFO). Use +Text to push, - to pop, r to reverse text, ? to show, x to exit.");

            while (true)
            {
                var (key, text) = ReadCommand();

                switch (char.ToLowerInvariant(key))
                {
                    case 'x':
                        return;

                    case '?':
                        PrintStack(stack);
                        break;

                    case '+':
                        Push(stack, text);
                        break;

                    case '-':
                        Pop(stack);
                        break;

                    case 'r':
                        ReverseTextInteractive();
                        break;

                    default:
                        Console.WriteLine("Use +Text (push), - (pop), r (reverse), ? (show), x (exit).");
                        break;
                }
            }
        }

        static void Push(Stack<string> stack, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Provide a value after '+' (e.g., +Greta)");
                return;
            }

            stack.Push(value);
            Console.WriteLine($"Pushed \"{value}\". Count={stack.Count}");
        }

        static void Pop(Stack<string> stack)
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }

            string item = stack.Pop();
            Console.WriteLine($"Popped \"{item}\". Count={stack.Count}");
        }

        static void ReverseTextInteractive()
        {
            Console.Write("Enter text to reverse: ");
            string input = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Reversed: {ReverseWithStack(input)}");
        }

        static string ReverseWithStack(string text)
        {
            var chars = new Stack<char>();
            foreach (char c in text)
                chars.Push(c);

            var buffer = new char[chars.Count];
            int i = 0;
            while (chars.Count > 0)
                buffer[i++] = chars.Pop();

            return new string(buffer);
        }

        static void PrintStack(Stack<string> stack)
        {
            Console.WriteLine($"Stack top->bottom (Count={stack.Count}):");
            foreach (var item in stack)
                Console.WriteLine($"  {item}");
        }


        /*
            * Use this method to check if the paranthesis in a string is Correct or incorrect.
            * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
            * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
        */

        static void CheckParanthesis()
        {
            while (true)
            {
                Console.WriteLine("Enter a string to validate parentheses (or 'x' to return to main menu):");
                Console.Write("> ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.Length == 1 && (input[0] == 'x' || input[0] == 'X'))
                    return;

                var (ok, error) = ValidateBrackets(input);

                if (ok)
                    Console.WriteLine("Balanced.");
                else
                    Console.WriteLine($"Not balanced: {error}");

                Console.WriteLine();
            }
        }


        /*
            The stack tracks outstanding opening brackets in the exact order they must be closed, 
            turning correct parentheses checking into a single, 
            straightforward pass with simple push/pop operations
        */

        static (bool ok, string? error) ValidateBrackets(string s)
        {
            var expect = new Dictionary<char, char>
            {
                [')'] = '(',
                ['}'] = '{',
                [']'] = '['
            };

            var opens = new HashSet<char>(expect.Values);
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (opens.Contains(c))
                {
                    stack.Push(c);
                    continue;
                }

                if (expect.ContainsKey(c))
                {
                    if (stack.Count == 0)
                        return (false, $"Unexpected closing '{c}' at index {i}");

                    char open = stack.Pop();
                    if (open != expect[c])
                        return (false, $"Mismatched '{open}' with '{c}' at index {i}");
                }
            }

            if (stack.Count > 0)
                return (false, $"Unclosed opening '{stack.Peek()}' remaining");

            return (true, null);
        }
    }
}

