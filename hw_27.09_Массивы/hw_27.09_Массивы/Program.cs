class Program
{
    static void Main()
    {
        try
        {
            int[] numbers = new int[10];
            Random random = new();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 6);
                Console.Write($"{numbers[i],3}");
            }

            Console.WriteLine("\n");

            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    numbers[counter] = numbers[i];
                    counter++;
                }
            }

            for (int i = counter; i < numbers.Length; i++)
            {
                numbers[i] = -1;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i],3}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
