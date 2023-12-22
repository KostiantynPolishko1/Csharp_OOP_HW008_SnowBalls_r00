namespace SnowBalls
{
    public class PlayerPL
    {
        public FigurePL? Figure_PL {  get; set; }
        
        public PlayerPL(in int PosRow, in int PosCol, in char SymPlayer)
        {
            Figure_PL = new(PosRow, PosCol, SymPlayer);
        }
    }
}
