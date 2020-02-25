using Game.Engine;
using Game.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AutoBattlePage : ContentPage
	{
		// Hold the Engine, so it can be swapped out for unit testing
		public AutoBattleEngine Engine = new AutoBattleEngine();

		/// <summary>
		/// Constructor
		/// </summary>
		public AutoBattlePage ()
		{
			InitializeComponent ();
		}

		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			// Call into Auto Battle from here to do the Battle...

			// To See Level UP happening, a character needs to be close to the next level
			var Character = new CharacterModel
			{
				ExperienceTotal = 300,    // Enough for next level
				Name = "Mike Level Example",
				Speed = 100,	// Go first
			};

			var CharacterPlayer = new PlayerInfoModel(Character);

			Engine.CharacterList.Add(CharacterPlayer);

			await Engine.RunAutoBattle();
			
			var Score = Engine.GetScoreObject();

			var BattleMessage = string.Format("Done {0} Rounds", Score.RoundCount);

			BattleMessageValue.Text = BattleMessage;
		}
	}
}