using SnowBalls.GameObjects;

namespace SnowBalls
{
    namespace Players
    {
        public class PlayerPL
        {
            public FigurePL? Figure_PL { get; set; }
            public SnowBall? Ball { get; set; }

            public PlayerPL(in int PosRow, in int PosCol, in char Symbol, ConsoleColor Color, bool flag = true)
            {
                Figure_PL = new(PosRow, PosCol, Symbol, Color);
                Ball = flag ? new(Figure_PL, '*', ConsoleColor.DarkBlue) : null;
            }

            public void UpdatePosPlayer(in int dx, in int SizeCol)
            {
                bool flag = false;
                if (dx == 1) { flag = Figure_PL.Plate[Figure_PL.Plate.GetLength(0) - 1, 1] + dx != SizeCol ? true : false; }
                else { flag = Figure_PL.Plate[0, 1] + dx != -1 ? true : false; }

                if (flag)
                {
                    Figure_PL.SetPosition(0, dx);
                    if (Ball is not null) { Ball.SetPosition(0, dx); }
                }
            }
        }

    }
}
