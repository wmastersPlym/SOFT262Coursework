using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RevisionCards
{
    public class Card : INotifyPropertyChanged
    {
        private string _question;
        public string Question {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Question"));
                }
            }
        }

        private string _answer;
        public string Answer {
            get
            {
                return _answer;
            }
            set
            {
                _answer = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Answer"));
                }
            }
        }


        // CONSTRUCTOR
        public Card (string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Card()
        {
            Question = "test";
            Answer = "test";
        }
    }
}
