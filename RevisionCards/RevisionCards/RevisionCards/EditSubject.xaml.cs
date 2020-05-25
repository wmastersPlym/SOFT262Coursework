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
    public partial class EditSubject : ContentPage
    {

        private Subject subject;

        public EditSubject(Subject subject) {
            this.subject = subject;
            InitializeComponent();

            // Adds all the colours to the colour picker
            foreach (string s in Data.colours.Keys)
            {
                ColourPicker.Items.Add(s);
            }
            ColourPicker.SelectedIndex = 0;

            //sets the background colour to that of the subject
            if (this.subject.Colour != null)
            {
                stack.BackgroundColor = this.subject.Colour;
            }
            BindingContext = this.subject;
        }

        private void ChangedColour(object sender, EventArgs e)
        {
            if (ColourPicker.SelectedIndex == -1)
            {
                stack.BackgroundColor = Color.MistyRose;
            }
            else
            {
                stack.BackgroundColor = Data.colours[ColourPicker.Items[ColourPicker.SelectedIndex]]; // changes the background to what was picked in the colour picker
            }
        }

        private void DoneClicked(object sender, EventArgs e) {
            // Saves the changed subject data and returns the user to the main page
            subject.Title = TitleInput.Text;
            subject.Description = DescInput.Text;
            subject.Colour = Data.colours[ColourPicker.Items[ColourPicker.SelectedIndex]];
            Navigation.PopAsync();
        }
    }

    
}