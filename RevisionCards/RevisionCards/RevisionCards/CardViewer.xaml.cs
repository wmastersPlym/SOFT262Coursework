using System;
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
            allCards = cards;
            TopicSubjectTitle = title;

            BindingContext = cards;
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


                
            } else
            {

            }

            
            
        }

        public void SetQuestionAndAnswer()
        {
            if(allCards != null && allCards.Count > 0)
            {
                if (position < allCards.Count)
                {
                    Question.Text = allCards.ElementAt(position).Question;
                    Answer.Text = allCards.ElementAt(position).Answer;

                    position++;
                } else
                {
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
    }


    enum CardStatus
    {
        Question,
        Answer,
        Finished
    }
}