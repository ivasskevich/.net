class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter text: ");
            string input = Console.ReadLine();

            string result = "";
            bool capitalizeNext = true;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (capitalizeNext && char.IsLetter(c))
                {
                    result += char.ToUpper(c);
                    capitalizeNext = false;
                }
                else
                {
                    result += c;
                }

                if (c == '.' || c == '!' || c == '?')
                {
                    capitalizeNext = true;
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
