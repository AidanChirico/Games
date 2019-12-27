namespace Dice
{
    internal class TrackedDice
    {
        public int Value { get; set; }
        public bool Keep { get; set; }

        public TrackedDice(int value)
        {
            Value = value;
        }
    }
}
