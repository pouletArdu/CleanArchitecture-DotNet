using System;
using TechTalk.SpecFlow;

namespace Test.StepDefinitions
{
    [Binding]
    public class CalculetteStepDefinitions
    {
        private Calculator calculator;

        private int first = 0;
        private int second = 0;
        private int result = -1;
        public CalculetteStepDefinitions()
        {
            calculator = new Calculator();
        }

        [Given(@"le premier est (.*)")]
        public void GivenLePremierEst(int p0)
        {
            first = p0;
        }

        [Given(@"le deuxième est (.*)")]
        public void GivenLeDeuxiemeEst(int p0)
        {
            second = p0;
        }

        [When(@"on additionne")]
        public void WhenOnAdditionne()
        {
           result = calculator.Sum(first, second);
        }

        [Then(@"on obtient (.*)")]
        public void ThenOnObtient(int p0)
        {
            Assert.Equal(p0, result);
        }
    }
}
