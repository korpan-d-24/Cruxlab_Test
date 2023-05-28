namespace Cruxlab_Test.Models;

/// <summary>
/// 
/// </summary>
public class PasswordRequirementsModel
{
    /// <summary>
    /// Symbol that password must contain to be valid, can be letter, number or other symbol
    /// </summary>
    public string ObligatedSymbol { get; init; }
    
    /// <summary>
    /// Min count of obligated letter that password must contain to be valid
    /// </summary>
    public int MinLetterCount { get; init; }
    
    /// <summary>
    /// Max count of obligated letter that password must contain to be valid
    /// </summary>
    public int MaxLetterCount { get; init; }
    
    /// <summary>
    /// Password, can be valid or not depends on conditions 
    /// </summary>
    public string Password { get; init; }
}