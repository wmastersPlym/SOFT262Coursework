using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace RevisionCards
{
    public class Subject
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Color Colour { get; set; }

        public ObservableCollection<Topic> Topics { get; set; } 
        
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



        public void AddTopic(Topic topic)
        {
            Topics.Add(topic);
        }

    }
}
