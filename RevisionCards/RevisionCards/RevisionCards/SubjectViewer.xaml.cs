﻿using System;
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

        async private void StartAll(object sender, EventArgs e)
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

            if (allCards.Count > 0 && allCards != null)
            {
                await Navigation.PushAsync(new CardViewer(allCards, subject.Title, subject.Colour));
            }
            else
            {
                await DisplayAlert("Alert", "No cards found", "OK");
            }
            
        }

        private void NewTopicClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTopic(subject));
        }

        private void EditSubjectClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditSubject(subject));
        }

        private void DeleteSubjectClicked(object sender, EventArgs e)
        {
            if (Data.GetInstance().GetAllSubjects().Contains(subject))
            {
                Data.GetInstance().GetAllSubjects().Remove(subject);
            }
            Navigation.PopAsync();
        }
    }
}