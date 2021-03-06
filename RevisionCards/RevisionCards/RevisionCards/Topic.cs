﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

using Xamarin.Forms;
using System.Xml.Serialization;

namespace RevisionCards
{
    public class Topic : INotifyPropertyChanged
    {
        private string _title;
        public string Title {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
        }

        private string _description;
        public string Description {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }

        private ObservableCollection<Card> _cards;
        public ObservableCollection<Card> Cards {
            get
            {
                return _cards;
            }
            set
            {
                _cards = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Cards"));
                }
            }
        }
        [XmlIgnore]
        private Color _colour;

        [XmlIgnore]
        public Color Colour {
            get
            {
                return _colour;
            }
            set
            {
                _colour = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Colour"));
                }
            }
        }
        public string ColourHex // used for serialisation of the Colour attribute
        {
            get { return Colour.ToHex(); }
            set { Colour = Color.FromHex(value); }
        }

        public Topic()
        {
            this.Title = "test";
            this.Description = "test";
            Colour = Color.PeachPuff;
            Cards = new ObservableCollection<Card>();
        }
        public Topic(string title, string description)
        {
            Title = title;
            Description = description;
            Colour = Color.PeachPuff;
            Cards = new ObservableCollection<Card>();
        }

        public Topic(string title, string description, Color colour)
        {
            Title = title;
            Description = description;
            Colour = colour;
            Cards = new ObservableCollection<Card>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
