using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercice02Calculatrice
{
    public partial class MainPage : ContentPage
    {
        string operationValue1 = "";
        string operationOperator = "";
        string operationValue2 = "";


        public MainPage()
        {
            InitializeComponent();
        }

        private void OnFunctionClicked(object sender, EventArgs e)
        {
            Button? functionButton = sender as Button;
            string function = functionButton!.Text;

            switch (function)
            {
                case "AC":
                    operationValue1 = "";
                    operationValue2 = "";
                    operationOperator = "";
                    UpdateResult();
                    break;
                case "±":
                    if (operationValue1 != "")
                        operationValue1 = (int.Parse(operationValue1) * -1).ToString();
                    else if (operationValue2 != "")
                        operationValue2 = (int.Parse(operationValue2) * -1).ToString();
                    UpdateResult();
                    break;
            }
        }
        

        private void OnDigitClicked(object sender, EventArgs e)
        {
            Button? digitButton = sender as Button;
            string digit = digitButton!.Text;

            if (operationOperator == "")
                operationValue1 += digit;
            else
                operationValue2 += digit;

            UpdateResult();
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            int result = 0;

            switch (operationOperator)
            {
                case "+":
                    result = int.Parse(operationValue1) + int.Parse(operationValue2);
                    break;
                case "-":
                    result = int.Parse(operationValue1) - int.Parse(operationValue2);
                    break;
                case "x":
                    result = int.Parse(operationValue1) * int.Parse(operationValue2);
                    break;
                case "÷":
                    result = int.Parse(operationValue1) / int.Parse(operationValue2);
                    break;
            }

            operationOperator = "";
            operationValue1 = result.ToString();
            operationValue2 = "";

            UpdateResult();
        }        

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            Button? operatorButton = sender as Button;
            operationOperator = operatorButton!.Text;
        }

        private void UpdateResult()
        {
            if (operationValue1 == "")
            {
                LblResult.Text = "0";
                return;
            }

            if (operationOperator == "")
                LblResult.Text = operationValue1;
            else
                LblResult.Text = operationValue2;
        }
    }
}
