namespace SnowBalls
{
    public class GameSnowBalls
    {
        private int dxUser { get; set; }
        private int dxComp { get; set; }
        private GameField? Grid { get; set; }
        private PlayerPL? PlayerUser { get; set; }
        private PlayerPL? PlayerComp { get; set; }
        public GameSnowBalls() 
        {
            Grid = new GameField();
            if(Grid != null)
            {
                PlayerUser = new(Grid.SizeRow - 1, (int)(Grid.SizeCol / 2) - 1, 'u');
                PlayerComp = new(0, (int)(Grid.SizeCol / 2) - 1, 'c');
                dxUser = 0;
                dxComp = 0;
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

        private int OffsetUser(ConsoleKeyInfo press)
        {
            if (press.Key == ConsoleKey.RightArrow) { return 1; }
            else if (press.Key == ConsoleKey.LeftArrow) { return -1; }
            return 0;
        }

        public void ShowGame()
        {
            IsPlaying();
            ConsoleKeyInfo press;

            do
            {
                Grid.FillGrid(PlayerUser!);
                Grid.FillGrid(PlayerComp!);
                Grid.ShowGrid(PlayerUser!);

                press = Console.ReadKey();
                dxUser = OffsetUser(press);

                PlayerUser.Figure_PL.UpdatePosition(dxUser, Grid.SizeCol);
                Grid.ClearGrid();
                Console.Clear();

            } while (press.Key != ConsoleKey.Escape);
        }

    }
}
