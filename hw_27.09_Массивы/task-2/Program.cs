class Program
{
    static void Main()
    {
        try
        {
            int size = 7;

            if (size % 2 == 0)
            {
                Console.WriteLine("Size of the matrix must be odd");
                return;
            }

            int[,] grid = new int[size, size];

            int centerX = size / 2;
            int centerY = size / 2;

            grid[centerX, centerY] = 1;
            int currentValue = 2;

            int[] horizontalShift = { -1, 0, 1, 0 };
            int[] verticalShift = { 0, 1, 0, -1 };

            int moveLength = 1;
            int currentDirection = 0;

            while (currentValue <= size * size)
            {
                for (int round = 0; round < 2; round++)
                {
                    for (int step = 0; step < moveLength; step++)
                    {
                        centerX += horizontalShift[currentDirection];
                        centerY += verticalShift[currentDirection];

                        if (IsValidPosition(centerX, centerY, size))
                        {
                            grid[centerX, centerY] = currentValue++;
                        }
                    }

                    currentDirection = (currentDirection + 1) % 4;
                }

                moveLength++;
            }

            DisplayMatrix(grid);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static bool IsValidPosition(int x, int y, int n)
    {
        return x >= 0 && x < n && y >= 0 && y < n;
    }
    static void DisplayMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],3}");
            }
            Console.WriteLine();
        }
    }
}
