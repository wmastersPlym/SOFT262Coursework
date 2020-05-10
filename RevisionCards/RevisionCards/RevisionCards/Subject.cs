using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RevisionCards
{
    class Subject
    {
        private string title;
        private string description;

        private Color colour;

        private List<Card> cards; 
        
        public Subject (string title, string description)
        {
            this.title = title;
            this.description = description;
            colour = Color.PeachPuff;
            cards = new List<Card>();
        }


        // GETTERS
        public string GetTitle()
        {
            return title;
        }

        public string GetDescription()
        {
            return description;
        }

        public Color GetColour()
        {
            return colour;
        }

        public List<Card> GetCards()
        {
            return cards;
        }

        // SETTERS
        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetDescription(String description)
        {
            this.description = description;
        }

        public void SetColour(Color colour)
        {
            this.colour = colour;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

    }
}
