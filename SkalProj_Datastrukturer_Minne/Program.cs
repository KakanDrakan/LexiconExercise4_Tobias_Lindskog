using System;

namespace SkalProj_Datastrukturer_Minne;

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
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
                + "\n5. ReverseText"
                + "\n6. RecursiveEven"
                + "\n7. RecursiveFibonacci"
                + "\n8. IterativeEven"
                + "\n9. IterativeFibonacci"
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
                case '5':
                    ReverseText();
                    break;
                case '6':
                    RecursiveEven();
                    break;
                case '7':
                    RecursiveFibonacci();
                    break;
                case '8':
                    IterativeEven();
                    break;
                case '9':
                    IterativeFibonacci();
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

    //Capacity börjar på 4 och dubbleras när det 5:e elementet läggs till. Den fortsätter dubbleras när capacity fulls upp.
    //Capacity blir aldrig lägre när man tar bort elements.
    //Att ändra capacity är (relativt) långsamt så det görs inte på varje add/remove för optimerings skull.
    //En array är alltid bäst att använda när man vet exakt hur många element som ska finnas i den. När performance är kritiskt är det också bättre med en array.
    static void ExamineList()
    {
        bool isAlive = true;
        Console.Write($"Input 0 to go back to main menu{Environment.NewLine}" +
                "Input +/- followed by the item to be added/removed: ");
        var listToExamine = new List<string>();

        do
        {
            string input = Console.ReadLine();
            char firstChar = input[0];
            switch (firstChar)
            {
                case '+':
                    listToExamine.Add(input.Substring(1));
                    Console.WriteLine("Count: " + listToExamine.Count);
                    Console.WriteLine("Capacity: " + listToExamine.Capacity);
                    break;
                case '-':
                    listToExamine.Remove(input.Substring(1));
                    Console.WriteLine("Count: " + listToExamine.Count);
                    Console.WriteLine("Capacity: " + listToExamine.Capacity);
                    break;
                case '0':
                    isAlive = false;
                    break;
                default:
                    Console.Write("Please enter valid input + or - followed by the item to be added or removed: ");
                    break;
            }

        } while (isAlive);

    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    static void ExamineQueue()
    {
        bool isAlive = true;
        Console.Write($"Input 0 to go back to main menu{Environment.NewLine}" +
                "Input +/- followed by the item to be added/popped from stack: ");
        var queueToExamine = new Queue<string>();

        do
        {
            string input = Console.ReadLine();
            char firstChar = input[0];
            switch (firstChar)
            {
                case '+':
                    queueToExamine.Enqueue(input.Substring(1));
                    foreach (var item in queueToExamine) Console.WriteLine(item);
                    break;
                case '-':
                    if (queueToExamine.TryDequeue(out var x))
                    {
                        foreach (var item in queueToExamine) Console.WriteLine(item);
                    }
                    else Console.WriteLine("Queue is already empty!");
                    break;
                case '0':
                    isAlive = false;
                    break;
                default:
                    Console.Write("Please enter valid input + followed by the item to be added, or -: ");
                    break;
            }

        } while (isAlive);

    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>

    //Att simulera en ICA-kö med en stack är inte så bra eftersom vi anser att köer är rättvisa om de är FIFO, inte FILO, som stacks är.
    //Den som ställer sig i kön först hade kanske fått stå där hela dagen!!!
    //Att ändå använda stacks för att simulera hur riktiga köer fungerar är tekniskt sett möjligt genom att t.ex flytta över alla element i ena stacken
    //till en ny stack (som då blir omvänd ordning), ta bort ett element, och sedan flytta tillbaka, men då förlorar man ju poängen med stacks
    static void ExamineStack()
    {
        bool isAlive = true;
        Console.Write($"Input 0 to go back to main menu{Environment.NewLine}" +
                "Input + followed by an item add it, or input - to pop it from stack: ");
        var stackToExamine = new Stack<string>();
        do
        {
            string input = Console.ReadLine();
            char firstChar = input[0];
            switch (firstChar)
            {
                case '+':
                    stackToExamine.Push(input.Substring(1));
                    foreach (var item in stackToExamine) Console.WriteLine(item);
                    break;
                case '-':
                    if (stackToExamine.TryPop(out var x))
                    {
                        foreach (var item in stackToExamine) Console.WriteLine(item);
                    }
                    else Console.WriteLine("Stack is already empty!");
                    break;
                case '0':
                    isAlive = false;
                    break;
                default:
                    Console.Write("Please enter valid input + followed by the item to be added, or -: ");
                    break;
            }

        } while (isAlive);

    }

    static void ReverseText()
    {
        Console.Write("Input a string to reverse: ");
        var input = Console.ReadLine();
        var stack = new Stack<char>();
        foreach (char ch in input) stack.Push(ch);
        Console.WriteLine(String.Concat(stack));
    }

    //We will iterate thorugh the inputted string and check for every char if it's a parenthesis.
    //The idea is to use a stack to keep track of the current most recent opening parenthesis that has not yet been paired with a matching closing parenthesis
    //When we find an opening parenthesis it's pushed to the stack, so it's now on top of the stack.
    //We pop the stack when we find a closing parenthesis that matches the top of the stack, because it has now been paired.
    //If we find a closing parenthesis that does not match the parenthesis at the top of the stack, that means parentheses are incorrect
    static void CheckParanthesis()
    {
        Console.Write("Input a string to check if parentheses are correct: ");
        string input = Console.ReadLine();
        Stack<char> stack = new Stack<char>();
        
        var parenthesisPairs = new Dictionary<char, char>() //using a dictionary to keep track of pairs
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        bool isCorrect = true; //we set this to false if it turns out a parenthesis is unpaired
        foreach (char ch in input)
        {
            if (parenthesisPairs.ContainsKey(ch))
            {
                //we push the opening parenthesis onto the stack because the most recent one must be paired with a closing parenthesis before those under it are
                stack.Push(ch);
            }
            if (parenthesisPairs.ContainsValue(ch)) 
            {
                if (stack.Count != 0 && parenthesisPairs[stack.Peek()] == ch) stack.Pop();  //we pop the stack because the first parenthesis in it has been paired
                else { isCorrect = false; break; }                      //or we stop the loop because we have confirmed the string is incorrect
            }
        }
        if (isCorrect) Console.WriteLine("Correct parenthesis");
        else Console.WriteLine("Incorrect parenthesis");

    }

    static void RecursiveEven()
    {
        Console.Write("Input n to get n:th even number: ");
        bool success = false;
        do
        {
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                success = true;
                Console.WriteLine(GetNthEven(n));
            }

        } while (!success);

        static int GetNthEven(int n)
        {
            if (n == 0) return 0;
            return (GetNthEven(n - 1) + 2);
        }
    }
    static void RecursiveFibonacci()
    {
        Console.Write("Input n to get n:th fibonacci number: ");
        bool success = false;
        do
        {
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                success = true;
                Console.WriteLine(GetNthFibonacci(n));
            }

        } while (!success);

        static int GetNthFibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return (GetNthFibonacci(n - 1) + (GetNthFibonacci(n - 2)));
        }
    }

    static void IterativeEven()
    {
        Console.Write("Input n to get the n:th even number: ");
        bool success = false;
        do
        {
            if(int.TryParse(Console.ReadLine(), out var n))
            {
                success = true;
                Console.WriteLine(GetNthEven(n));
            }

        } while (!success);

        

        static int GetNthEven(int n)
        {
            int res = 0;
            for (int i = 0; i < n; i++) res += 2;
            return res;
        }

    }

    
    //Att iterativt beräkna något är nästan alltid (alltid?) mer effektivt än att göra det rekursivt.
    //De rekursiva funktionerna behöver lägga mer och mer på stacken, men det behöver inte de iterativa.
    //En rekursiv funktion kallar på sig själv flera gånger, vilket innebär att stacken inte tar bort data förs den är helt klar (risk för stack overflow).
    static void IterativeFibonacci()
    {
        Console.Write("Input n to get the n:th fibonacci number: ");
        bool success = false;
        do
        {
            if (int.TryParse(Console.ReadLine(), out var n))
            {
                success = true;
                Console.WriteLine(GetNthFibonacci(n));
            }

        } while (!success);

        static int GetNthFibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int newRes = 1;
            int res = 0;
            int lastRes = 0;
            for (int i = 1; i < n; i++)
            {
                res = lastRes + newRes;
                lastRes = newRes;
                newRes = res;
            }
            return res;
        }
    }
}

