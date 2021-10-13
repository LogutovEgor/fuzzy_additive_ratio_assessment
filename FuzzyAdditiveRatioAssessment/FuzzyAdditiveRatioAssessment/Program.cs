using System;
using System.Linq;
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

Console.WriteLine("Importance of criterias:");
for (int i = 0; i <= experts; i++)
{
    for (int j = 0; j <= criterias; j++)
    {
        if (i == 0 && j == 0)
        {
            Console.Write(String.Format("{0,16}|", ""));
        }
        else if (i == 0 && j > 0)
        {
            Console.Write(String.Format("{0,16}|", $"Criterion {j}"));
        }
        else if (i > 0 && j == 0)
        {
            Console.Write(String.Format("{0,16}|", $"Expert {i}"));
        }
        else
        {
            Console.Write(String.Format("{0,16}|", $"{criteriasLinguisticImportance[i - 1, j - 1]}"));
        }
    }
    Console.WriteLine();
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

Console.WriteLine("Estimates of alternatives:");
for (int i = 0; i < experts; i++)
{
    Console.WriteLine($"Expert #{i + 1}");
    for (int j = 0; j <= alternatives; j++)
    {
        for (int k = 0; k <= criterias; k++)
        {
            if (j == 0 && k == 0)
            {
                Console.Write(String.Format("{0,16}|", ""));
            }
            else if (j == 0 && k > 0)
            {
                Console.Write(String.Format("{0,16}|", $"Criterion {k}"));
            }
            else if (j > 0 && k == 0)
            {
                Console.Write(String.Format("{0,16}|", $"Alternative {j}"));
            }
            else
            {
                Console.Write(String.Format("{0,16}|", $"{alternativesEstimates[i, j - 1, k - 1]}"));
            }
        }
        Console.WriteLine();
    }
}
/////////////////////////////////
string[,][] alternativesEstimatesGrouped = new string[alternatives, criterias][];
for (int alternative = 0; alternative < alternatives; alternative++)
{
    for (int criteria = 0; criteria < criterias; criteria++)
    {
        alternativesEstimatesGrouped[alternative, criteria] = new string[experts];
        for (int expert = 0; expert < experts; expert++)
        {
            alternativesEstimatesGrouped[alternative, criteria][expert] =
                alternativesEstimates[expert, alternative, criteria];
        }
    }
}




        TriangularNumber[,] criteriasTriangularImportance = new TriangularNumber[experts, criterias];
for (int expert = 0; expert < experts; expert++)
    for (int criteria = 0; criteria < criterias; criteria++)
        criteriasTriangularImportance[expert, criteria] = LinguisticTerms.ConvertToTriangularFromLinguistic(criteriasLinguisticImportance[expert, criteria]);

Console.WriteLine("Triangular fuzzy numbers(criteria):");
for (int i = 0; i <= experts; i++)
{
    for (int j = 0; j <= criterias; j++)
    {
        if (i == 0 && j == 0)
        {
            Console.Write(String.Format("{0,16}|", ""));
        }
        else if (i == 0 && j > 0)
        {
            Console.Write(String.Format("{0,16}|", $"Criterion {j}"));
        }
        else if (i > 0 && j == 0)
        {
            Console.Write(String.Format("{0,16}|", $"Expert {i}"));
        }
        else
        {
            Console.Write(String.Format("{0,16}|", $"{criteriasTriangularImportance[i - 1, j - 1]}"));
        }
    }
    Console.WriteLine();
}





