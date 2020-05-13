using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace RevisionCards
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Subject> subjects;

        public MainPage()
        {
            InitializeComponent();

            subjects = Data.GetInstance().GetAllSubjects();

            

            list.ItemsSource = subjects;
        }

        private void OnSubjectTapped(object sender, ItemTappedEventArgs e)
        {
            Subject tappedSubject = e.Item as Subject;
            Navigation.PushAsync(new SubjectViewer(tappedSubject));
        }

        private void NewSubjectClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewSubject());
        }
    }
}
