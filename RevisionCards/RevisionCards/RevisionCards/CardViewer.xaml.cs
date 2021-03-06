﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RevisionCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardViewer : ContentPage
    {
        public string TopicSubjectTitle;


        private ObservableCollection<Card> allCards;
        private CardStatus status;
        private int position;


        public CardViewer(ObservableCollection<Card> cards, string title, Color colour)
        {
            InitializeComponent();

            MainStack.BackgroundColor = colour;

            status = CardStatus.Question;
            position = 0;
            allCards = new ObservableCollection<Card>(cards);
            TopicSubjectTitle = title;

            // SHUFFLE CARDS // TODO
            shuffleCards();

            BindingContext = allCards;
            this.Title = TopicSubjectTitle;

            SetQuestionAndAnswer();
        }

        async void ScreenTapped(object sender, EventArgs e)
        {
            if(status == CardStatus.Question)
            {
                await AnswerStack.FadeTo(1); // Fades in the answer
                status = CardStatus.Answer;
            } else if(status == CardStatus.Answer)
            {
                await AnswerStack.FadeTo(0);
                status = CardStatus.Question;

                SetQuestionAndAnswer();


                
            }

            
            
        }

        public void SetQuestionAndAnswer()
        {

            if(allCards != null && allCards.Count > 0)
            {   // Displays next card
                if (position < allCards.Count)
                {
                    Question.Text = allCards.ElementAt(position).Question;
                    Answer.Text = allCards.ElementAt(position).Answer;

                    position++;
                } else
                {
                    // When all cards have been through
                    status = CardStatus.Finished;
                    DisplayEndScreen();
                }
                
            }
            
        }

        async private void DisplayEndScreen()
        {
            await AnswerStack.FadeTo(0);
            QuestionTitle.IsVisible = false;
            Question.Text = "All done!";
        }


        private void shuffleCards() // puts the cards in a random order
        {
            if(allCards.Count > 1)
            {
                Random random = new Random();
                for (int i =0; i < allCards.Count; i++)
                {
                    int randIndex = random.Next(0, allCards.Count);

                    Card tmp = allCards[i];
                    allCards[i] = allCards[randIndex];
                    allCards[randIndex] = tmp;
                }
            }
        }
    }


    enum CardStatus // enum used to store what state the card displaying is at
    {
        Question,
        Answer,
        Finished
    }
}