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
            Navigation.PushAsync(new EditCard(tappedCard, topic));
        }

        async private void StartClicked(object sender, EventArgs e)
        {
            if(topic.Cards.Count > 0 && topic.Cards != null)
            {
                await Navigation.PushAsync(new CardViewer(topic.Cards, topic.Title, topic.Colour));
            } else
            {
                await DisplayAlert("Alert", "No cards found", "OK");
            }
            
        }

        private void NewCardClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCard(topic));
        }

        private void EditTopicClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditTopic(topic));
        }

        private void DeleteTopicClicked(object sender, EventArgs e)
        {
            if (subject.Topics.Contains(topic))
            {
                subject.Topics.Remove(topic);
            }
            Navigation.PopAsync();
        }
    }
}