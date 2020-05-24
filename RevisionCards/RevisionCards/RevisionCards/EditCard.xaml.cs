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
    public partial class EditCard : ContentPage
    {
        private Card cardToEdit;
        private Topic topicItsIn;

        public EditCard(Card card, Topic topic)
        {
            cardToEdit = card;
            topicItsIn = topic;
            BindingContext = cardToEdit;
            InitializeComponent();
            stack.BackgroundColor = topic.Colour;
        }

        private void DoneClicked(object sender, EventArgs e)
        {
            cardToEdit.Question = QuestionInput.Text;
            cardToEdit.Answer = AnswerInput.Text;
            Navigation.PopAsync();
        }

        private void DeleteCardClicked(object sender, EventArgs e)
        {
            if (topicItsIn.Cards.Contains(cardToEdit)) {
                topicItsIn.Cards.Remove(cardToEdit);
            }
            Navigation.PopAsync();
        }
    }
}