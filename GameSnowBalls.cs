namespace SnowBalls
{
    public class GameSnowBalls
    {
        private int dx { get; set; }
        private GameField? Grid { get; set; }
        private PlayerPL? PlayerUser { get; set; }
        public GameSnowBalls() 
        {
            Grid = new GameField();
            if(Grid != null)
            {
                PlayerUser = new(Grid.SizeRow - 1, (int)(Grid.SizeCol / 2) - 1, 'u');
                dx = 0;
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

        public void ShowGame()
        {
            IsPlaying();
            ConsoleKeyInfo press;

            do
            {
                Grid.FillGrid(PlayerUser!);
                Grid.ShowGrid(PlayerUser!);

                press = Console.ReadKey();
                if(press.Key == ConsoleKey.RightArrow) { dx = 1; }
                else if(press.Key == ConsoleKey.LeftArrow) { dx = -1; }

                PlayerUser.Figure_PL.UpdatePosition(dx, Grid.SizeCol);
                Grid.ClearGrid();
                Console.Clear();

            } while (press.Key != ConsoleKey.Escape);
        }

    }
}
