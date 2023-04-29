using DemoQA.Tests.Navigation.LeftPanel;
using NUnit.Framework;

namespace DemoQA.Tests.Elements
{
    public class TextBoxTests : BaseTest
    {
        [TestCase("John Smith", "john.smith@test.com", "8162 Pumpkin Hill Avenue, Ogden, UT 84404", "8947 North Lake Forest St., Dickson, TN 37055")]
        [TestCase("Sarah Bond", "sarah.bond@test.com", "92 Elizabeth Court, Niagara Falls, NY 14304", "4 High Point Drive, Dyersburg, TN 38024")]
        public void SubmitData(string fullName, string email, string currentAddress, string permanentAddress)
        {
            var textBoxPage = LeftPanel.Elements.TextBox()
                .SubmitData(fullName, email, currentAddress, permanentAddress);

            var actualFullName = textBoxPage.GetSubmittedFullName();
            var actualEmail = textBoxPage.GetSubmittedEmail();
            var actualCurrentAddress = textBoxPage.GetSubmittedCurrentAddress();
            var actualPermanentAddress = textBoxPage.GetSubmittedPermanentAddress();

            Assert.Multiple(() =>
            {
                Assert.That(actualFullName, Is.EqualTo(fullName), "Wrong Full Name");
                Assert.That(actualEmail, Is.EqualTo(email), "Wrong Email");
                Assert.That(actualCurrentAddress, Is.EqualTo(currentAddress), "Wrong Current Address");
                Assert.That(actualPermanentAddress, Is.EqualTo(permanentAddress), "Wrong Permanent Address");
            });
        }
    }
}
