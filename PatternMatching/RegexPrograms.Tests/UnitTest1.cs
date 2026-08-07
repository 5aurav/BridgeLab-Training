using NUnit.Framework;
using RegexPrograms;

namespace RegexPrograms.Tests
{
    public class RegexTests
    {
        private RegexUtility regexUtility;

        [SetUp]
        public void Setup()
        {
            regexUtility = new RegexUtility();
        }

        [Test]
        public void ValidateUsername_ValidUsername_ReturnsTrue()
        {
            bool result = regexUtility.ValidateUsername("user_123");

            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateUsername_StartsWithNumber_ReturnsFalse()
        {
            bool result = regexUtility.ValidateUsername("123user");

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateUsername_TooShort_ReturnsFalse()
        {
            bool result = regexUtility.ValidateUsername("us");

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateUsername_ContainsSpecialCharacter_ReturnsFalse()
        {
            bool result = regexUtility.ValidateUsername("user@12");

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateUsername_TooLong_ReturnsFalse()
        {
            bool result = regexUtility.ValidateUsername("abcdefghijklmnopqrstuvwxyz");

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateUsername_StartsWithUnderscore_ReturnsFalse()
        {
            bool result = regexUtility.ValidateUsername("_user12");

            Assert.That(result, Is.False);
        }
        [Test]
        public void ValidateLicensePlate_Valid_ReturnsTrue()
        {
            Assert.That(regexUtility.ValidateLicensePlate("AB1234"), Is.True);
        }

        [Test]
        public void ValidateLicensePlate_Invalid_ReturnsFalse()
        {
            Assert.That(regexUtility.ValidateLicensePlate("A12345"), Is.False);
        }

        [Test]
        public void ValidateLicensePlate_LowerCase_ReturnsFalse()
        {
            Assert.That(regexUtility.ValidateLicensePlate("ab1234"), Is.False);
        }
        [Test]
        public void ValidateHexColor_Valid_ReturnsTrue()
        {
            Assert.That(regexUtility.ValidateHexColor("#FFA500"), Is.True);
        }

        [Test]
        public void ValidateHexColor_LowerCase_ReturnsTrue()
        {
            Assert.That(regexUtility.ValidateHexColor("#ff4500"), Is.True);
        }

        [Test]
        public void ValidateHexColor_Invalid_ReturnsFalse()
        {
            Assert.That(regexUtility.ValidateHexColor("#123"), Is.False);
        }
        [Test]
        public void ExtractEmails_ReturnsTwoEmails()
        {
            string text = "Contact support@example.com and info@company.org";

            List<string> result = regexUtility.ExtractEmails(text);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo("support@example.com"));
            Assert.That(result[1], Is.EqualTo("info@company.org"));
        }

        [Test]
        public void ExtractCapitalizedWords_ReturnsWords()
        {
            string text = "The Eiffel Tower is in Paris and the Statue of Liberty is in New York.";

            List<string> result = regexUtility.ExtractCapitalizedWords(text);

            Assert.That(result.Count, Is.EqualTo(8));
            Assert.That(result, Does.Contain("Eiffel"));
            Assert.That(result, Does.Contain("Paris"));
            Assert.That(result, Does.Contain("York"));
        }

        [Test]
        public void ExtractDates_ReturnsAllDates()
        {
            string text = "Events are on 12/05/2023, 15/08/2024 and 29/02/2020.";

            List<string> result = regexUtility.ExtractDates(text);

            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test]
        public void ExtractLinks_ReturnsTwoLinks()
        {
            string text = "Visit https://google.com and http://example.org";

            List<string> result = regexUtility.ExtractLinks(text);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void ReplaceMultipleSpaces_ReturnsSingleSpaces()
        {
            string result = regexUtility.ReplaceMultipleSpaces("This    is     a    test");

            Assert.That(result, Is.EqualTo("This is a test"));
        }

        [Test]
        public void CensorBadWords_ReplacesWords()
        {
            string result = regexUtility.CensorBadWords("This is a damn stupid example");

            Assert.That(result, Is.EqualTo("This is a **** **** example"));
        }

        [Test]
        public void ValidateIPAddress_Valid()
        {
            Assert.That(regexUtility.ValidateIPAddress("192.168.1.1"), Is.True);
        }

        [Test]
        public void ValidateIPAddress_Invalid()
        {
            Assert.That(regexUtility.ValidateIPAddress("256.10.10.10"), Is.False);
        }

        [Test]
        public void ValidateCreditCard_ValidVisa()
        {
            Assert.That(regexUtility.ValidateCreditCard("4123456789012345"), Is.True);
        }

        [Test]
        public void ValidateCreditCard_Invalid()
        {
            Assert.That(regexUtility.ValidateCreditCard("6123456789012345"), Is.False);
        }

        [Test]
        public void ExtractProgrammingLanguages_ReturnsLanguages()
        {
            string text = "Java Python JavaScript Go";

            List<string> result = regexUtility.ExtractProgrammingLanguages(text);

            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test]
        public void ExtractCurrencyValues_ReturnsValues()
        {
            string text = "Price $45.99 and discount $ 10.50";

            List<string> result = regexUtility.ExtractCurrencyValues(text);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void FindRepeatingWords_ReturnsRepeatedWords()
        {
            string text = "This is is a repeated repeated test";

            List<string> result = regexUtility.FindRepeatingWords(text);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void ValidateSSN_Valid()
        {
            Assert.That(regexUtility.ValidateSSN("123-45-6789"), Is.True);
        }

        [Test]
        public void ValidateSSN_Invalid()
        {
            Assert.That(regexUtility.ValidateSSN("123456789"), Is.False);
        }
    }
}