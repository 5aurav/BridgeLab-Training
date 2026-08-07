using NUnit.Framework;
using NUnitPrograms;

namespace NUnitPrograms.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = calculator.Add(10, 5);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            int result = calculator.Subtract(10, 5);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Multiply_ShouldReturnCorrectProduct()
        {
            int result = calculator.Multiply(10, 5);

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            int result = calculator.Divide(10, 5);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Divide_ByZero_ShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                calculator.Divide(10, 0);
            });
        }
    }
    [TestFixture]
    public class StringUtilsTests
    {
        private StringUtils stringUtils;

        [SetUp]
        public void Setup()
        {
            stringUtils = new StringUtils();
        }

        [Test]
        public void Reverse_ShouldReturnReversedString()
        {
            string result = stringUtils.Reverse("Hello");

            Assert.That(result, Is.EqualTo("olleH"));
        }

        [Test]
        public void Reverse_EmptyString_ShouldReturnEmpty()
        {
            string result = stringUtils.Reverse("");

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void IsPalindrome_TrueCase()
        {
            bool result = stringUtils.IsPalindrome("madam");

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_FalseCase()
        {
            bool result = stringUtils.IsPalindrome("hello");

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsPalindrome_IgnoreCase()
        {
            bool result = stringUtils.IsPalindrome("MadAm");

            Assert.That(result, Is.True);
        }

        [Test]
        public void ToUpperCase_ShouldConvertCorrectly()
        {
            string result = stringUtils.ToUpperCase("hello");

            Assert.That(result, Is.EqualTo("HELLO"));
        }

        [Test]
        public void ToUpperCase_AlreadyUpper()
        {
            string result = stringUtils.ToUpperCase("WORLD");

            Assert.That(result, Is.EqualTo("WORLD"));
        }
    }
    [TestFixture]
    public class ListManagerTests
    {
        private ListManager manager;
        private List<int> list;

        [SetUp]
        public void Setup()
        {
            manager = new ListManager();
            list = new List<int>();
        }

        [Test]
        public void AddElement_Test()
        {
            manager.AddElement(list, 10);

            Assert.That(list, Does.Contain(10));
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveElement_Test()
        {
            list.Add(10);
            list.Add(20);

            manager.RemoveElement(list, 10);

            Assert.That(list, Does.Not.Contain(10));
        }

        [Test]
        public void GetSize_Test()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.That(manager.GetSize(list), Is.EqualTo(3));
        }
    }
    [TestFixture]
    public class MathOperationsTests
    {
        private MathOperations math;

        [SetUp]
        public void Setup()
        {
            math = new MathOperations();
        }

        [Test]
        public void Divide_Test()
        {
            Assert.That(math.Divide(20, 5), Is.EqualTo(4));
        }

        [Test]
        public void DivideByZero_Test()
        {
            Assert.Throws<ArithmeticException>(() =>
            {
                math.Divide(10, 0);
            });
        }
    }
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection db;

        [SetUp]
        public void Setup()
        {
            db = new DatabaseConnection();
            db.Connect();
        }

        [TearDown]
        public void TearDown()
        {
            db.Disconnect();
        }

        [Test]
        public void Connection_ShouldBeOpen()
        {
            Assert.That(db.IsConnected, Is.True);
        }

        [Test]
        public void Disconnect_Test()
        {
            db.Disconnect();

            Assert.That(db.IsConnected, Is.False);
        }
    }
    [TestFixture]
    public class NumberCheckerTests
    {
        private NumberChecker checker;

        [SetUp]
        public void Setup()
        {
            checker = new NumberChecker();
        }

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_Test(int number, bool expected)
        {
            Assert.That(checker.IsEven(number), Is.EqualTo(expected));
        }
    }
    [TestFixture]
    public class PerformanceTesterTests
    {
        private PerformanceTester tester;

        [SetUp]
        public void Setup()
        {
            tester = new PerformanceTester();
        }

        [Test]
        [CancelAfter(1000)]
        public void LongRunningTask_Test()
        {
            Assert.That(tester.LongRunningTask(), Is.EqualTo("Completed"));
        }
    }
    [TestFixture]
    public class FileProcessorTests
    {
        private FileProcessor processor;
        private string file = "test.txt";

        [SetUp]
        public void Setup()
        {
            processor = new FileProcessor();
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(file))
                File.Delete(file);
        }

        [Test]
        public void WriteAndRead_Test()
        {
            processor.WriteToFile(file, "Hello NUnit");

            Assert.That(File.Exists(file), Is.True);

            Assert.That(processor.ReadFromFile(file), Is.EqualTo("Hello NUnit"));
        }

        [Test]
        public void FileNotFound_Test()
        {
            Assert.Throws<IOException>(() =>
            {
                processor.ReadFromFile("abc.txt");
            });
        }
    }
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount();
        }

        [Test]
        public void Deposit_Test()
        {
            account.Deposit(5000);

            Assert.That(account.GetBalance(), Is.EqualTo(5000));
        }

        [Test]
        public void Withdraw_Test()
        {
            account.Deposit(5000);
            account.Withdraw(2000);

            Assert.That(account.GetBalance(), Is.EqualTo(3000));
        }

        [Test]
        public void InsufficientBalance_Test()
        {
            account.Deposit(1000);

            Assert.Throws<InvalidOperationException>(() =>
            {
                account.Withdraw(2000);
            });
        }
    }
    [TestFixture]
    public class PasswordValidatorTests
    {
        private PasswordValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [TestCase("Hello123", true)]
        [TestCase("password", false)]
        [TestCase("HELLO", false)]
        [TestCase("Hello", false)]
        [TestCase("HelloWorld", false)]
        [TestCase("12345678", false)]
        public void PasswordValidation_Test(string password, bool expected)
        {
            Assert.That(validator.IsValid(password), Is.EqualTo(expected));
        }
    }
    [TestFixture]
    public class TemperatureConverterTests
    {
        private TemperatureConverter converter;

        [SetUp]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [Test]
        public void CelsiusToFahrenheit_Test()
        {
            Assert.That(converter.CelsiusToFahrenheit(0), Is.EqualTo(32));
        }

        [Test]
        public void FahrenheitToCelsius_Test()
        {
            Assert.That(converter.FahrenheitToCelsius(32), Is.EqualTo(0));
        }

        [Test]
        public void BoilingPoint_Test()
        {
            Assert.That(converter.CelsiusToFahrenheit(100), Is.EqualTo(212));
        }
    }
    [TestFixture]
    public class DateFormatterTests
    {
        private DateFormatter formatter;

        [SetUp]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [Test]
        public void ValidDate_Test()
        {
            Assert.That(
                formatter.FormatDate("2026-08-07"),
                Is.EqualTo("07-08-2026"));
        }

        [Test]
        public void InvalidDate_Test()
        {
            Assert.Throws<FormatException>(() =>
            {
                formatter.FormatDate("07/08/2026");
            });
        }
    }
    [TestFixture]
    public class UserRegistrationTests
    {
        private UserRegistration registration;

        [SetUp]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [Test]
        public void ValidRegistration_Test()
        {
            Assert.That(
                registration.RegisterUser(
                    "Saurav",
                    "saurav@gmail.com",
                    "Password123"),
                Is.True);
        }

        [Test]
        public void InvalidUsername_Test()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                registration.RegisterUser(
                    "",
                    "abc@gmail.com",
                    "Password123");
            });
        }

        [Test]
        public void InvalidEmail_Test()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                registration.RegisterUser(
                    "Saurav",
                    "gmail.com",
                    "Password123");
            });
        }

        [Test]
        public void InvalidPassword_Test()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                registration.RegisterUser(
                    "Saurav",
                    "abc@gmail.com",
                    "pass");
            });
        }
    }
}