using System;
using System.ComponentModel;
using Xamarin.Forms;
using Game.ViewModels;
using Game.Models;
using Game.Helpers;

namespace Game.Views
{
    /// <summary>
    /// Character Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class CharacterUpdatePage : ContentPage
    {
        // View Model for Character
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for Tests
        public CharacterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data Character
        /// </summary>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            // Load the values for the Level into the Picker
            for (var i = 1; i <= LevelTableHelper.MaxLevel; i++)
            {
                LevelPicker.Items.Add(i.ToString());
            }

            MaxHealthValue.Text = string.Format(" : {0:G}", ViewModel.Data.MaxHealth);
        }

        /// <summary>
        /// The Level selected from the list
        /// Need to recalculate Max Health
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Level_Changed(object sender, EventArgs args)
        {
            var level = LevelPicker.SelectedIndex+1;

            // Roll the Dice and reset the Health
            ViewModel.Data.MaxHealth = DiceHelper.RollDice(level,10);

            MaxHealthValue.Text = string.Format(" : {0:G}",ViewModel.Data.MaxHealth);
        }
        
        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = new CharacterModel().ImageURI;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}