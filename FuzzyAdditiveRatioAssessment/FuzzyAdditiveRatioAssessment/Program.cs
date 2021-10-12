using System;
using FuzzyAdditiveRatioAssessment;

Console.WriteLine("Enter the number of criteria.");
int criterias = ConsoleInput.ReadIntAboveOrEquals(1);

Console.WriteLine("Enter the number of alternatives.");
int alternatives = ConsoleInput.ReadIntAboveOrEquals(2);

Console.WriteLine("Enter the number of experts.");
int experts = ConsoleInput.ReadIntAboveOrEquals(1);

Console.WriteLine("Enter the importance of criteria.");
string[,] criteriasLinguisticImportance = new string[experts, criterias];
for (int expert = 0; expert < experts; expert++)
    for (int criteria = 0; criteria < criterias; criteria++)
    {
        Console.WriteLine($"Expert {expert + 1}, criteria {criteria + 1}:");
        criteriasLinguisticImportance[expert, criteria] = ConsoleInput.ChooseFrom(LinguisticTerms.GetAll);
    }


Console.WriteLine("Enter estimates of alternatives.");
string[,,] alternativesEstimates = new string[experts, alternatives, criterias];
for (int expert = 0; expert < experts; expert++)
    for (int alternative = 0; alternative < alternatives; alternative++)
        for (int criteria = 0; criteria < criterias; criteria++)
        {
            Console.WriteLine($"Expert {expert + 1}, alternative {alternative + 1}, criteria {criteria + 1}:");
            alternativesEstimates[expert, alternative, criteria] = ConsoleInput.ChooseFrom(LinguisticTerms.GetAll);
        }



Console.WriteLine("asdas");
//namespace FuzzyAdditiveRatioAssessment
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}
