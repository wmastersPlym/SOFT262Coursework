using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace RevisionCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTopic : ContentPage
    {
        private Topic topic;

        

        public EditTopic(Topic topic)
        {
            this.topic = topic;
            BindingContext = this.topic;

            InitializeComponent();
            foreach (string s in Data.colours.Keys) // Adds all the colours to the colour picker
            {
                ColourPicker.Items.Add(s);
            }
            ColourPicker.SelectedIndex = 0;

            if (topic.Colour != null) // sets the background colour to the colour used by the topic
            {
                stack.BackgroundColor = topic.Colour;
            }
        }

        private void ChangedColour(object sender, EventArgs e)
        {
            if (ColourPicker.SelectedIndex == -1)
            {
                stack.BackgroundColor = Color.MistyRose;
            }
            else
            {
                stack.BackgroundColor = Data.colours[ColourPicker.Items[ColourPicker.SelectedIndex]]; // Sets the background colour to what was picked in the colour picker
            }
        }

        private void DoneClicked(object sender, EventArgs e)
        {
            // Saves all the changes made and sends the user back to the previous page
            topic.Title = TitleInput.Text;
            topic.Description = DescInput.Text;
            topic.Colour = Data.colours[ColourPicker.Items[ColourPicker.SelectedIndex]];
            Navigation.PopAsync();
        }

        
    }
}