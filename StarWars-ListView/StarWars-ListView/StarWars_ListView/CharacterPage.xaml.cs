using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StarWars_ListView
{
	public partial class CharacterPage : ContentPage
	{
		public CharacterPage (People character)
		{
            InitializeComponent ();

            CharacterStackLayout.BindingContext = character;
        }
	}
}
