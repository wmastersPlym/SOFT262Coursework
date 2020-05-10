using System;
using System.Collections.Generic;
using System.Text;

namespace RevisionCards
{
    public class Card
    {
        private string question;

        private string answer;


        // CONSTRUCTOR
        public Card (string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }

        // GETTERS
        public string GetQuestion()
        {
            return question;
        }

        public string GetAnswer()
        {
            return answer;
        }


        // SETTERS
        public void SetQuestion(string question)
        {
            this.question = question;
        }

        public void SetAnswer(string answer)
        {
            this.answer = answer;
        }
    }
}
