using ReHub.Utilities.Extensions;

namespace ReHub.Utilities.Tests
{
    [TestClass]
    public class TemplateMailTests
    {
        [TestMethod]
        public void TestEmailTemplate()
        {
            var context = new {
                verification_url ="http://localhost/mytoken",
                img_folder="http://localhost/images",
                name="Mario",
                surname="Z."
            };
            var result = "email_address_verification.html".ParseFile(context);
            Assert.AreEqual(result.Length, 173458);
        }
    }
}
