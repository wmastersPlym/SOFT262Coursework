using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RevisionCards
{
    public class Subject
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Color Colour { get; set; }

        private List<Card> Cards { get; set; } 
        
        public Subject (string title, string description)
        {
            this.Title = title;
            this.Description = description;
            Colour = Color.PeachPuff;
            Cards = new List<Card>();
        }



        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

    }
}
