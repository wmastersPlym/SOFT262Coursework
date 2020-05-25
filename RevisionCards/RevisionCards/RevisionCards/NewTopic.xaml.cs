using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RevisionCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTopic : ContentPage
    {
        Dictionary<string, Color> colours = Data.colours;

        private Subject subjectToAddTo;

        public NewTopic(Subject subject)
        {
            subjectToAddTo = subject;
            InitializeComponent();
            if(subject.Colour != null)
            {
                stack.BackgroundColor = subject.Colour;
            } else
            {
                stack.BackgroundColor = Color.MistyRose;
            }
            
            foreach (string s in colours.Keys)
            {
                ColourPicker.Items.Add(s);
            }
            ColourPicker.SelectedIndex = 0;
        }

        private void ChangedColour(object sender, EventArgs e)
        {
            if (ColourPicker.SelectedIndex == -1) // Makes sure a valid item was picked
            {
                stack.BackgroundColor = Color.MistyRose;
            }
            else
            {
                stack.BackgroundColor = colours[ColourPicker.Items[ColourPicker.SelectedIndex]]; // sets the background to the colour that was picked in the picker
            }

        }

        private void DoneClicked(object sender, EventArgs e)
        {
            // Creates a new topic using the data in the form and adds it to the topic
            subjectToAddTo.AddTopic(new Topic(TitleInput.Text, DescInput.Text, colours[ColourPicker.Items[ColourPicker.SelectedIndex]]));

            Navigation.PopAsync();
        }
    }
}