using intuito.test.helper;

namespace intuito_test.test
{

    public class EmailTest
    {
        [Theory]
        [InlineData("invalid@invalid.invalid",false)]
        [InlineData("elgrego@gmail.com", true)]
        public void ValidateEmail(string email,bool expected)
        {

            //Arrange
            var mailValidator = new EmailValidatorHelper();

            //Act
            bool isValid = mailValidator.EmailValidator(email);

            //Assert
            Assert.Equal(isValid, expected);
        }
    }
}
