using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceRoller.Classes.Tests
{
    [TestClass()]
    public class DiceResultTests
    {
        [TestMethod()]
        public void Rolld2Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d2
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 2);
            }
        }

        [TestMethod()]
        public void Rolld3Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d3
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 3);
            }
        }

        [TestMethod()]
        public void Rolld4Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d4
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 4);
            }
        }

        [TestMethod()]
        public void Rolld6Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d6
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 6);
            }
        }

        [TestMethod()]
        public void Rolld8Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d8
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 8);
            }
        }

        [TestMethod()]
        public void Rolld10Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d10
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 10);
            }
        }

        [TestMethod()]
        public void Rolld12Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d12
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 12);
            }
        }

        [TestMethod()]
        public void Rolld20Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d20
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 20);
            }
        }

        [TestMethod()]
        public void Rolld100Test()
        {
            //Arrange

            //Act
            DiceResult dr = new()
            {
                NumberThrown = 1,
                DieType = DieTypes.d100
            };
            dr.RollDice();

            //Assert
            Assert.AreEqual(dr.NumberThrown, dr.Results.Count);
            foreach (int result in dr.Results)
            {
                Assert.IsTrue(result >= 1 && result <= 100);
            }
        }

        [TestMethod()]
        public void RollAbilityScoresTest()
        {
            //Arrange

            //Act
            DiceResult dr = new();
            dr.RollAbilityScores();

            //Assert
            Assert.AreEqual(3, dr.Results.Count);
            
            Assert.IsTrue(dr.TotalResult >= 3 && dr.TotalResult <= 18);
            
        }
    }
}