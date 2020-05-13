using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace RevisionCards
{
    class Data
    {
        private static Data instance;

        private ObservableCollection<Subject> allSubjects;

        public static Data GetInstance()
        {
            if (instance == null)
            {
                instance = new Data();
                return instance;
            } else
            {
                return instance;
            }
        }

        public ObservableCollection<Subject> GetAllSubjects()
        {
            if(allSubjects == null)
            {
                generateTestSubjects();
                return GetAllSubjects();
            } else
            {
                return allSubjects;
            }

            

            
        }

        public void AddSubject(Subject subject)
        {
            allSubjects.Add(subject);
        }






        private void generateTestSubjects()
        {
            allSubjects = new ObservableCollection<Subject>();

            Subject a = new Subject("Coding", "A collection of questions from various languages");
            Topic topicA = new Topic("WebDev", "A collection of cards on different parts of web development");
            topicA.AddCard(new Card("What does HTML stand for?", "Hyper Text Markup Language"));
            topicA.AddCard(new Card("What does CSS stand for?", "Cascading Style Sheets"));
            a.AddTopic(topicA);

            Topic topicAA = new Topic("Java", "A collection of cards on JAVA");
            topicAA.AddCard(new Card("What does JVM stand for?", "Java virtual machine"));
            topicAA.AddCard(new Card("What does CSS stand for?", "Cascading Style Sheets"));
            a.AddTopic(topicAA);

            Subject b = new Subject("Sports", "A collection of questions from different sports");
            Topic topicB = new Topic("Under water hockey", "A collection of cards on underwater hockey");
            topicB.AddCard(new Card("What does UWH stand for?", "Underwater hockey"));
            topicB.AddCard(new Card("How many players are in the pool during an underwater hockey game?", "12"));
            b.AddTopic(topicB);

            allSubjects.Add(a);
            allSubjects.Add(b);
        }
    }
}
