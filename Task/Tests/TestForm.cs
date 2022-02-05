using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Task.Data;
using Task.Models;
using Task.Pages;
using Task.Utils;

namespace Task.Tests
{
    public class TestForm:BaseTest
    {
        string pathToFile = Path.GetFullPath(string.Format("Resources/{0}",ConfigsData.nameOfFile));
        private PracticeFormPage practiceFormPage = new PracticeFormPage();
        private SubmittingFormPage submittingFormPage = new SubmittingFormPage();
       
        [Test]
        public void TestPracticeForm()
        {
            string nameStudent = Randomaser.RandomString();
            string lastName = Randomaser.RandomString();
            string email = string.Format(TestData.formatEmail, Randomaser.RandomString(5), Randomaser.RandomString(5), Randomaser.RandomString(3));
  
            Assert.IsTrue(practiceFormPage.State.IsDisplayed, "Page not displayed");

            practiceFormPage
                            .EnterName(nameStudent)
                            .EnterLastName(lastName)
                            .EnterEmail(email);

            var gender = practiceFormPage.ChooseGender();
            var number = practiceFormPage.EnterPhoneNumber();
            var birthDay = practiceFormPage.EnterBirthday(TestData.yearOfBD, TestData.monthOfBD, TestData.dayOfBD);
            var hobbies = practiceFormPage.EnterHobbies();
            practiceFormPage.UploadFile(pathToFile);
            var stateAndCity = practiceFormPage.SelectStateAndCity();
            practiceFormPage.ClickBySubmitButton();
                            
            Assert.IsTrue(submittingFormPage.State.IsDisplayed, "Page not displayed");

            var submittingFormFromPage = submittingFormPage.GetValuesFromForm();

            SubmittingFormModel submittingFormModel = new SubmittingFormModel
            {
                  StudentName = string.Format("{0} {1}", nameStudent, lastName),
                  StudentEmail = email,
                  Gender = gender,
                  Mobile = number,
                  DateOfBirth = birthDay,
                  Hobbies = hobbies,
                  Picture = ConfigsData.nameOfFile,
                  StateAndCity = stateAndCity
            };

            Assert.Multiple(() =>
           {
                Assert.AreEqual(submittingFormModel.StudentName, submittingFormFromPage.StudentName, "Names are not equal");
                Assert.AreEqual(submittingFormModel.StudentEmail, submittingFormFromPage.StudentEmail, "Emails are not equal");
                Assert.AreEqual(submittingFormModel.Gender, submittingFormFromPage.Gender, "Genders are not equal");
                Assert.AreEqual(submittingFormModel.Mobile, submittingFormFromPage.Mobile, "Mobiles are not equal");
                Assert.AreEqual(submittingFormModel.DateOfBirth, submittingFormFromPage.DateOfBirth, "Dates of birth are not equal");
                Assert.AreEqual(submittingFormModel.Hobbies, submittingFormFromPage.Hobbies, "Hobbies are not equal");
                Assert.AreEqual(submittingFormModel.Picture, submittingFormFromPage.Picture, "Pictures are not equal");
                Assert.AreEqual(submittingFormModel.StateAndCity, submittingFormFromPage.StateAndCity, "States and city are not equal");
           });
        }
    }
}
