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
    public partial class TopicViewer : ContentPage
    {

        private Topic topic;
        private Subject subject;

        public TopicViewer(Topic topic, Subject subject)
        {
            this.topic = topic;
            this.subject = subject;

            InitializeComponent();
            stack.BackgroundColor = topic.Colour;
            BindingContext = topic;
        }

        private void OnCardTapped(object sender, ItemTappedEventArgs e)
        {
            Card tappedCard = e.Item as Card;
            Navigation.PushAsync(new EditCard(tappedCard, topic)); // Opens the edit card page
        }

        async private void StartClicked(object sender, EventArgs e) // Attempts to start viewing the vards
        {
            if(topic.Cards.Count > 0 && topic.Cards != null)
            {
                await Navigation.PushAsync(new CardViewer(topic.Cards, topic.Title, topic.Colour)); // Sucessful, starts going through the cards
            } else
            {
                await DisplayAlert("Alert", "No cards found", "OK"); // No cards were found within the topic
            }
            
        }

        private void NewCardClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCard(topic)); // Opens new card page
        }

        private void EditTopicClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditTopic(topic)); // Opens edit topic page
        }

        private void DeleteTopicClicked(object sender, EventArgs e)
        {
            if (subject.Topics.Contains(topic)) // Makes sure the topic is within the subject that was passed with it
            {
                subject.Topics.Remove(topic); // removes it
            }
            Navigation.PopAsync(); // sends user to previous page
        }
    }
}