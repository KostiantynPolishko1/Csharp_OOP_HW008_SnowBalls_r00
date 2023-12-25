using SnowBalls.GameObjects;

namespace SnowBalls
{
    namespace Players
    {
        public class PlayerBurst
        {
            public readonly char Symbol;
            public ConsoleColor Color { get; private set; }
            public int[,] BurstCoord { get; private set; }

            public PlayerBurst(in SnowBall? Obj_SnowBall)
            {
                if (Obj_SnowBall is not null)
                {
                    BurstCoord = new[,] { { 0, 1 }, { 1, 0 }, { 1, 1 }, { 1, 2 } };
                    Color = Obj_SnowBall.Color;
                    Symbol = 'x';
                }
            }

            public void SetObjPosition(in SnowBall? Obj_SnowBall)
            {
                if (Obj_SnowBall is not null)
                {
                    int dx = Obj_SnowBall.PositionBall[0, 1] - BurstCoord[0, 1];
                    for (int i = 0; i < BurstCoord.GetLength(0); i++)
                    {
                        BurstCoord[i, 1] += dx;
                    }
                }
            }

        }

    }
}
