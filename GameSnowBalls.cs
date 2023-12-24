using System.Diagnostics;

namespace SnowBalls
{
    public class GameSnowBalls
    {
        private bool FlagMove;
        private GameField? Grid { get; set; }
        private PlayerPL? PlayerUser { get; set; }
        private PlayerPL? PlayerComp { get; set; }
        public GameSnowBalls() 
        {
            Grid = new GameField();
            if(Grid != null)
            {
                PlayerUser = new(Grid.SizeRow - 1, (int)(Grid.SizeCol / 2) - 1, 'u', ConsoleColor.DarkRed);
                PlayerComp = new(0, (int)(Grid.SizeCol / 2) - 1, 'c', ConsoleColor.DarkYellow, false);
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

        private void ShowBlock()
        {
            Grid.FillGrid(PlayerUser!);
            Grid.FillGrid(PlayerComp!);
            Grid.ShowGrid(PlayerUser!, PlayerComp!);
            Thread.Sleep(30);
        }

        private int OffsetUser(ConsoleKeyInfo press)
        {
            if (press.Key == ConsoleKey.RightArrow) { return 1; }
            else if (press.Key == ConsoleKey.LeftArrow) { return -1; }
            return 0;
        }

        private int OffsetComp(in int IndexCol, in int LenPlate)
        {
            if (IndexCol == Grid.SizeCol-1) { FlagMove = false; }
            else if(IndexCol == LenPlate - 1) { FlagMove = true; }

            if (FlagMove) { return 1; }
            else { return -1; }
        }

        private void PushSnowBall(ConsoleKeyInfo press, in SnowBall Ball)
        {
            int Row_StartPos = Ball.PositionBall[0, 0];
            int dy = Ball.PositionBall[0, 0] - 1 == 0 ? 1 : -1;
            int Limit = Ball.PositionBall[0, 0] - 1 == 0 ? Grid.SizeRow - 1 : 0;

            while (Ball.PositionBall[0, 0] != Limit)
            {
                Console.Clear();
                Ball.PositionBall[0, 0] += dy;
                ShowBlock();
                Grid.ClearGrid();

            }

            Ball.PositionBall[0, 0] = Row_StartPos;
        }

        public void ShowGame()
        {
            IsPlaying();
            ConsoleKeyInfo press;
            int dxUser;
            int dxComp;

            do
            {
                ShowBlock();
                
                press = Console.ReadKey();
                if(press.Key == ConsoleKey.UpArrow || press.Key == ConsoleKey.DownArrow)
                {
                    PushSnowBall(press, PlayerUser.Ball);
                }
                else if(press.Key == ConsoleKey.LeftArrow || press.Key == ConsoleKey.RightArrow)
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
