using DemoQA.Pages.PageElements;
using SeleniumExtras.PageObjects;

namespace DemoQA.Pages.ElementsSectionPages
{
    public class TextBoxPage : BasePage
    {
        [FindsBy(How.Id, "userName")]
        private InputElement FullNameInput { get; set; }

        [FindsBy(How.Id, "userEmail")]
        private InputElement EmailInput { get; set; }

        [FindsBy(How.Id, "currentAddress")]
        private InputElement CurrentAddressInput { get; set; }

        [FindsBy(How.Id, "permanentAddress")]
        private InputElement PermanentAddressInput { get; set; }

        [FindsBy(How.Id, "submit")]
        private ButtonElement SubmitButton { get; set; }

        [FindsBy(How.CssSelector, "p#name")]
        private TextFieldElement SubmittedFullName { get; set; }

        [FindsBy(How.CssSelector, "p#email")]
        private TextFieldElement SubmittedEmail { get; set; }

        [FindsBy(How.CssSelector, "p#currentAddress")]
        private TextFieldElement SubmittedCurrentAddress { get; set; }

        [FindsBy(How.CssSelector, "p#permanentAddress")]
        private TextFieldElement SubmittedPermanentAddress { get; set; }

        private TextBoxPage InputFullName(string fullName)
        {
            FullNameInput.ClearAndInput(fullName, true);
            return this;
        }

        private TextBoxPage InputEmail(string email)
        {
            EmailInput.ClearAndInput(email, true);

            return this;
        }

        private TextBoxPage InputCurrentAddress(string currentAddress)
        {
            CurrentAddressInput.ClearAndInput(currentAddress, true);

            return this;
        }

        private TextBoxPage InputPermanentAddress(string permanentAddress)
        {
            PermanentAddressInput.ClearAndInput(permanentAddress, true);

            return this;
        }

        private TextBoxPage ClickSubmitButton()
        {
            SubmitButton.Click();

            return this;
        }

        public TextBoxPage SubmitData(string fullName, string email, string currentAddress, string permanentAddres)
        {
            return InputFullName(fullName)
                .InputEmail(email)
                .InputCurrentAddress(currentAddress)
                .InputPermanentAddress(permanentAddres)
                .ClickSubmitButton();
        }

        public string GetSubmittedFullName() => SubmittedFullName.GetText().Split(":")[1];

        public string GetSubmittedEmail() => SubmittedEmail.GetText().Split(":")[1];

        public string GetSubmittedCurrentAddress() => SubmittedCurrentAddress.GetText().Split(":")[1];

        public string GetSubmittedPermanentAddress() => SubmittedPermanentAddress.GetText().Split(":")[1];
    }
}
