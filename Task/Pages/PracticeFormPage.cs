using AngleSharp.Text;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Utils;

namespace Task.Pages
{
    public class PracticeFormPage : Form
    {
        private ITextBox FirstNameTextBox => ElementFactory.GetTextBox(By.Id("firstName"), "First name field");

        private ITextBox LastNameTextBox => ElementFactory.GetTextBox(By.Id("lastName"), "Last name field");

        private ITextBox EmailTextBox => ElementFactory.GetTextBox(By.Id("userEmail"), "Email field");

        private List<ITextBox> GengerTextBox => (List<ITextBox>)ElementFactory.FindElements<ITextBox>(By.XPath("//label[contains(@for,'gender')]"));

        private ILabel SumOfNumMobileLabel => ElementFactory.GetLabel(By.Id("userNumber-label"), "Sum of numder for mobile phone");

        private ITextBox PhoneTextBox => ElementFactory.GetTextBox(By.Id("userNumber"), "Phone field");

        private ILabel InputYearLabel(string year) => ElementFactory.GetLabel(By.XPath($"//div[@class='react-datepicker']//select[contains(@class,'year-select')]//option[contains(text(),{year})]"), "Year");

        private ILabel InputMonthLabel(string month) => ElementFactory.GetLabel(By.XPath($"//div[@class='react-datepicker']//select[contains(@class,'month-select')]//option[contains(text(),'{month}')]"), "Month");

        private ILabel InputDayLabel(string day) => ElementFactory.GetLabel(By.XPath($"//div[contains(@class,'datepicker__day')and contains(text(),'{day}')]"), "Day");

        private List<ILabel> EnterCheckBoxHobbies => (List<ILabel>)ElementFactory.FindElements<ILabel>(By.XPath("//label[contains(@for,'hobbies-checkbox')]"), "Hobbies");

        private ITextBox BirthDayTextBox => ElementFactory.GetTextBox(By.Id("dateOfBirthInput"), "Birthday field");

        private IButton UploadButton => ElementFactory.GetButton(By.Id("uploadPicture"), "Upload Button");

        private IButton StateButton => ElementFactory.GetButton(By.Id("state"), "State");

        private IButton CityButton => ElementFactory.GetButton(By.Id("city"), "City");

        private IButton SubmitButton => ElementFactory.GetButton(By.Id("submit"), "Submit");

        private List<IButton> ResultOfStateAndCity => (List<IButton>)ElementFactory.FindElements<IButton>(By.XPath("//div[contains(@class,'singleValue')]"));
        public PracticeFormPage() : base(By.Id("userName-wrapper"), "Practice form") { }

        public PracticeFormPage EnterName(string name)
        {
            FirstNameTextBox.SendKeys(name);
            return this;
        }

        public PracticeFormPage EnterLastName(string lastName)
        {
            LastNameTextBox.SendKeys(lastName);
            return this;
        }

        public PracticeFormPage EnterEmail(string email)
        {
            EmailTextBox.SendKeys(email);
            return this;
        }

        public string ChooseGender()
        {
            var gender = GengerTextBox[Randomaser.RandomInt(GengerTextBox.Count)];
            gender.Click();
            return gender.GetText();
        }

        public string EnterPhoneNumber()
        {
            int.TryParse(string.Join("", SumOfNumMobileLabel.GetText().Where(c => char.IsDigit(c))), out int value);
            IEnumerable<int> nums = Enumerable.Range(0, value);
            foreach (int i in nums)
            {
                PhoneTextBox.SendKeys(i.ToString());
            }
            
            return string.Join("",nums);
        }

        public string EnterHobbies()
        {
            List<string> hobbies = new List<string>();
            foreach(ILabel label in EnterCheckBoxHobbies)
            {
                hobbies.Add(label.GetText());
                label.MouseActions.MoveToElement();
                label.State.WaitForClickable();
                label.Click();
            }
            return string.Join(", ", hobbies);
        }

        public string EnterBirthday(string year,string month,string day)
        {
            string birthday = string.Format("{0} {1},{2}", day, month, year);
            BirthDayTextBox.Click();
            InputMonthLabel(month).Click();
            InputYearLabel(year).Click();
            InputDayLabel(day).Click();
            return birthday;
        }

        public PracticeFormPage UploadFile(string file)
        {
            UploadButton.SendKeys(file);
            return this;
        }

        public string SelectStateAndCity()
        {
            List<string> stateAndCity = new List<string>();
            StateButton.MouseActions.MoveToElement();
            StateButton.State.WaitForClickable();
            StateButton.Click();
            Actions actions = new Actions(AqualityServices.Browser.Driver);
            actions.SendKeys(Keys.ArrowDown + Keys.Enter).Perform();
            CityButton.Click();
            actions.SendKeys(Keys.ArrowDown + Keys.Enter).Perform();
            foreach(IButton button in ResultOfStateAndCity)
            {
                stateAndCity.Add(button.GetText());
            }
            return string.Join(" ", stateAndCity);
        }

        public SubmittingFormPage ClickBySubmitButton()
        {
            SubmitButton.Click();
            return new SubmittingFormPage();
        }
    }
}
