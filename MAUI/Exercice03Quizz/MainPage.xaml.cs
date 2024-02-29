using Exercice03Quizz.Pages;

namespace Exercice03Quizz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Question1());
        }
    }
}
