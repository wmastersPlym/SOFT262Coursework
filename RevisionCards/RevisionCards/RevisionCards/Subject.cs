using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace RevisionCards
{
    public class Subject : INotifyPropertyChanged
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
                if(PropertyChanged != null)
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

        private ObservableCollection<Topic> _topics;
        public ObservableCollection<Topic> Topics {
            get
            {
                return _topics;
            }
            set
            {
                _topics = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Topics"));
                }
            }
        } 

        public string ColourHex // used for serialisation of the Colour attribute
        {
            get { return Colour.ToHex(); }
            set { Colour = Color.FromHex(value); }
        }
        
        public Subject()
        {
            this.Title = "test";
            this.Description = "test";
            Colour = Color.PeachPuff;
            Topics = new ObservableCollection<Topic>();
        }

        public Subject (string title, string description)
        {
            this.Title = title;
            this.Description = description;
            Colour = Color.PeachPuff;
            Topics = new ObservableCollection<Topic>();
        }

        public Subject(string title, string description, Color colour)
        {
            this.Title = title;
            this.Description = description;
            Colour = colour;
            Topics = new ObservableCollection<Topic>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddTopic(Topic topic)
        {
            Topics.Add(topic);
        }
        
    }
}
