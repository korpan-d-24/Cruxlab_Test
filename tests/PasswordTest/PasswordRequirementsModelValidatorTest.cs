using Cruxlab_Test.Models;
using Cruxlab_Test.Validators;
using FluentAssertions;
using Xunit;

namespace PasswordTest;

public class PasswordRequirementsModelValidatorTest
{
    private PasswordRequirementsModelValidator testCase;
    
    public PasswordRequirementsModelValidatorTest()
    {
        testCase = new PasswordRequirementsModelValidator();
    }
    
    [Theory]
    [InlineData("a", 1, 5, "abcdj")]
    [InlineData("b", 3, 6, "bhhkkbbjjjb")]
    public async Task PasswordRequirementsModelValidator_Returns_ValidResult(string obligatedSymbol, int minLetterCount, int maxLetterCount, string password)
    {
        var dto = new PasswordRequirementsModel { ObligatedSymbol = obligatedSymbol, MinLetterCount = minLetterCount, MaxLetterCount = maxLetterCount, Password = password };
        var result = await testCase.ValidateAsync(dto);
        
        result.IsValid.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("z", 2, 4, "asfalseiruqwo")]
    public async Task PasswordRequirementsModelValidator_Returns_InvalidResult(string obligatedSymbol, int minLetterCount, int maxLetterCount, string password)
    {
        var dto = new PasswordRequirementsModel { ObligatedSymbol = obligatedSymbol, MinLetterCount = minLetterCount, MaxLetterCount = maxLetterCount, Password = password };
        var result = await testCase.ValidateAsync(dto);
        
        result.IsValid.Should().BeFalse();
    }
}
