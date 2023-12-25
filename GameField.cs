namespace SnowBalls
{
    public class GameField
    {
        public readonly int SizeRow;
        public readonly int SizeCol;
        public readonly ConsoleColor Color;
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
            Color = ConsoleColor.White;
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

        private void FillColor(in char SymbolGrid, in int Row, in int Col, in PlayerPL? PlayerUser, in PlayerPL? PlayerComp, in PlayerBurst? Obj_PlayerBurst)
        {
            char SymbolPlayer = PlayerUser is not null ? PlayerUser.Figure_PL.S_FigurePL : '\0';
            char SymbolComp = PlayerComp is not null ? PlayerComp.Figure_PL.S_FigurePL : '\0';

            if (SymbolGrid == SymbolPlayer) { Console.BackgroundColor = PlayerUser.Figure_PL.Color; }

            else if (SymbolGrid == SymbolComp) { Console.BackgroundColor = PlayerComp.Figure_PL.Color; }

            else if(SymbolGrid == 'x') { Console.BackgroundColor = Obj_PlayerBurst.Color; }

            else if (PlayerUser.Ball is not null && (Row == PlayerUser.Ball.PositionBall[0, 0] && Col == PlayerUser.Ball.PositionBall[0, 1]))
            { 
                Console.BackgroundColor = PlayerUser.Ball.Color; 
            }
            else if (PlayerComp is not null)
            {
                if (PlayerComp.Ball is not null && (Row == PlayerComp.Ball.PositionBall[0, 0] && Col == PlayerComp.Ball.PositionBall[0, 1]))
                {
                    Console.BackgroundColor = PlayerComp.Ball.Color;
                }
            }

            Console.Write($"{SymbolGrid}");
            Console.BackgroundColor = this.Color;
        }

        public void ShowGrid(in PlayerPL? PlayerUser, in PlayerPL? PlayerComp, in PlayerBurst Obj_PlayerBurst)
        {
            Console.ForegroundColor = ConsoleColor.White;
            BorderH(SizeCol + 4);
            for (int i = 0; i != SizeRow; i++)
            {
                BorderV();
                Console.BackgroundColor = this.Color;
                for (int j = 0; j != SizeCol; j++)
                {
                    if(GridField[i, j] != '\0')
                    {
                        FillColor(GridField[i, j], i, j, PlayerUser!, PlayerComp!, Obj_PlayerBurst!);
                        continue;
                    }                   
                    Console.Write(SymGrid);
                }
                BorderV();
                Console.WriteLine();
            }
            BorderH(SizeCol + 4);
        }

        public void FigureToGrid(in int[,]? Figure, in char symbol)
        {
            for (int i = 0; i != Figure.GetLength(0); i++)
            {
                GridField[Figure[i, 0], Figure[i, 1]] = symbol;
            }
        }

        public void FillGrid(in PlayerPL? Player)
        {
            if (Player is not null) 
            { 
                FigureToGrid(Player.Figure_PL.Plate, Player.Figure_PL.S_FigurePL);
                if (Player.Ball is not null) { FigureToGrid(Player.Ball.PositionBall, Player.Ball.SymbolBall); }
            }
        }

        public void ClearGrid()
        {
            Array.Clear(GridField);
        }
    }
}
