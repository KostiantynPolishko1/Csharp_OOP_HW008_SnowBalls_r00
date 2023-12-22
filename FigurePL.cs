namespace SnowBalls
{
    public class FigurePL
    {
        public readonly char S_FigurePL;
        public int[,]? Plate { get; set; }
        public FigurePL(in int PosRow, in int PosCol, in char S_FigurePL) 
        {
            Plate = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 } };

            if(Plate is not null )
            {
                this.S_FigurePL = S_FigurePL;
                for (int i = 0; i != Plate.GetLength(0); i++)
                {
                    Plate[i, 0] += PosRow;
                    Plate[i, 1] += PosCol;
                }
            }
        }
    }
}
