namespace SnowBalls
{
    public class GameField
    {
        public readonly int SizeRow;
        public readonly int SizeCol;
        public char[,]? GridField { get; set; }
        private char SymGrid;
        public char Sym_Grid
        {
            get { return SymGrid; }
            set
            {
                SymGrid = GridField is not null ? value : '\0';
            }
        }

        private char SymDivide;
        public char Sym_Divide
        {
            get { return SymDivide; }
            set
            {
                SymDivide = GridField is not null ? value : '\0';
            }
        }

        public GameField() 
        {
            SizeRow = 7;
            SizeCol = 11;
            GridField = new char[SizeRow, SizeCol];
            SymGrid = '-';
            SymDivide = '.';

            if (GridField is not null)
            {
                for (int i = 0; i != SizeRow; i++)
                {
                    for(int j = 0; j != SizeCol; j++)
                    {
                        GridField[i, j] = SymGrid;
                    }
                }
            }
        }

        private static void BorderH(in int size)
        {
            for (int i = 0; i != size; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        private static void BorderV()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
        }

        public void ShowGrid()
        {
            BorderH(SizeCol + SizeCol + 5);
            for (int i = 0; i != SizeRow; i++)
            {
                BorderV();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write('.');
                for (int j = 0; j != SizeCol; j++)
                {
                    Console.Write($"{GridField[i, j]}.");
                }
                BorderV();
                Console.WriteLine();
            }
            BorderH(SizeCol + SizeCol + 5);
        }

        public void FillGrid(in PlayerPL? PlayerUser)
        {
            int size = PlayerUser is not null ? PlayerUser.Figure_PL.Plate.GetLength(0) : 0;
            char symbol = PlayerUser is not null ? PlayerUser.Figure_PL.S_FigurePL : '\0';

            for (int i = 0; i != size; i++)
            {
                int row = PlayerUser.Figure_PL.Plate[i, 0];
                int col = PlayerUser.Figure_PL.Plate[i, 1];

                GridField[row, col] = symbol;
            }
        }
    }
}
