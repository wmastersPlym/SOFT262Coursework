using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RevisionCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewSubject : ContentPage
    {

        Dictionary<string, Color> colours = new Dictionary<string, Color>
        {
            { "MistyRose", Color.MistyRose }, {"PeachPuff", Color.PeachPuff },
            {"PaleGreen", Color.LightSeaGreen }, {"LightSteelBlue", Color.LightSteelBlue},
            {"AntiqueWhite", Color.AntiqueWhite }
        };

        public NewSubject()
        {
            InitializeComponent();
            stack.BackgroundColor = Color.MistyRose;
            foreach (string s in colours.Keys)
            {
                ColourPicker.Items.Add(s);
            }
            ColourPicker.SelectedIndex = 0;

            
        }

        private void ChangedColour(object sender, EventArgs e)
        {
            if(ColourPicker.SelectedIndex == -1)
            {
                stack.BackgroundColor = Color.MistyRose;
            } else {
                stack.BackgroundColor = colours[ColourPicker.Items[ColourPicker.SelectedIndex]];
            }
            
        }

        private void DoneClicked(object sender, EventArgs e)
        {
            Data.GetInstance().AddSubject(new Subject(TitleInput.Text, DescInput.Text, colours[ColourPicker.Items[ColourPicker.SelectedIndex]]));
            Navigation.PopAsync();
        }
    }
}