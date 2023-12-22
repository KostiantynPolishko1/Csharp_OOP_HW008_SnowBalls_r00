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

        public GameField() 
        {
            SizeRow = 7;
            SizeCol = 21;
            GridField = new char[SizeRow, SizeCol];
            SymGrid = '-';
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

        private static void FillColorPlayer(in char SymbolGrid, in char SymbolPlayerUser)
        {
            Console.BackgroundColor = SymbolGrid == SymbolPlayerUser ? ConsoleColor.Red : ConsoleColor.Magenta;
            Console.Write($"{SymbolGrid}");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        public void ShowGrid(in PlayerPL? PlayerUser)
        {
            char SymbolPlayerlUser = PlayerUser is not null ? PlayerUser.Figure_PL.S_FigurePL : '\0';

            BorderH(SizeCol + 4);
            for (int i = 0; i != SizeRow; i++)
            {
                BorderV();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                for (int j = 0; j != SizeCol; j++)
                {
                    if(GridField[i, j] != '\0')
                    {
                        FillColorPlayer(GridField[i, j], SymbolPlayerlUser);
                        continue;
                    }                   
                    Console.Write(SymGrid);
                }
                BorderV();
                Console.WriteLine();
            }
            BorderH(SizeCol + 4);
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
