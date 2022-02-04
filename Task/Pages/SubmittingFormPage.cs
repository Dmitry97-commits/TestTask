using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Models;

namespace Task.Pages
{
    public class SubmittingFormPage:Form
    {
        private List<ITextBox> ListOfValues => (List<ITextBox>)ElementFactory.FindElements<ITextBox>(By.XPath("//tbody//tr//td[2]"));

        public SubmittingFormPage() : base(By.Id("example-modal-sizes-title-lg"), "Submitting form") { }

        public SubmittingFormModel GetValuesFromForm()
        {
             SubmittingFormModel submittingFormModel = new SubmittingFormModel
             {
                 StudentName = ListOfValues[(int)Fields.StudentName].GetText(),
                 StudentEmail = ListOfValues[(int)Fields.StudentEmail].GetText(),
                 Gender = ListOfValues[(int)Fields.Gender].GetText(),
                 Mobile = ListOfValues[(int)Fields.Mobile].GetText(),
                 DateOfBirth = ListOfValues[(int)Fields.DateOfBirth].GetText(),
                 Hobbies = ListOfValues[(int)Fields.Hobbies].GetText(),
                 Picture = ListOfValues[(int)Fields.Picture].GetText(),
             };
             return submittingFormModel;
        }

        enum Fields
        {
            StudentName = 0,
            StudentEmail,
            Gender,
            Mobile,
            DateOfBirth,
            Hobbies = 6,
            Picture
        }
    }
}
