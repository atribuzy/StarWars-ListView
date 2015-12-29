using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StarWars_ListView
{
	public class Home : ContentPage
	{
		Label chosenLabel;
        public Home ()
		{
			string[] characterNames = new string[] { "C-3PO", "Chewbacca", "Darth Vader", "Luke SkyWalker",
			"Princess Leia","R2D2", "Yoda" };

			Label title = new Label
			{
				Text = "Star Wars ListView",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};

			ListView list = new ListView();
			list.ItemsSource = characterNames;
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

		private void List_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			chosenLabel.Text = "You Selected " + e.Item;
		}
	}
}
