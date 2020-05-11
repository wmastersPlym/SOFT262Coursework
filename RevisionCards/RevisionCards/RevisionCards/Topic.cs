using System;
using System.Collections.Generic;
using System.Text;

namespace RevisionCards
{
    public class Topic
    {

        public string Title { get; set; }
        public string Description { get; set; }

        public List<Card> Cards { get; set; }

        public Topic(string title, string description)
        {
            Title = title;
            Description = description;
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
