using Cruxlab_Test.Models;
using Cruxlab_Test.Validators;

public class CruxlabTest
{
    const string filePath = @"C:\Users\Asus\RiderProjects\Cruxlab_Test\Cruxlab_Test\TestData.txt";
    static void Main()
    {
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int validPasswordCount = 0;
                var validator = new PasswordRequirementsModelValidator();
                // Read and process lines from the file until the end is reached
                while ((line = sr.ReadLine()) is not null)
                {
                    // Process each line here
                    string[] parts = line.Split(new[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    var checkPassword = new PasswordRequirementsModel
                    {
                        ObligatedSymbol = parts[0],
                        MinLetterCount = int.Parse(parts[1]),
                        MaxLetterCount = int.Parse(parts[2]),
                        Password = parts[3],
                    };
                    // check if password is valid
                    var result = validator.Validate(checkPassword);
                    if (result.IsValid)
                        validPasswordCount++;
                }
                Console.WriteLine($"Count of valid passwords in file = {validPasswordCount}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }
}