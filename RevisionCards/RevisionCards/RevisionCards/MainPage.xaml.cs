using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RevisionCards
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            List<Subject> test = new List<Subject>();

            Subject a = new Subject("Coding", "A collection of questions from various languages");
            a.AddCard(new Card("What does HTML stand for?", "Hyper Text Markup Language"));
            a.AddCard(new Card("What does CSS stand for?", "Cascading Style Sheets"));

            Subject b = new Subject("Sports", "A collection of questions from different sports");
            b.AddCard(new Card("What does UWH stand for?", "Underwater hockey"));
            b.AddCard(new Card("How many players are in the pool during an underwater hockey game?", "12"));

            test.Add(a);
            test.Add(b);

            list.ItemsSource = test;
        }
    }
}
