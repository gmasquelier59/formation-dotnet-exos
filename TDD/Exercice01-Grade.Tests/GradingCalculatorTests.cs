namespace Exercice01_Grade.Tests
{
    public class GradingCalculatorTests
    {
        private GradingCalculator _gradingCalculator;

        [SetUp]
        public void Setup()
        {
            _gradingCalculator = new GradingCalculator();
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = 'A')]
        [TestCase(85, 90, ExpectedResult = 'B')]
        [TestCase(65, 90, ExpectedResult = 'C')]
        [TestCase(95, 65, ExpectedResult = 'B')]
        [TestCase(95, 55, ExpectedResult = 'F')]
        [TestCase(65, 55, ExpectedResult = 'F')]
        [TestCase(50, 90, ExpectedResult = 'F')]
        public char Should_GetGrade_InputScoreAndPercentage_GetRightGrade(int score, int attendancePercentage)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendancePercentage;

            return _gradingCalculator.GetGrade();
        }
    }
}