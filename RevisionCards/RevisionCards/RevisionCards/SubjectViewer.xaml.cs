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
            Navigation.PushAsync(new TopicViewer(tappedTopic, subject.Colour));
        }

        private void StartAll(object sender, EventArgs e)
        {
            List<Card> allCards = new List<Card>();
            foreach(Topic t in subject.Topics)
            {
                allCards.AddRange(t.Cards);
            }
            Navigation.PushAsync(new CardViewer(allCards, subject.Title, subject.Colour));
        }
    }
}