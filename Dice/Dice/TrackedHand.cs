namespace Dice
{
    internal class TrackedHand
    {
        public string Name { get; private set; }
        public int Score { get; set; }

        public TrackedHand(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
