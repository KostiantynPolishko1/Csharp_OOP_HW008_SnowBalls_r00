namespace SnowBalls
{
    public class SnowBall
    {
        public readonly char SymbolBall;
        public readonly ConsoleColor Color;
        public int[,] PositionBall { get; set; }

        public SnowBall(in FigurePL Figure_PL, in char SymbolBall, in ConsoleColor Color)
        {
            this.SymbolBall = SymbolBall;

            PositionBall = new int[1, 2];
           
            PositionBall[0, 0] = Figure_PL.Plate[1, 0] != 0 ? Figure_PL.Plate[1, 0] - 1 : Figure_PL.Plate[1, 0] + 1; //position related to Row
            PositionBall[0, 1] = Figure_PL.Plate[1, 1]; //position related to Column
            this.Color = Color;
        }

        public void SetPosition(in int dy, in int dx)
        {
            PositionBall[0, 0] += dy;
            PositionBall[0, 1] += dx;
        }
    }
}
