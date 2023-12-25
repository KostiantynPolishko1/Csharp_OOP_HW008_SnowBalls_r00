using System.Diagnostics;
using SnowBalls.GameObjects;
using SnowBalls.Players;

namespace SnowBalls
{
    namespace Games
    {
        public class GameSnowBalls
        {
            private bool FlagMove;
            private GameField? Grid { get; set; }
            private PlayerPL? PlayerUser { get; set; }
            private PlayerPL? PlayerComp { get; set; }
            private PlayerBurst? Obj_PlayerBurst { get; set; }
            public GameSnowBalls()
            {
                Grid = new GameField();
                if (Grid != null)
                {
                    PlayerUser = new(Grid.SizeRow - 1, Grid.SizeCol / 2 - 1, 'u', ConsoleColor.DarkRed);
                    PlayerComp = new(0, Grid.SizeCol / 2 - 1, 'c', ConsoleColor.DarkYellow, false);
                    Obj_PlayerBurst = new(PlayerUser.Ball);

                    FlagMove = true;
                }
            }

            private void IsPlaying()
            {
                if (Grid is null)
                {
                    Console.WriteLine("\n\tERROR!");
                    Environment.Exit(0);
                }
            }

            private void ShowBlock(in int TimePausa, bool flag = false)
            {
                Grid.FillGrid(PlayerUser!);
                Grid.FillGrid(PlayerComp!);
                if (flag)
                {
                    Grid.FigureToGrid(Obj_PlayerBurst.BurstCoord, Obj_PlayerBurst.Symbol);
                }
                Grid.ShowGrid(PlayerUser!, PlayerComp!, Obj_PlayerBurst!);
                Thread.Sleep(TimePausa);
            }

            private int OffsetUser(ConsoleKeyInfo press)
            {
                if (press.Key == ConsoleKey.RightArrow) { return 1; }
                else if (press.Key == ConsoleKey.LeftArrow) { return -1; }
                return 0;
            }

            private int OffsetComp(in int IndexCol, in int LenPlate)
            {
                if (IndexCol == Grid.SizeCol - 1) { FlagMove = false; }
                else if (IndexCol == LenPlate - 1) { FlagMove = true; }

                if (FlagMove) { return 1; }
                else { return -1; }
            }

            private bool IsOpponent(in SnowBall Ball, in PlayerPL PlayerComp)
            {
                return Grid.GridField[Ball.PositionBall[0, 0], Ball.PositionBall[0, 1]] == PlayerComp.Figure_PL.S_FigurePL;
            }
            private void PushSnowBall(ConsoleKeyInfo press, in SnowBall Ball, in PlayerPL? PlayerComp)
            {
                int dxComp;
                int dy = Ball.PositionBall[0, 0] - 1 == 0 ? 1 : -1;
                int Limit = Ball.PositionBall[0, 0] - 1 == 0 ? Grid.SizeRow - 1 : 0;

                while (Ball.PositionBall[0, 0] != Limit)
                {
                    Console.Clear();
                    Ball.PositionBall[0, 0] += dy;
                    ShowBlock(10);

                    if (Ball.PositionBall[0, 0] == 0)
                    {
                        if (IsOpponent(Ball, PlayerComp))
                        {
                            Grid.ClearGrid();
                            Console.Clear();
                            this.PlayerComp.Figure_PL = null;
                            this.PlayerComp.Ball = null;
                            this.PlayerComp = null;

                            Obj_PlayerBurst.SetObjPosition(Ball);

                            ShowBlock(0, true);
                            Environment.Exit(0);
                        }
                    }

                    Grid.ClearGrid();

                    int count = 5;
                    while (count != 0)
                    {
                        Console.Clear();

                        dxComp = OffsetComp(PlayerComp.Figure_PL.Plate[PlayerComp.Figure_PL.Plate.GetLength(0) - 1, 1], PlayerComp.Figure_PL.Plate.GetLength(0));
                        PlayerComp.UpdatePosPlayer(dxComp, Grid.SizeCol);
                        count -= 1;

                        ShowBlock(3);
                        Grid.ClearGrid();
                    }

                }
            }

            public void ShowGame()
            {
                IsPlaying();
                ConsoleKeyInfo press;
                int dxUser;
                int dxComp;

                do
                {
                    ShowBlock(30);

                    press = Console.ReadKey();
                    if (press.Key == ConsoleKey.UpArrow || press.Key == ConsoleKey.DownArrow)
                    {
                        int Row_StartPos = PlayerUser.Ball.PositionBall[0, 0];

                        PushSnowBall(press, PlayerUser.Ball, PlayerComp);

                        PlayerUser.Ball.PositionBall[0, 0] = Row_StartPos;
                    }
                    else if (press.Key == ConsoleKey.LeftArrow || press.Key == ConsoleKey.RightArrow)
                    {
                        dxUser = OffsetUser(press);
                        PlayerUser.UpdatePosPlayer(dxUser, Grid.SizeCol);
                    }

                    dxComp = OffsetComp(PlayerComp.Figure_PL.Plate[PlayerComp.Figure_PL.Plate.GetLength(0) - 1, 1], PlayerComp.Figure_PL.Plate.GetLength(0));
                    PlayerComp.UpdatePosPlayer(dxComp, Grid.SizeCol);

                    Grid.ClearGrid();
                    Console.Clear();

                } while (press.Key != ConsoleKey.Escape);
            }

        }

    }
}
