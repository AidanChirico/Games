using Dice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YathzeeHandTest
{
    [TestClass]
    public class HandsTesting
    {
        [TestMethod]
        [DataRow(3, 0, 1, 2, 3, 4, 5)] //No match
        [DataRow(3, 7, 1, 1, 1, 2, 2)] //At start of data match
        [DataRow(3, 7, 2, 2, 1, 1, 1)] //At end of data match
        [DataRow(3, 7, 1, 2, 1, 2, 1)] //Scattered data match
        [DataRow(3, 6, 1, 1, 1, 1, 2)] //Four of A Kind data match
        [DataRow(4, 6, 1, 1, 1, 1, 2)] //At start of data match
        [DataRow(4, 6, 2, 1, 1, 1, 1)] //At end of data match
        [DataRow(4, 6, 1, 2, 1, 1, 1)] //Scattered data match
        public void XOfAKind_Test(int expectedLength, int expectedScore, params int[] dice)
        {
            var xOfAKind = new XOfAKind(expectedLength);
            int score = xOfAKind.DetectHand(dice);

            Assert.AreEqual(expectedScore, score);
        }
        
        [TestMethod]
        [DataRow(0, 1, 2, 3, 4, 5)] //No match
        [DataRow(50, 1, 1, 1, 1, 1)] //Match

        public void Yahtzee_Test(int expectedScore, params int[] dice)
        {
            var Yahtzee = new Yahtzee();
            int score = Yahtzee.DetectHand(dice);

            Assert.AreEqual(expectedScore, score);
        }

        [TestMethod]
        [DataRow(0, 1, 1, 2, 2, 3)] //No match
        [DataRow(25, 1, 1, 1, 2, 2)] //Ordered Full House
        [DataRow(25, 2, 2, 1, 1, 1)] //Reverse Full House
        [DataRow(25, 1, 2, 2, 1, 1)] //Unordered Full House
        public void FullHouse_Test(int expectedScore, params int[] dice)
        {
            var fullHouse = new FullHouse();
            int score = fullHouse.DetectHand(dice);

            Assert.AreEqual(expectedScore, score);
        }

        [TestMethod]
        [DataRow(4, 0, 1, 2, 2, 4, 4)] //No match
        [DataRow(4, 30, 1, 2, 3, 4, 4)] //Straight Length of 4 (start, ordered)
        [DataRow(5, 40, 1, 2, 3, 4, 5)] //Straight Length of 5 (ordered)
        [DataRow(4, 30, 1, 3, 2, 4, 6)] //Straight Length of 4 (shuffeled)
        [DataRow(4, 30, 1, 2, 3, 3, 4)] //Straight Length of 4 (ordered, pair mid)
        [DataRow(5, 40, 5, 4, 3, 2, 1)] //Straight Length of 5 (reverse)
        public void Straight_Test(int expectedLenght, int expectedScore, params int[] dice)
        {
            var straight = new Straight(expectedLenght);
            int score = straight.DetectHand(dice);

            Assert.AreEqual(expectedScore, score);
        }

        [TestMethod]
        [DataRow(1, 4, 1, 1, 1, 1, 2)] //Ones (four match, ordered)
        [DataRow(1, 4, 1, 1, 1, 2, 1)] //Ones (four match, unordered)
        [DataRow(2, 8, 2, 2, 2, 2, 1)] //Twos (four match, ordered)
        [DataRow(3, 12, 3, 3, 3, 3, 1)] //Threes (four match, ordered)
        [DataRow(4, 16, 4, 4, 4, 4, 1)] //Fours (four match, ordered)
        [DataRow(5, 20, 5, 5, 5, 5, 1)] //Fives (four match, ordered)
        [DataRow(6, 24, 6, 6, 6, 6, 1)] //Sixes (four match, ordered)
        public void LikeFaces_Test(int face, int expectedScore, params int[] dice)
        {
            var likeFaces = new LikeFaces(face);
            int score = likeFaces.DetectHand(dice);

            Assert.AreEqual(expectedScore, score);
        }

        [TestMethod]
        [DataRow(16, 5, 5, 2, 1, 3)]
        public void Chance_Test(int expectedScore, params int[] dice)
        {
            var chance = new Chance();
            int score = chance.DetectHand(dice);

            Assert.AreEqual(expectedScore, score);
        }
    }
}
