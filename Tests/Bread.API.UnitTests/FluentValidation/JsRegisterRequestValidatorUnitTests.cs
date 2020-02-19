using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentValidation.Results;
using Bread.API.Schemas.Accounts;
using FluentValidation.TestHelper;
using Moq;
using Bread.Application.Services;
using System.Threading.Tasks;

namespace Bread.API.UnitTests.FluentValidation
{
    public class JsRegisterRequestValidatorUnitTests
    {
        private readonly JsRegisterUserRequestValidator validator;
        private bool isEmailUnique = true;

        public JsRegisterRequestValidatorUnitTests()
        {
            var userValidationServiceMock = new Mock<IUserValidationService>();
            userValidationServiceMock.Setup<Task<bool>>(s => s.IsEmailUnique(It.IsAny<string>(), default)).Returns(() => Task.FromResult(isEmailUnique));
            validator = new JsRegisterUserRequestValidator(userValidationServiceMock.Object);
        }

        [Fact]
        public void Pass_When_FormalNameIsValid()
        {
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.FormalName, "A");
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.FormalName,
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "123456789012345678901234567890123456789012345678901234"
            );
        }

        [Fact]
        public void Pass_When_FormalNameIsNullOrEmpty()
        {
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.FormalName, (string)null);
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.FormalName, "");
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.FormalName, string.Empty);
        }

        [Fact]
        public void Error_When_FormalNameIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.FormalName,
                "A1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345"
                );
        }

        [Fact]
        public void Pass_When_PreferredNameIsValid()
        {
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.PreferredName, "A");
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.PreferredName,
                "A1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "123456789012345678901234567890123456789012345678901234"
            );
        }

        [Fact]
        public void Error_When_PreferredNameIsNullOrEmpty()
        {
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.PreferredName, (string)null);
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.PreferredName, "");
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.PreferredName, string.Empty);
        }

        [Fact]
        public void Error_When_PreferredNameIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.PreferredName,
                "A1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345"
                );
        }

        [Fact]
        public void Pass_When_EmailIsValid()
        {
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.Email, "A@A.com");
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.Email, "A@A");
        }

        [Fact]
        public void Error_When_EmailIsInvalidFormat()
        {
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.Email, "string");
        }

        [Fact]
        public void Pass_When_EmailIsNull()
        {
            validator.ShouldNotHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.Email, (string)null);
        }

        [Fact]
        public void Error_When_EmailIsEmpty()
        {
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.Email, string.Empty);
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.Email, "");
        }

        [Fact]
        public void Error_When_EmailIsNotUnique()
        {
            this.isEmailUnique = false;
            validator.ShouldHaveValidationErrorFor(jsRegisterRequest => jsRegisterRequest.Email, "A@A.com");
            this.isEmailUnique = true;
        }

    }
}
