class Program
{
    static void Main()
    {

        try
        {
            int[,] grid = {
                { 12, 34, 56, 78, 90, 11, 23 },
                { 45, 67, 89, 10, 12, 34, 56 },
                { 21, 43, 65, 87, 09, 11, 13 },
                { 14, 26, 38, 49, 50, 62, 74 }
            };

            Console.WriteLine("Initial matrix:");
            DisplayMatrix(grid);

            Console.Write("\nSpecify the number of positions to shift: ");
            int offset = int.Parse(Console.ReadLine());

            Console.Write("Select the direction (1 - left, 2 - right): ");
            int shiftDirection = int.Parse(Console.ReadLine());

            ShiftAllRows(grid, offset, shiftDirection);

            Console.WriteLine("\nMatrix after shift:");
            DisplayMatrix(grid);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ShiftAllRows(int[,] grid, int offset, int direction)
    {
        int totalRows = grid.GetLength(0);
        int totalCols = grid.GetLength(1);

        offset = offset % totalCols;

        for (int row = 0; row < totalRows; row++)
        {
            ShiftSingleRow(grid, row, offset, direction, totalCols);
        }
    }

    static void ShiftSingleRow(int[,] grid, int row, int offset, int direction, int totalCols)
    {
        int[] newRow = new int[totalCols];

        if (direction == 1)
        {
            ShiftLeft(grid, row, offset, totalCols, newRow);
        }
        else
        {
            ShiftRight(grid, row, offset, totalCols, newRow);
        }

        for (int col = 0; col < totalCols; col++)
        {
            grid[row, col] = newRow[col];
        }
    }

    static void ShiftLeft(int[,] grid, int row, int offset, int totalCols, int[] newRow)
    {
        for (int col = 0; col < totalCols; col++)
        {
            newRow[col] = grid[row, (col + offset) % totalCols];
        }
    }
    static void ShiftRight(int[,] grid, int row, int offset, int totalCols, int[] newRow)
    {
        for (int col = 0; col < totalCols; col++)
        {
            newRow[col] = grid[row, (col - offset + totalCols) % totalCols];
        }
    }

    static void DisplayMatrix(int[,] grid)
    {
        int totalRows = grid.GetLength(0);
        int totalCols = grid.GetLength(1);

        for (int row = 0; row < totalRows; row++)
        {
            for (int col = 0; col < totalCols; col++)
            {
                Console.Write($"{grid[row, col],4}");
            }
            Console.WriteLine();
        }
    }
}
