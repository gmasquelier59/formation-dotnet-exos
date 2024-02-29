namespace Exercice03Quizz.Pages;

public partial class Question7 : ContentPage
{
    Button RightAnswer;
    List<Button> WrongAnswers;

	public Question7()
	{
		InitializeComponent();

        RightAnswer = Answer3;
        RightAnswer.ZIndex = 1000;
        WrongAnswers = new List<Button> { Answer1, Answer2, Answer4 };
    }

    private async void AnswerClicked(object sender, EventArgs e)
    {
        Button answer = (Button)sender;

        if (answer == RightAnswer)
        {
            RightAnswer.BackgroundColor = Color.FromArgb("#0f0");
            await RightAnswer.ScaleTo(1.2, 500);
            await Navigation.PopToRootAsync();
        }
        else
        {
            foreach (Button wrongAnswer in WrongAnswers)
                wrongAnswer.BackgroundColor = Color.FromArgb("#f00");
            RightAnswer.BackgroundColor = Color.FromArgb("#0f0");
            await RightAnswer.ScaleTo(1.2, 500);
            await Navigation.PopAsync();
        }
    }
}