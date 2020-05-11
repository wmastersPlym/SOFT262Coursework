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

            List<Subject> subjects = new List<Subject>();

            Subject a = new Subject("Coding", "A collection of questions from various languages");
            Topic topicA = new Topic("WebDev", "A collection of cards on different parts of web development");
            topicA.AddCard(new Card("What does HTML stand for?", "Hyper Text Markup Language"));
            topicA.AddCard(new Card("What does CSS stand for?", "Cascading Style Sheets"));
            a.AddTopic(topicA);

            Topic topicAA = new Topic("Java", "A collection of cards on JAVA");
            topicAA.AddCard(new Card("What does JVM stand for?", "Java virtual machine"));
            topicAA.AddCard(new Card("What does CSS stand for?", "Cascading Style Sheets"));
            a.AddTopic(topicAA);

            Subject b = new Subject("Sports", "A collection of questions from different sports");
            Topic topicB = new Topic("Under water hockey", "A collection of cards on underwater hockey");
            topicB.AddCard(new Card("What does UWH stand for?", "Underwater hockey"));
            topicB.AddCard(new Card("How many players are in the pool during an underwater hockey game?", "12"));
            b.AddTopic(topicB);

            subjects.Add(a);
            subjects.Add(b);

            list.ItemsSource = subjects;
        }

        private void OnSubjectTapped(object sender, ItemTappedEventArgs e)
        {
            Subject tappedSubject = e.Item as Subject;
            Navigation.PushAsync(new SubjectViewer(tappedSubject));
        }

        private void OnSubjectSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
