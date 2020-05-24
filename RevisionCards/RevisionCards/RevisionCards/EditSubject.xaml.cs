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
            foreach (string s in Data.colours.Keys)
            {
                ColourPicker.Items.Add(s);
            }
            ColourPicker.SelectedIndex = 0;
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
                stack.BackgroundColor = Data.colours[ColourPicker.Items[ColourPicker.SelectedIndex]];
            }
        }

        private void DoneClicked(object sender, EventArgs e) {
            subject.Title = TitleInput.Text;
            subject.Description = DescInput.Text;
            subject.Colour = Data.colours[ColourPicker.Items[ColourPicker.SelectedIndex]];
            Navigation.PopAsync();
        }
    }

    
}