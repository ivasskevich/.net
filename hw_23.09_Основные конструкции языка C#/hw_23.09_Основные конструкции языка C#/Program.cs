class SimpleProgram
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            Console.WriteLine("Перше завдання: Перевірка на паліндром");
            Console.Write("Введіть слово або число: ");
            string original = Console.ReadLine();

            string reversed = "";
            for (int i = original.Length - 1; i >= 0; i--)
            {
                reversed += original[i];
            }

            if (original == reversed)
            {
                Console.WriteLine($"{original} є паліндромом.");
            }
            else
            {
                Console.WriteLine($"{original} не є паліндромом.");
            }

            //==============

            Console.WriteLine("Друге завдання: Зсув числа");
            Console.Write("Введіть число для зсуву: ");
            string number = Console.ReadLine();

            Console.Write("На скільки символів зсунути? ");
            int shift = int.Parse(Console.ReadLine());

            Console.Write("Виберіть напрямок зсуву: ліво (писати л), право (писати п): ");
            string direction = Console.ReadLine();

            string shiftedNumber = "";

            if (direction == "л")
            {
                string leftPart = number.Substring(shift);
                string rightPart = number.Substring(0, shift);
                shiftedNumber = leftPart + rightPart;
            }
            else if (direction == "п")
            {
                string leftPart = number.Substring(number.Length - shift);
                string rightPart = number.Substring(0, number.Length - shift);
                shiftedNumber = leftPart + rightPart;
            }
            else
            {
                shiftedNumber = "Невірний напрямок зсуву.";
            }

            Console.WriteLine($"Результат зсуву: {shiftedNumber}");

            //==============

            Console.WriteLine("Третє завдання: Знаходження максимальної послідовності");
            Console.WriteLine("Введіть 15 чисел:");

            int previous = int.MinValue;
            int currentLength = 0;
            int maxLength = 0;
            int startingPosition = 0;
            int bestStartingPosition = 0;

            for (int i = 1; i <= 15; i++)
            {
                Console.Write($"Число {i}: ");
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber >= previous)
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        bestStartingPosition = startingPosition;
                    }
                    currentLength = 1;
                    startingPosition = i - 1;
                }

                previous = currentNumber;
            }

            Console.WriteLine($"Максимальна довжина зростаючої послідовності: {maxLength}");
            Console.WriteLine($"Послідовність починається з числа під номером: {bestStartingPosition + 1}");

        }
        catch (Exception e)
        {
            Console.WriteLine($"Сталася помилка: {e.Message}");
        }
    }
}
