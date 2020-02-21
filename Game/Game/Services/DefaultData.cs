using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Services
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "Gold Sword",
                    Description = "Sword made of Gold, really expensive looking",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    Range = 0,
                    Damage = 9,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Strong Shield",
                    Description = "Enough to hide behind",
                    ImageURI = "http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Speed},
                
                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed},
            };

            return datalist;
        }

        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }

        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            string HeadString = null;
            string NecklassString = null;
            string PrimaryHandString = null;
            string OffHandString = null;
            string FeetString = null;
            string RightFingerString = null;
            string LeftFingerString = null;

          // // try
          //  {
          //      HeadString = ItemIndexViewModel.Instance.Dataset.Where(m => m.Location == ItemLocationEnum.Head).FirstOrDefault().Id;
          //      NecklassString = ItemIndexViewModel.Instance.Dataset.Where(m => m.Location == ItemLocationEnum.Necklass).FirstOrDefault().Id;
          //      PrimaryHandString = ItemIndexViewModel.Instance.Dataset.Where(m => m.Location == ItemLocationEnum.PrimaryHand).FirstOrDefault().Id;
          //      OffHandString = ItemIndexViewModel.Instance.Dataset.Where(m => m.Location == ItemLocationEnum.OffHand).FirstOrDefault().Id;
          //      FeetString = ItemIndexViewModel.Instance.Dataset.Where(m => m.Location == ItemLocationEnum.Feet).FirstOrDefault().Id;
          //      RightFingerString = ItemIndexViewModel.Instance.Dataset.Where(m => m.Location == ItemLocationEnum.Finger).FirstOrDefault().Id;
          //      LeftFingerString = ItemIndexViewModel.Instance.Dataset.Where(m => m.Location == ItemLocationEnum.Finger).LastOrDefault().Id;
          //  }
          ////  catch(Exception e)
          //  { }

            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Mike",
                    Description = "Warrior Wannabe",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "knight.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Doug",
                    Description = "Cleric in training",
                    Level = 1,
                    MaxHealth = 8,
                    ImageURI = "knight.png"
                },

                new CharacterModel {
                    Name = "Sue",
                    Description = "A strong Warrior",
                    Level = 4,
                    MaxHealth = 38,
                    ImageURI = "knight.png"
                },

                new CharacterModel {
                    Name = "Jea",
                    Description = "A powerfull Cleric",
                    Level = 5,
                    MaxHealth = 43,
                    ImageURI = "knight.png"
                }
            };

            return datalist;
        }
    }
}