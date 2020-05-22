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

        public TopicViewer(Topic topic, Color colour)
        {
            this.topic = topic;

            InitializeComponent();
            stack.BackgroundColor = colour;
            BindingContext = topic;
        }

        private void OnCardTapped(object sender, ItemTappedEventArgs e)
        {
            //Subject tappedSubject = e.Item as Subject;
            //Navigation.PushAsync(new SubjectViewer(tappedSubject));
        }

        private void StartClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CardViewer(this.topic.Cards, topic.Title, topic.Colour));
        }

        private void NewCardClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCard(topic));
        }
    }
}