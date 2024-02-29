using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercice01NombreMystere
{
    public partial class MainPage : ContentPage
    {
        int NumberToGuess;
        int NumberOfTries;

        public MainPage()
        {


            InitializeComponent();

            Init();
        }

        protected override void OnAppearing()
        {
#if WINDOWS
            this.Window.MinimumHeight = 500;
            this.Window.MinimumWidth = 600;
#endif
        }

        private async void UpdateNumberOfRetries()
        {
            Image? heart = null;

            if (NumberOfTries == 4)
                heart = ImgLife5;
            else if (NumberOfTries == 3)
                heart = ImgLife4;
            else if (NumberOfTries == 2)
                heart = ImgLife3;
            else if (NumberOfTries == 1)
                heart = ImgLife2;

            if (heart == null)
                return;

            heart!.Opacity = 1;
            await heart.ScaleTo(2, 250);
            heart.ScaleTo(0, 500);
            await heart.FadeTo(0, 500);
        }

        private void Init()
        {
            Random rand = new Random();
            NumberToGuess = rand.Next(1, 21);
            NumberOfTries = 5;
            ResetBtn.IsVisible = false;
            TestResult.Text = "";
            Container.IsVisible = true;
            NumberToTest.Text = "";
            ImgLife1.Opacity = 1;
            ImgLife1.Scale = 1;
            ImgLife2.Opacity = 1;
            ImgLife2.Scale = 1;
            ImgLife3.Opacity = 1;
            ImgLife3.Scale = 1;
            ImgLife4.Opacity = 1;
            ImgLife4.Scale = 1;
            ImgLife5.Opacity = 1;
            ImgLife5.Scale = 1;
        }


        private void OnResetBtnClicked(object sender, EventArgs e)
        {
            Init();
        }

        private void OnTestBtnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NumberToTest.Text))
                return;

            int numberToTest;
            if (!int.TryParse(NumberToTest.Text, out numberToTest))
            {
                TestResult.TextColor = Color.FromArgb("#D32F2F");
                TestResult.Text = "La valeur saisie doit être uniquement composée de chiffres !";
                return;
            }

            if (numberToTest != NumberToGuess)
            {
                NumberOfTries--;
                UpdateNumberOfRetries();

                if (NumberOfTries == 0)
                {
                    TestResult.TextColor = Color.FromArgb("#D32F2F");
                    TestResult.Text = "Perdu ! Le nombre à trouver était " + NumberToGuess;
                    ResetBtn.IsVisible = true;
                    Container.IsVisible = false;
                    ImgLife1.Opacity = 0;
                    ImgLife2.Opacity = 0;
                    ImgLife3.Opacity = 0;
                    ImgLife4.Opacity = 0;
                    ImgLife5.Opacity = 0;
                }
                else
                {
                    NumberToTest.Text = "";
                    TestResult.TextColor = Color.FromArgb("#FF8F00");
                    if (numberToTest < NumberToGuess)
                        TestResult.Text = $"Le nombre à deviner est plus grand. Il vous reste {NumberOfTries} essai(s)";
                    else
                        TestResult.Text = $"Le nombre à deviner est plus petit. Il vous reste {NumberOfTries} essai(s)";
                }
            }
            else
            {
                TestResult.TextColor = Color.FromArgb("#4CAF50");
                TestResult.Text = "Bravo ! Le nombre à trouver était bien " + NumberToGuess;
                ResetBtn.IsVisible = true;
                Container.IsVisible = false;
                ImgLife1.Opacity = 0;
                ImgLife2.Opacity = 0;
                ImgLife3.Opacity = 0;
                ImgLife4.Opacity = 0;
                ImgLife5.Opacity = 0;
            }
        }
    }

}
