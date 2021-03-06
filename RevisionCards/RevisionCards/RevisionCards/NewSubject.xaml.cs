﻿using System;
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

        Dictionary<string, Color> colours = Data.colours;

        public NewSubject()
        {
            InitializeComponent();
            stack.BackgroundColor = Color.MistyRose;
            foreach (string s in colours.Keys) // Fills the picker with all the colours
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
                stack.BackgroundColor = colours[ColourPicker.Items[ColourPicker.SelectedIndex]]; // Changes the background colour to whatever was picked in the picker
            }
            
        }

        private void DoneClicked(object sender, EventArgs e)
        {
            // Creates a new subject object and adds it to the 'database'
            Data.GetInstance().AddSubject(new Subject(TitleInput.Text, DescInput.Text, colours[ColourPicker.Items[ColourPicker.SelectedIndex]]));
            Navigation.PopAsync();
        }
    }
}