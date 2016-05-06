using SharpTrooper.Core;
using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StarWars_ListView
{
	public class Home : ContentPage
	{
		Label chosenLabel;
        public Home ()
		{
            //string[] characterNames = new string[] { "C-3PO", "Chewbacca", "Darth Vader", "Luke SkyWalker",
            //"Princess Leia","R2D2", "Yoda" };
            var characters = GetAllPepole();

            


            Label title = new Label
			{
				Text = "Star Wars ListView",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};

			ListView list = new ListView();
			list.ItemsSource = characters;
            
			list.ItemTapped += List_ItemTapped;

			chosenLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			StackLayout stack = new StackLayout
			{
				Children = {title,list, chosenLabel }
			};
			this.Content = stack;
			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);
		}

        public List<People> GetAllPepole()
        {
            var characters = new List<People>();
            SharpTrooperCore core = new SharpTrooperCore();
            var getPepoleResult = core.GetAllPeople("1");
            characters = getPepoleResult.results;
                        
            return characters;
        }

		private void List_ItemTapped(object sender, ItemTappedEventArgs e)
		{
            SharpTrooperCore core = new SharpTrooperCore();
            core.GetPeople(e.Item.ToString());
            chosenLabel.Text = "You Selected " + e.Item;
		}
	}
}
