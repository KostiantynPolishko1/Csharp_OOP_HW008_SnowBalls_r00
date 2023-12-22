namespace SnowBalls
{
    public class GameSnowBalls
    {
        private GameField Grid { get; set; }
        private PlayerPL? PlayerUser { get; set; }
        public GameSnowBalls() {
            Grid = new GameField();
            if(Grid != null)
            {
                PlayerUser = new(Grid.SizeRow - 1, (int)(Grid.SizeCol / 2) - 1, 'x');
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
            Grid.FillGrid(PlayerUser!);
            Grid.ShowGrid(PlayerUser!);
        }

    }
}
