using NUnit.Framework;

using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class RandomPlayerHelperTests
    {
        [Test]
        public void RandomPlayerHelper_GetAbilityValue_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(2);

            // Act
            var result = RandomPlayerHelper.GetAbilityValue();

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual(2-1, result);
        }

        [Test]
        public void RandomPlayerHelper_GetLevel_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(2);

            // Act
            var result = RandomPlayerHelper.GetLevel();

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void RandomPlayerHelper_GetHealth_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(2);

            // Act
            var result = RandomPlayerHelper.GetHealth(1);

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void RandomPlayerHelper_GetCharacterDescription_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(2);

            // Act
            var result = RandomPlayerHelper.GetCharacterDescription();

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual("the awesome", result);
        }

        [Test]
        public void RandomPlayerHelper_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(2);

            // Act
            var result = RandomPlayerHelper.GetCharacterName();

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual("Doug", result);
        }

        [Test]
        public void RandomPlayerHelper_GetItem_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(2);

            // Act
            var result = RandomPlayerHelper.GetItem(Game.Models.ItemLocationEnum.Feet);

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreNotEqual(null, result);
        }
    }
}