using SharpTrooper.Core;
using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StarWars_ListView
{
	public partial class StartPage : ContentPage
	{
        public List<People> Characters { get; set; }
        public People SelectedCharacter { get; set; }
        private SharpTrooperCore core;


        public StartPage ()
		{
			InitializeComponent ();
            core = new SharpTrooperCore();

            Characters = new List<People>();
            Characters = GetAllPepole();
            
            List.BindingContext = this;
            
            
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCharacter = e.SelectedItem as People;
            Navigation.PushAsync(new CharacterPage(selectedCharacter),true);
        }

        public List<People> GetAllPepole()
        {
            var characters = new List<People>();
            
            var getPepoleResult = core.GetAllPeople("1");
            characters = getPepoleResult.results;

            return characters;
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedCharacter = e.Item as People;
            Navigation.PushAsync(new CharacterPage(selectedCharacter), true);
        }
        protected override void OnAppearing()
        {            
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {            
            base.OnDisappearing();
        }

        
    }
}
