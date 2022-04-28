namespace HackMan.Scripts.Events
{
    public class GameOverEvent
    {
        public bool IsWinning { get;}

        public GameOverEvent(bool isWinning)
        {
            this.IsWinning = isWinning;
        }
    }
}