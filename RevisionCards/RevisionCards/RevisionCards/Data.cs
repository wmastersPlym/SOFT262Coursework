using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.IO;
using Xamarin.Forms;

namespace RevisionCards
{
    [Serializable]
    class SerialisableData
    {
        private static string file = "topics.xml";

        public SerialisableData()
        {

        }

        // Saves all the data within the local application data file on the mobile phone
        public void Save(ObservableCollection<Subject> allSubjects)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), file);
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Subject>));
            // Writes and serialises the data to the file
            using (StreamWriter writer = new System.IO.StreamWriter(fileName))
            {
                serializer.Serialize(writer, allSubjects);
                writer.Flush();
            }
        }

        // Loads all the data from the file and deserialises it and returns all the subjects
        public ObservableCollection<Subject> Load()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), file);

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Subject>));
            // creates an empty ObservableCollection ready to populate
            ObservableCollection<Subject> subjects;
            try
            {
                using(FileStream stream = File.OpenRead(fileName))
                {
                    // Fills the ObservableCollection with all the deserialised data 
                    subjects = serializer.Deserialize(stream) as ObservableCollection<Subject>;
                    return subjects;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
    }

    class Data
    {
        // Using singleton 
        private static Data instance;

        public static Dictionary<string, Color> colours = new Dictionary<string, Color> // potential background colours
        {
            { "MistyRose", Color.MistyRose }, {"PeachPuff", Color.PeachPuff },
            {"PaleGreen", Color.LightSeaGreen }, {"LightSteelBlue", Color.LightSteelBlue},
            {"AntiqueWhite", Color.AntiqueWhite }
        };

        private ObservableCollection<Subject> allSubjects;

        public Data()
        {

        }

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


        // Returns all the subjects
        public ObservableCollection<Subject> GetAllSubjects()
        {
            if(allSubjects == null)
            {
                //generateTestSubjects();
                SerialisableData sd = new SerialisableData();
                allSubjects = sd.Load();
                return GetAllSubjects();
            } else
            {
                return allSubjects;
            }
        }

        // Adds a subject to the observable collection
        public void AddSubject(Subject subject)
        {
            allSubjects.Add(subject);
        }


        // Save
        public void Save() // Saves all the subjects
        {
            SerialisableData sd = new SerialisableData();
            sd.Save(allSubjects);
        }

        public void Load() // loads all the subjects into the allSubjects variable
        { 
            SerialisableData sd = new SerialisableData();
            allSubjects = sd.Load();
        }

        public ObservableCollection<Subject> TestLoad() // used for testing the serialisation
        {
            SerialisableData sd = new SerialisableData();
            return sd.Load();
        }



        private void generateTestSubjects() // generates subjects and topics for testing
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
