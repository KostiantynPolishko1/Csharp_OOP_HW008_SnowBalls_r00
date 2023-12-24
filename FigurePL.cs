namespace SnowBalls
{
    public class FigurePL
    {
        public readonly char S_FigurePL;
        public readonly ConsoleColor Color;
        public int[,] Plate { get; set; }
        public FigurePL(in int PosRow, in int PosCol, in char S_FigurePL, in ConsoleColor Color) 
        {
            Plate = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 } };

            if(Plate is not null )
            {
                this.S_FigurePL = S_FigurePL;
                this.Color = Color;
                SetPosition( PosRow, PosCol );
            }
        }

        public void SetPosition(in int dy, in int dx)
        {
            for (int i = 0; i != Plate.GetLength(0); i++)
            {
                Plate[i, 0] += dy;
                Plate[i, 1] += dx;
            }
        }

/*        public void UpdatePosition(in int dx, in int SizeCol)
        {
            bool flag = false;
            if(dx == 1) { flag = Plate[Plate.GetLength(0)-1,1] + dx != SizeCol ? true : false; }
            else { flag = Plate[0, 1] + dx != -1 ? true : false; }

            if (flag) { SetPosition(0, dx); }
        }*/
    }
}
