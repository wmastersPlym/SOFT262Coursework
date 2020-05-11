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
    public partial class TopicViewer : ContentPage
    {
        public TopicViewer(Topic topic)
        {
            InitializeComponent();

            BindingContext = topic;
        }

        private void OnCardTapped(object sender, ItemTappedEventArgs e)
        {
            //Subject tappedSubject = e.Item as Subject;
            //Navigation.PushAsync(new SubjectViewer(tappedSubject));
        }
    }
}