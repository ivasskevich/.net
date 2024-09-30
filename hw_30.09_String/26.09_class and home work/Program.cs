class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter an arithmetic expression (only with + and - operations): ");
            string input = Console.ReadLine();

            input = input.Replace(" ", "");

            int result = 0;
            int currentNumber = 0;
            char operation = '+';

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsDigit(c))
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                }

                if (!char.IsDigit(c) || i == input.Length - 1)
                {
                    if (operation == '+')
                    {
                        result += currentNumber;
                    }
                    else if (operation == '-')
                    {
                        result -= currentNumber;
                    }

                    operation = c;
                    currentNumber = 0;
                }
            }

            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
