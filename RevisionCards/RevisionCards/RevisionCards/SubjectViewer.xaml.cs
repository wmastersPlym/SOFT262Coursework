using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RevisionCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectViewer : ContentPage
    {
        public SubjectViewer(Subject subject)
        {
            
            InitializeComponent();

            BindingContext = subject;
        }

        private void OnTopicTapped(object sender, ItemTappedEventArgs e)
        {
            Topic tappedTopic = e.Item as Topic;
            Navigation.PushAsync(new TopicViewer(tappedTopic));
        }
    }
}