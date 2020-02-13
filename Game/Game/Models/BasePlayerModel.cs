﻿using System.Collections.Generic;

namespace Game.Models
{
    public class BasePlayerModel<T> : BaseModel<T>
    {
        #region Attributes
        #region GameEngineAttributes
        // TurnOrder
        public int Order;

        // Guid of the original data it links back to the ID, used in Game Engine
        public string Guid;

        // alive status, !alive will be removed from the list
        public bool Alive = true;

        // The type of player, character comes before monster
        public PlayerTypeEnum PlayerType;

        // Finally if all of the above are the same, sort based on who was loaded first into the list...
        public int ListOrder;

        #endregion GameEngineAttributes

        #region PlayerAttributes

        // Total speed, including level and items
        public int Speed;

        // Level of character or monster
        public int Level;

        // The experience points the player has used in sorting ties...
        public int ExperiencePoints;

        // Current Health
        public int CurrentHealth;

        // Max Health
        public int MaxHealth;

        // Total Experience
        public int ExperienceTotal = 0;

        // The defense score, to be used for defending against attacks
        public int Defense { get; set; }

        // The Attack score to be used when attacking
        public int Attack { get; set; }
        #endregion PlayerAttributes

        #region Items
        // Item is a string referencing the database table
        public string Head { get; set; }

        // Feet is a string referencing the database table
        public string Feet { get; set; }

        // Necklasss is a string referencing the database table
        public string Necklass { get; set; }

        // PrimaryHand is a string referencing the database table
        public string PrimaryHand { get; set; }

        // Offhand is a string referencing the database table
        public string OffHand { get; set; }

        // RightFinger is a string referencing the database table
        public string RightFinger { get; set; }

        // LeftFinger is a string referencing the database table
        public string LeftFinger { get; set; }
        #endregion Items
        #endregion Attributes

        #region Methods

        public int GetAttack() { return 0; }
        public int GetDefense() { return 0; }
        public int GetSpeed() { return 0; }
        public int GetHealthCurrent() { return CurrentHealth; }
        public int GetHealthMax() { return MaxHealth; }
        public int GetDamageRollValue() { return 10; }


        // Take Damage
        // If the damage recived, is > health, then death occurs
        // Return the number of experience received for this attack 
        // monsters give experience to characters.  Characters don't accept expereince from monsters
        public bool TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                return false;
            }

            CurrentHealth = CurrentHealth - damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;

                // Death...
                CauseDeath();
            }

            return true;
        }

        // Death
        // Alive turns to False
        public bool CauseDeath()
        {
            Alive = false;
            return Alive;
        }

        public List<ItemModel> DropAllItems() { return new List<ItemModel>(); }
        public string FormatOutput() { return ""; }
        public bool AddExperience(int newExperience) { return true; }
        public ItemModel AddItem(ItemLocationEnum itemlocation, string itemID) { return new ItemModel(); }
        public int CalculateExperienceEarned(int damage) { return 0; }
        public ItemModel GetItem(string itemString) { return new ItemModel(); }
        public ItemModel GetItemByLocation(ItemLocationEnum itemLocation)
        {
            switch (itemLocation)
            {
                case ItemLocationEnum.Head:
                    return GetItem(Head);

                case ItemLocationEnum.Necklass:
                    return GetItem(Necklass);

                case ItemLocationEnum.PrimaryHand:
                    return GetItem(PrimaryHand);

                case ItemLocationEnum.OffHand:
                    return GetItem(OffHand);

                case ItemLocationEnum.RightFinger:
                    return GetItem(RightFinger);

                case ItemLocationEnum.LeftFinger:
                    return GetItem(LeftFinger);

                case ItemLocationEnum.Feet:
                    return GetItem(Feet);
            }

            return null;
        }
        #endregion Methods
    }
}