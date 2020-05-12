using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RevisionCards
{
    public class Topic
    {

        public string Title { get; set; }
        public string Description { get; set; }

        public List<Card> Cards { get; set; }

        public Color Colour { get; set; }

        public Topic(string title, string description)
        {
            Title = title;
            Description = description;
            Colour = Color.PeachPuff;
            Cards = new List<Card>();
        }

        public Topic(string title, string description, Color colour)
        {
            Title = title;
            Description = description;
            Colour = colour;
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
