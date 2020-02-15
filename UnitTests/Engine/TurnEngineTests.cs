﻿using NUnit.Framework;

using Game.Engine;
using Game.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Game.Services;
using Game.ViewModels;

namespace UnitTests.Engine
{
    [TestFixture]
    public class TurnEngineTests
    {
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.StartBattle(false);   // Clear the Engine
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TurnEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TurnEngine_Attack_Valid_Empty_Monster_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_Attack_InValid_Empty_Monster_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Clar the Monster List to cause the error
            Engine.MonsterList.Clear();

            // Act
            var result = Engine.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_Attack_InValid_Empty_Character_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new MonsterModel());

            // Cause an error by making the list empty
            Engine.CharacterList.Clear();

            // Act
            var result = Engine.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_Attack_Valid_Correct_List_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();
            Engine.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            // Act
            var result = Engine.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Empty_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();
            Engine.CharacterList = new List<PlayerInfoModel>();

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Null_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();

            // Remember the List
            var saveList = Engine.CharacterList;

            Engine.CharacterList = null;

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset
            Engine.CharacterList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();
            Engine.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreNotEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Empty_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();
            Engine.MonsterList = new List<PlayerInfoModel>();

            // Act
            var result = Engine.SelectMonsterToAttack();

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Null_List_Should_Fail()
        {
            // Arrange

            // Remember the List
            var saveList = Engine.MonsterList;
            
            Engine.MonsterList = null;

            // Act
            var result = Engine.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.MonsterList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectMonsterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();
            Engine.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            // Act
            var result = Engine.SelectMonsterToAttack();

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreNotEqual(null, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Hit_Should_Pass()
        {
            // Arrange
            var AttackScore = 10;
            var DefenseScore = 0;

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Miss_Should_Pass()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Forced_1_Should_Miss()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(1);

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Forced_20_Should_Hit()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(20);

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void TurnEngine_TakeTurn_Default_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.TakeTurn(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_DropItems_No_Items_Should_Return_0()
        {
            // Arrange
            var player = new CharacterModel();

            var PlayerInfo = new PlayerInfoModel(player);

            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(0);

            // Act
            var result = Engine.DropItems(PlayerInfo);

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TurnEngine_DropItems_Character_Items_2_Should_Return_2()
        {
            // Arrange
            var player = new CharacterModel
            {
                Head = ItemIndexViewModel.Instance.Dataset.FirstOrDefault().Id,
                Feet = ItemIndexViewModel.Instance.Dataset.FirstOrDefault().Id,
            };

            var PlayerInfo = new PlayerInfoModel(player);

            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(0);

            // Act
            var result = Engine.DropItems(PlayerInfo);

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void TurnEngine_DropItems_Monster_Items_0_Random_Drop_1_Should_Return_1()
        {
            // Arrange
            var player = new CharacterModel();

            var PlayerInfo = new PlayerInfoModel(player);

            DiceHelper.EnableRandomValues();
            DiceHelper.SetForcedRandomValue(1);

            // Act
            var result = Engine.DropItems(PlayerInfo);

            // Reset
            DiceHelper.DisableRandomValues();

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}