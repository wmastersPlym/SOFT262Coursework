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
    public partial class NewCard : ContentPage
    {
        private Topic topic;

        public NewCard(Topic topic)
        {
            this.topic = topic;
            InitializeComponent();
        }

        private void DoneClicked(object sender, EventArgs e)
        {
            topic.AddCard(new Card(QuestionInput.Text, AnswerInput.Text));
            Navigation.PopAsync();
        }
    }
}