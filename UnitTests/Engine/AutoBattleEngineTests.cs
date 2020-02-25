using NUnit.Framework;

using Game.Engine;
using Game.Models;
using System.Threading.Tasks;
using Game.Helpers;
using System.Linq;
using Game.ViewModels;

namespace UnitTests.Engine
{
    [TestFixture]
    public class AutoBattleEngineTests
    {
        AutoBattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new AutoBattleEngine();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void AutoBattleEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AutoBattleEngine_GetScoreObject_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.GetScoreObject();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

       [Test]
        public void AutoBattleEngine_RunAutoBattle_Default_Should_Pass()
        {
            //Arrange

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(3);

            var data = new CharacterModel { Level = 1, MaxHealth = 10 };

            Engine.CharacterList.Add(new PlayerInfoModel(data));
            Engine.CharacterList.Add(new PlayerInfoModel(data));
            Engine.CharacterList.Add(new PlayerInfoModel(data));
            Engine.CharacterList.Add(new PlayerInfoModel(data));
            Engine.CharacterList.Add(new PlayerInfoModel(data));
            Engine.CharacterList.Add(new PlayerInfoModel(data));

            //Act
            var result = Engine.RunAutoBattle();

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.IsNotNull(result);
        }

       [Test]
        public void AutoBattleEngine_RunAutoBattle_Monsters_1_Should_Pass()
        {
            //Arrange

            // Need to set the Monster count to 1, so the battle goes to Next Round Faster
            Engine.MaxNumberPartyMonsters = 1;
            Engine.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            Engine.CharacterList.Add(CharacterPlayerMike);

            //Act
            var result = Engine.RunAutoBattle();

            //Reset

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task AutoBattleEngine_CreateCharacterParty_Characters_Should_Assign_6()
        {
            //Arrange
            Engine.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "1" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "2" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "3" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "4" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "5" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "6" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "7" });

            //Act
            var result = Engine.CreateCharacterParty();

            //Reset

            //Assert
            Assert.AreEqual(6, Engine.CharacterList.Count());
            Assert.AreEqual("6", Engine.CharacterList.ElementAt(5).Name);
        }

        [Test]
        public void AutoBattleEngine_CreateCharacterParty_Characters_CharacterIndex_None_Should_Create_6()
        {
            //Arrange
            Engine.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();
            
            //Act
            var result = Engine.CreateCharacterParty();

            //Reset

            //Assert
            Assert.AreEqual(6, Engine.CharacterList.Count());
        }

        [Test]
        public void AutoBattleEngine_RunAutoBattle_Character_Level_Up_Should_Pass()
        {
            // Test to force leveling up of a character during the battle

            //Arrange
            Engine.MaxNumberPartyCharacters = 1;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            // To See Level UP happening, a character needs to be close to the next level
            var Character = new CharacterModel
            {
                ExperienceTotal = 300,    // Enough for next level
                Name = "Mike Level Example",
                Speed = 100,    // Go first
            };

            var CharacterPlayer = new PlayerInfoModel(Character);

            Engine.CharacterList.Add(CharacterPlayer);

            //Act
            var result = Engine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, Engine.BattleScore.CharacterAtDeathList.Contains("Mike Level Example"));
        }
    }
}