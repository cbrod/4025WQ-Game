﻿using Game.Helpers;
using Game.Models;
using Game.Services;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// About Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        // Constructor for UnitTests
        public AboutPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for About Page
        /// </summary>
        public AboutPage()
        {
            InitializeComponent();

            // Hide the Debug Settings
            DatabaseSettingsFrame.IsVisible = false;

            // Turn off the Settings Frame
            DebugSettingsFrame.IsVisible = false;

            // Set to the curent date and time
            CurrentDateTime.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        }

        /// <summary>
        /// Show or hide the Database Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DatabaseSettingsSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            // Show or hide the Database Section
            DatabaseSettingsFrame.IsVisible = (e.Value);
        }

        /// <summary>
        /// Sow or hide the Debug Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DebugSettingsSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            // Show or hide the Debug Settings
            DebugSettingsFrame.IsVisible = (e.Value);
        }

        /// <summary>
        /// Data Source Toggle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DataSource_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (DataSourceValue.IsToggled == true)
            {
                MessagingCenter.Send(this, "SetDataSource", 1);
            }
            else
            {
                MessagingCenter.Send(this, "SetDataSource", 0);
            }
        }

        /// <summary>
        /// Button to delete the data store
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void WipeDataList_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Delete Data", "Are you sure you want to delete all data?", "Yes", "No");

            if (answer)
            {
               Task.Run(async ()=> { await DataSetsHelper.WipeDataInSequence(); });
               //MessagingCenter.Send(this, "WipeDataList", true);
            }
        }

        /// <summary>
        /// Example of how to call for Items using HttpGet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetItemsGet_Command(object sender, EventArgs e)
        {
            var myOutput = "No Results";
            var myDataList = new List<ItemModel>();

            var answer = await DisplayAlert("Get", "Sure you want to Get Items from the Server?", "Yes", "No");
            if (answer)
            {
                // Call to the ItemModel Service and have it Get the Items
                // The ServerItemValue Code stands for the batch of items to get
                // as the group to request.  1, 2, 3, 100 (All), or if not specified All

                var value = Convert.ToInt32(ServerItemValue.Text);
                myDataList = await Services.ItemService.GetItemsFromServerGetAsync(value);

                if (myDataList != null && myDataList.Count > 0)
                {
                    // Reset the output
                    myOutput = "";

                    foreach (var ItemModel in myDataList)
                    {
                        // Add them line by one, use \n to force new line for output display.
                        // Build up the output string by adding formatted ItemModel Output
                        myOutput += ItemModel.FormatOutput() + "\n";
                    }
                }

                await DisplayAlert("Returned List", myOutput, "OK");
            }
        }

        /// <summary>
        /// Example of how to call for Items using Http Post
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetItemsPost_Command(object sender, EventArgs e)
        {
            var myOutput = "No Results";
            var myDataList = new List<ItemModel>();

            var number = Convert.ToInt32(ServerItemValue.Text);
            var level = 6;  // Max Value of 6
            var attribute = AttributeEnum.Unknown;  // Any Attribute
            var location = ItemLocationEnum.Unknown;    // Any Location
            var random = true;  // Random between 1 and Level
            var updateDataBase = true;  // Add them to the DB
            var category = 0;   // What category to filter down to, 0 is all

            // will return shoes value 10 of speed.
            // Example  result = await ItemsController.Instance.GetItemsFromGame(1, 10, AttributeEnum.Speed, ItemLocationEnum.Feet, false, true);
            myDataList = await ItemService.GetItemsFromServerPostAsync(number, level, attribute, location, category, random, updateDataBase);

            if (myDataList != null && myDataList.Count > 0)
            {
                // Reset the output
                myOutput = "";

                foreach (var ItemModel in myDataList)
                {
                    // Add them line by one, use \n to force new line for output display.
                    myOutput += ItemModel.FormatOutput() + "\n";
                }
            }

            await DisplayAlert("Returned List", myOutput, "OK");
        }
    }
}