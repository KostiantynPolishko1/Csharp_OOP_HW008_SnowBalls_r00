namespace SnowBalls
{
    public class GameSnowBalls
    {
        private GameField Grid { get; set; }
        public GameSnowBalls() {
            Grid = new GameField();
        }

        public void ShowGame()
        {
            if (Grid is null) { Environment.Exit(0); }
            Grid.ShowGrid();
        }
    }
}
