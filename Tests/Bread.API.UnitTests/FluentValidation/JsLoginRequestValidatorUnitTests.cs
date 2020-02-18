using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentValidation.Results;
using Bread.API.Schemas.Accounts;
using FluentValidation.TestHelper;

namespace Bread.API.UnitTests.FluentValidation
{
    public class JsLoginRequestValidatorUnitTests
    {
        readonly JsLoginRequestValidator validator = new JsLoginRequestValidator();

        [Fact]
        public void Pass_When_PasswordIsValid()
        {
            //Arrange
            //Act
            validator.ShouldNotHaveValidationErrorFor(jsLoginRequest => jsLoginRequest.Password, "Passw0rd!");
            //Assert
        }

        [Fact]
        public void Pass_When_PasswordIsEmpty()
        {
            //Arrange
            //Act
            //Assert
            validator.ShouldNotHaveValidationErrorFor(jsLoginRequest => jsLoginRequest.Password, (string)null);
            validator.ShouldNotHaveValidationErrorFor(jsLoginRequest => jsLoginRequest.Password, string.Empty);
        }

        [Fact]
        public void Error_When_PasswordIsTooLong()
        {
            //Arrange
            //Act
            //Assert
            validator.ShouldHaveValidationErrorFor(jsLoginRequest => jsLoginRequest.Password,
                "1234567890123456789012345678901"
                );
        }

    }
}
