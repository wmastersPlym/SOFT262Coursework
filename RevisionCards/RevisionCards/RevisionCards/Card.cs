using System;
using System.Collections.Generic;
using System.Text;

namespace RevisionCards
{
    public class Card
    {
        public string Question { get; set; }

        private string Answer { get; set; }


        // CONSTRUCTOR
        public Card (string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }

    }
}
