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

        //  Première manière de faire le test avec un TestCase

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

        //  Seconde manière de faire le test avec un TestCaseSource

        public static object[] GradeCases =
        {
            new object[] { 95, 90, 'A' },
            new object[] { 85, 90, 'B' },
            new object[] { 65, 90, 'C' },
            new object[] { 95, 65, 'B' },
            new object[] { 95, 55, 'F' },
            new object[] { 65, 55, 'F' },
            new object[] { 50, 90, 'F' }
        };

        [TestCaseSource(nameof(GradeCases))]
        public void Should_GetGrade_InputScoreAndPercentage_GetRightGrade_Source(int score, int attendancePercentage, char grade)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendancePercentage;

            Assert.That(_gradingCalculator.GetGrade(), Is.EqualTo(grade));
        }
    }
}