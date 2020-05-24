using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RevisionCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectViewer : ContentPage
    {
        private Subject subject;

        public SubjectViewer(Subject subject)
        {
            this.subject = subject;
            InitializeComponent();

            BindingContext = subject;
        }

        private void OnTopicTapped(object sender, ItemTappedEventArgs e)
        {
            Topic tappedTopic = e.Item as Topic;
            Navigation.PushAsync(new TopicViewer(tappedTopic, subject));
        }

        private void StartAll(object sender, EventArgs e)
        {
            ObservableCollection<Card> allCards = new ObservableCollection<Card>();

            // Adds all cards a from the subject to a ObservableCollection 
            foreach(Topic t in subject.Topics)
            {
                foreach(Card c in t.Cards)
                {
                    allCards.Add(c);
                }
            }


            Navigation.PushAsync(new CardViewer(allCards, subject.Title, subject.Colour));
        }

        private void NewTopicClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTopic(subject));
        }
    }
}