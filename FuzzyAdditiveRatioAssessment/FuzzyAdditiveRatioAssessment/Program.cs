using System;
using System.Linq;
using FuzzyAdditiveRatioAssessment;

bool testData = false;

Console.WriteLine("Enter the number of criteria.");
int criterias = testData ? 4 : ConsoleInput.ReadIntAboveOrEquals(1);

Console.WriteLine("Enter the number of alternatives.");
int alternatives = testData ? 3 : ConsoleInput.ReadIntAboveOrEquals(2);

Console.WriteLine("Enter the number of experts.");
int experts = testData ? 3 : ConsoleInput.ReadIntAboveOrEquals(1);

Console.WriteLine("Enter the importance of criteria.");
string[,] criteriasLinguisticImportance = new string[experts, criterias];

if (testData)
{
    criteriasLinguisticImportance[0, 0] = LinguisticTerms.HIGH;
    criteriasLinguisticImportance[0, 1] = LinguisticTerms.MEDIUM;
    criteriasLinguisticImportance[0, 2] = LinguisticTerms.HIGH;
    criteriasLinguisticImportance[0, 3] = LinguisticTerms.MEDIUM;
    //
    criteriasLinguisticImportance[1, 0] = LinguisticTerms.MEDIUM;
    criteriasLinguisticImportance[1, 1] = LinguisticTerms.HIGH;
    criteriasLinguisticImportance[1, 2] = LinguisticTerms.HIGH;
    criteriasLinguisticImportance[1, 3] = LinguisticTerms.HIGH;
    //
    criteriasLinguisticImportance[2, 0] = LinguisticTerms.VERY_HIGH;
    criteriasLinguisticImportance[2, 1] = LinguisticTerms.HIGH;
    criteriasLinguisticImportance[2, 2] = LinguisticTerms.VERY_HIGH;
    criteriasLinguisticImportance[2, 3] = LinguisticTerms.MEDIUM;
}
else
{
    for (int expert = 0; expert < experts; expert++)
        for (int criteria = 0; criteria < criterias; criteria++)
        {
            Console.WriteLine($"Expert {expert + 1}, criteria {criteria + 1}:");
            criteriasLinguisticImportance[expert, criteria] = ConsoleInput.ChooseFrom(LinguisticTerms.GetAll);
        }
}

Console.WriteLine("\nImportance of criterias:");
for (int i = 0; i <= experts; i++)
{
    for (int j = 0; j <= criterias; j++)
        if (i == 0 && j == 0)
            Console.Write(String.Format("{0,16}|", ""));
        else if (i == 0 && j > 0)
            Console.Write(String.Format("{0,16}|", $"Criterion {j}"));
        else if (i > 0 && j == 0)
            Console.Write(String.Format("{0,16}|", $"Expert {i}"));
        else
            Console.Write(String.Format("{0,16}|", $"{criteriasLinguisticImportance[i - 1, j - 1]}"));
    Console.WriteLine();
}

Console.WriteLine("\nEnter estimates of alternatives.");
string[,,] alternativesEstimates = new string[experts, alternatives, criterias];
if (testData)
{
    // expert 1
    // alternative 1
    alternativesEstimates[0, 0, 0] = LinguisticTerms.HIGH; // criterion 1
    alternativesEstimates[0, 0, 1] = LinguisticTerms.VERY_HIGH; // criterion 2
    alternativesEstimates[0, 0, 2] = LinguisticTerms.HIGH; // criterion 3
    alternativesEstimates[0, 0, 3] = LinguisticTerms.VERY_HIGH; // criterion 4
    // alternative 2
    alternativesEstimates[0, 1, 0] = LinguisticTerms.VERY_HIGH; // criterion 1
    alternativesEstimates[0, 1, 1] = LinguisticTerms.MEDIUM_HIGH; // criterion 2
    alternativesEstimates[0, 1, 2] = LinguisticTerms.MEDIUM_HIGH; // criterion 3
    alternativesEstimates[0, 1, 3] = LinguisticTerms.HIGH;
    // alternative 3
    alternativesEstimates[0, 2, 0] = LinguisticTerms.MEDIUM_HIGH; // criterion 1
    alternativesEstimates[0, 2, 1] = LinguisticTerms.HIGH; // criterion 2
    alternativesEstimates[0, 2, 2] = LinguisticTerms.MEDIUM; // criterion 3
    alternativesEstimates[0, 2, 3] = LinguisticTerms.VERY_HIGH; // criterion 4

    // expert 2
    // alternative 1
    alternativesEstimates[1, 0, 0] = LinguisticTerms.VERY_HIGH; // criterion 1
    alternativesEstimates[1, 0, 1] = LinguisticTerms.VERY_HIGH; // criterion 2
    alternativesEstimates[1, 0, 2] = LinguisticTerms.MEDIUM_HIGH; // criterion 3
    alternativesEstimates[1, 0, 3] = LinguisticTerms.MEDIUM_HIGH; // criterion 4
    // alternative 2
    alternativesEstimates[1, 1, 0] = LinguisticTerms.VERY_HIGH; // criterion 1
    alternativesEstimates[1, 1, 1] = LinguisticTerms.HIGH; // criterion 2
    alternativesEstimates[1, 1, 2] = LinguisticTerms.MEDIUM_HIGH; // criterion 3
    alternativesEstimates[1, 1, 3] = LinguisticTerms.HIGH;
    // alternative 3
    alternativesEstimates[1, 2, 0] = LinguisticTerms.HIGH; // criterion 1
    alternativesEstimates[1, 2, 1] = LinguisticTerms.VERY_HIGH; // criterion 2
    alternativesEstimates[1, 2, 2] = LinguisticTerms.HIGH; // criterion 3
    alternativesEstimates[1, 2, 3] = LinguisticTerms.HIGH; // criterion 4

    // expert 3
    // alternative 1
    alternativesEstimates[2, 0, 0] = LinguisticTerms.MEDIUM_HIGH; // criterion 1
    alternativesEstimates[2, 0, 1] = LinguisticTerms.MEDIUM_HIGH; // criterion 2
    alternativesEstimates[2, 0, 2] = LinguisticTerms.HIGH; // criterion 3
    alternativesEstimates[2, 0, 3] = LinguisticTerms.VERY_HIGH; // criterion 4
    // alternative 2
    alternativesEstimates[2, 1, 0] = LinguisticTerms.VERY_HIGH; // criterion 1
    alternativesEstimates[2, 1, 1] = LinguisticTerms.MEDIUM_HIGH; // criterion 2
    alternativesEstimates[2, 1, 2] = LinguisticTerms.VERY_HIGH; // criterion 3
    alternativesEstimates[2, 1, 3] = LinguisticTerms.MEDIUM_HIGH;
    // alternative 3
    alternativesEstimates[2, 2, 0] = LinguisticTerms.VERY_HIGH; // criterion 1
    alternativesEstimates[2, 2, 1] = LinguisticTerms.HIGH; // criterion 2
    alternativesEstimates[2, 2, 2] = LinguisticTerms.MEDIUM_HIGH; // criterion 3
    alternativesEstimates[2, 2, 3] = LinguisticTerms.HIGH; // criterion 4
}
else
{
    for (int expert = 0; expert < experts; expert++)
        for (int alternative = 0; alternative < alternatives; alternative++)
            for (int criteria = 0; criteria < criterias; criteria++)
            {
                Console.WriteLine($"Expert {expert + 1}, alternative {alternative + 1}, criteria {criteria + 1}:");
                alternativesEstimates[expert, alternative, criteria] = ConsoleInput.ChooseFrom(LinguisticTerms.GetAll);
            }
}
Console.WriteLine("\nEstimates of alternatives:");
for (int i = 0; i < experts; i++)
{
    Console.WriteLine($"Expert #{i + 1}");
    for (int j = 0; j <= alternatives; j++)
    {
        for (int k = 0; k <= criterias; k++)
            if (j == 0 && k == 0)
                Console.Write(String.Format("{0,16}|", ""));
            else if (j == 0 && k > 0)
                Console.Write(String.Format("{0,16}|", $"Criterion {k}"));
            else if (j > 0 && k == 0)
                Console.Write(String.Format("{0,16}|", $"Alternative {j}"));
            else
                Console.Write(String.Format("{0,16}|", $"{alternativesEstimates[i, j - 1, k - 1]}"));
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

Console.WriteLine("\nLinguistic terms(grouped experts):");
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
            Console.Write(String.Format("{0,16}|", $"{LinguisticTerms.GroupedLingusticTermsToString(alternativesEstimatesGrouped[j - 1, k - 1])}"));
        }
    }
    Console.WriteLine();
}

TriangularNumber[,] criteriasTriangularImportance = new TriangularNumber[experts, criterias];
for (int expert = 0; expert < experts; expert++)
    for (int criteria = 0; criteria < criterias; criteria++)
        criteriasTriangularImportance[expert, criteria] = LinguisticTerms.ConvertToTriangularFromLinguistic(criteriasLinguisticImportance[expert, criteria]);

Console.WriteLine("\nTriangular fuzzy numbers(criteria):");
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

TriangularNumber[,][] triangularAlternativesEstimatesGrouped = new TriangularNumber[alternatives, criterias][];
for (int alternative = 0; alternative < alternatives; alternative++)
{
    for (int criteria = 0; criteria < criterias; criteria++)
    {
        triangularAlternativesEstimatesGrouped[alternative, criteria] = new TriangularNumber[experts];
        for (int expert = 0; expert < experts; expert++)
        {
            triangularAlternativesEstimatesGrouped[alternative, criteria][expert] = LinguisticTerms.ConvertToTriangularFromLinguistic(alternativesEstimatesGrouped[alternative, criteria][expert]);
        }
    }
}

Console.WriteLine("\nTriangular fuzzy terms(grouped experts):");
for (int j = 0; j <= alternatives; j++)
{
    for (int k = 0; k <= criterias; k++)
    {
        if (j == 0 && k == 0)
        {
            Console.Write(String.Format("{0,32}|", ""));
        }
        else if (j == 0 && k > 0)
        {
            Console.Write(String.Format("{0,32}|", $"Criterion {k}"));
        }
        else if (j > 0 && k == 0)
        {
            Console.Write(String.Format("{0,32}|", $"Alternative {j}"));
        }
        else
        {
            Console.Write(String.Format("{0,32}|", $"{LinguisticTerms.GroupedTriangularTermsToString(triangularAlternativesEstimatesGrouped[j - 1, k - 1])}"));
        }
    }
    Console.WriteLine();
}

float[,] matrixCriteria = new float[criterias, 5];
for (int criteria = 0; criteria < criterias; criteria++)
{
    //l
    float l = float.MaxValue;
    for (int expert = 0; expert < experts; expert++)
        if (criteriasTriangularImportance[expert, criteria].Left <= l)
            l = criteriasTriangularImportance[expert, criteria].Left;
    //lh
    float lh = 1;
    for (int expert = 0; expert < experts; expert++)
            lh *= criteriasTriangularImportance[expert, criteria].Left;
    lh = (float)Math.Pow(lh, 1f / (float)experts);
    //m
    float m = 1;
    for (int expert = 0; expert < experts; expert++)
        m *= criteriasTriangularImportance[expert, criteria].Middle;
    m = (float)Math.Pow(m, 1f / (float)experts);
    //uh
    float uh = 1;
    for (int expert = 0; expert < experts; expert++)
        uh *= criteriasTriangularImportance[expert, criteria].Right;
    uh = (float)Math.Pow(uh, 1f / (float)experts);
    //u
    float u = float.MinValue;
    for (int expert = 0; expert < experts; expert++)
        if (criteriasTriangularImportance[expert, criteria].Right >= u)
            u = criteriasTriangularImportance[expert, criteria].Right;
    //
    matrixCriteria[criteria, 0] = l;
    matrixCriteria[criteria, 1] = lh;
    matrixCriteria[criteria, 2] = m;
    matrixCriteria[criteria, 3] = uh;
    matrixCriteria[criteria, 4] = u;
}


Console.WriteLine("\nMatrix criteria:");
for (int j = 0; j <= criterias; j++)
{
    for (int k = 0; k <= 5; k++)
    {
        if (j == 0 && k == 0)
        {
            Console.Write(String.Format("{0,16}|", ""));
        }
        else if (j > 0 && k == 0)
        {
            Console.Write(String.Format("{0,16}|", $"Criterion {j}"));
        }
        else if (j == 0 && k == 1)
        {
            Console.Write(String.Format("{0,16}|", "l"));
        }
        else if (j == 0 && k == 2)
        {
            Console.Write(String.Format("{0,16}|", "lh"));
        }
        else if (j == 0 && k == 3)
        {
            Console.Write(String.Format("{0,16}|", "m"));
        }
        else if (j == 0 && k == 4)
        {
            Console.Write(String.Format("{0,16}|", "uh"));
        }
        else if (j == 0 && k == 5)
        {
            Console.Write(String.Format("{0,16}|", "u"));
        }
        else
        {
            Console.Write(String.Format("{0,16}|", $"{matrixCriteria[j - 1, k - 1]}"));
        }
    }
    Console.WriteLine();
}

float[][,] matrixAlternatives = new float[alternatives][,];
for (int alternative = 0; alternative < alternatives; alternative++) {
    matrixAlternatives[alternative] = new float[criterias, 5];
    for (int criteria = 0; criteria < criterias; criteria++)
    {
        //l
        float l = float.MaxValue;
        for (int expert = 0; expert < experts; expert++)
            if (triangularAlternativesEstimatesGrouped[alternative, criteria][expert].Left <= l)
                l = triangularAlternativesEstimatesGrouped[alternative, criteria][expert].Left;
        //lh
        float lh = 1;
        for (int expert = 0; expert < experts; expert++)
            lh *= triangularAlternativesEstimatesGrouped[alternative, criteria][expert].Left;
        lh = (float)Math.Pow(lh, 1f / (float)experts);
        //m
        float m = 1;
        for (int expert = 0; expert < experts; expert++)
            m *= triangularAlternativesEstimatesGrouped[alternative, criteria][expert].Middle;
        m = (float)Math.Pow(m, 1f / (float)experts);
        //uh
        float uh = 1;
        for (int expert = 0; expert < experts; expert++)
            uh *= triangularAlternativesEstimatesGrouped[alternative, criteria][expert].Right;
        uh = (float)Math.Pow(uh, 1f / (float)experts);
        //u
        float u = float.MinValue;
        for (int expert = 0; expert < experts; expert++)
            if (triangularAlternativesEstimatesGrouped[alternative, criteria][expert].Right >= u)
                u = triangularAlternativesEstimatesGrouped[alternative, criteria][expert].Right;
        //
        matrixAlternatives[alternative][criteria, 0] = l;
        matrixAlternatives[alternative][criteria, 1] = lh;
        matrixAlternatives[alternative][criteria, 2] = m;
        matrixAlternatives[alternative][criteria, 3] = uh;
        matrixAlternatives[alternative][criteria, 4] = u;
    }
}

Console.WriteLine("\nMatrix alternatives:");
for (int alternative = 0; alternative < alternatives; alternative++)
{
    Console.WriteLine($"Alternative #{alternative + 1}");
    for (int j = 0; j <= criterias; j++)
    {
        for (int k = 0; k <= 5; k++)
        {
            if (j == 0 && k == 0)
            {
                Console.Write(String.Format("{0,16}|", ""));
            }
            else if (j > 0 && k == 0)
            {
                Console.Write(String.Format("{0,16}|", $"Criterion {j}"));
            }
            else if (j == 0 && k == 1)
            {
                Console.Write(String.Format("{0,16}|", "l"));
            }
            else if (j == 0 && k == 2)
            {
                Console.Write(String.Format("{0,16}|", "lh"));
            }
            else if (j == 0 && k == 3)
            {
                Console.Write(String.Format("{0,16}|", "m"));
            }
            else if (j == 0 && k == 4)
            {
                Console.Write(String.Format("{0,16}|", "uh"));
            }
            else if (j == 0 && k == 5)
            {
                Console.Write(String.Format("{0,16}|", "u"));
            }
            else
            {
                Console.Write(String.Format("{0,16}|", $"{matrixAlternatives[alternative][j - 1, k - 1]}"));
            }
        }
        Console.WriteLine();
    }
}

float[,] matrixOptimal = new float[criterias, 5];

for (int criteria = 0; criteria < criterias; criteria++)
    for (int i = 0; i < 5; i++)
    {
        matrixOptimal[criteria, i] = float.MinValue;
        for (int alternative = 0; alternative < alternatives; alternative++)
            if (matrixOptimal[criteria, i] <= matrixAlternatives[alternative][criteria, i])
                matrixOptimal[criteria, i] = matrixAlternatives[alternative][criteria, i] ;
    }

Console.WriteLine("\nMatrix optimal value:");
for (int j = 0; j <= criterias; j++)
{
    for (int k = 0; k <= 5; k++)
    {
        if (j == 0 && k == 0)
        {
            Console.Write(String.Format("{0,16}|", ""));
        }
        else if (j > 0 && k == 0)
        {
            Console.Write(String.Format("{0,16}|", $"Criterion {j}"));
        }
        else if (j == 0 && k == 1)
        {
            Console.Write(String.Format("{0,16}|", "l"));
        }
        else if (j == 0 && k == 2)
        {
            Console.Write(String.Format("{0,16}|", "lh"));
        }
        else if (j == 0 && k == 3)
        {
            Console.Write(String.Format("{0,16}|", "m"));
        }
        else if (j == 0 && k == 4)
        {
            Console.Write(String.Format("{0,16}|", "uh"));
        }
        else if (j == 0 && k == 5)
        {
            Console.Write(String.Format("{0,16}|", "u"));
        }
        else
        {
            Console.Write(String.Format("{0,16}|", $"{matrixOptimal[j - 1, k - 1]}"));
        }
    }
    Console.WriteLine();
}

float[,] r = new float[criterias, 5];
for (int criteria = 0; criteria < criterias; criteria++)
{
    float c = 0;
    for (int i = 0; i < criterias; i++)
    {
        float max = float.MinValue;
        for (int j = 0; j < 5; j++) 
            if (matrixOptimal[i, j] >= max)
                max = matrixOptimal[i, j];
        c += max;
    }

    r[criteria, 0] = matrixOptimal[criteria, 0] / c;
    r[criteria, 1] = matrixOptimal[criteria, 1] / c;
    r[criteria, 2] = matrixOptimal[criteria, 2] / c;
    r[criteria, 3] = matrixOptimal[criteria, 3] / c;
    r[criteria, 4] = matrixOptimal[criteria, 4] / c;
}

float[][,] matrixNormalised = new float[criterias][,];
for (int criteria = 0; criteria < criterias; criteria++)
    matrixNormalised[criteria] = new float[alternatives, 5];
for (int alternative = 0; alternative < alternatives; alternative++)
{
    for (int criteria = 0; criteria < criterias; criteria++)
    {
        float c = 0;
        for (int i = 0; i < criterias; i++)
        {
            float max = float.MinValue;
            for (int j = 0; j < 5; j++)
                if (matrixAlternatives[alternative][i, j] >= max)
                    max = matrixOptimal[i, j];
            c += max;
        }

        for (int i = 0; i < 5; i++)
            matrixNormalised[criteria][alternative, i] = matrixAlternatives[alternative][criteria, i] / c;
        //matrixNormalised[criteria][alternative, 0] = matrixAlternatives[alternative][criteria, 0] / c;
        //matrixNormalised[criteria][alternative, 1] = matrixAlternatives[alternative][criteria, 1] / c;
        //matrixNormalised[criteria][alternative, 2] = matrixAlternatives[alternative][criteria, 2] / c;
        //matrixNormalised[criteria][alternative, 3] = matrixAlternatives[alternative][criteria, 3] / c;
        //matrixNormalised[criteria][alternative, 4] = matrixAlternatives[alternative][criteria, 4] / c;
    }
}

Console.WriteLine("\nNormalised fuzzy matrix:");
for (int criteria = 0; criteria < criterias; criteria++)
{
    Console.WriteLine($"Criterion #{criteria + 1}");

    for (int i = 0; i <= 5; i++)
        if (i == 0)
            Console.Write(String.Format("{0,16}|", "Optimal alter"));
        else
            Console.Write(String.Format("{0,16}|", $"{r[criteria, i - 1]}"));
    Console.WriteLine();

    for (int j = 0; j <= alternatives; j++)
    {
        for (int k = 0; k <= 5; k++)
            if (j == 0 && k == 0)
                Console.Write(String.Format("{0,16}|", ""));
            else if (j > 0 && k == 0)
                Console.Write(String.Format("{0,16}|", $"Alternative {j}"));
            else if (j > 0 && k >0)
                Console.Write(String.Format("{0,16}|", $"{matrixNormalised[criteria][j - 1, k - 1]}"));
        Console.WriteLine();
    }
}

float[,] rNormilesedWeighted = new float[criterias, 5];
for (int criteria = 0; criteria < criterias; criteria++)
    for (int i = 0; i < 5; i++)
        rNormilesedWeighted[criteria, i] = r[criteria, i] * matrixCriteria[criteria, i];

float[][,] matrixNormalisedWeighted = new float[criterias][,];
for (int criteria = 0; criteria < criterias; criteria++)
    matrixNormalisedWeighted[criteria] = new float[alternatives, 5];
for (int alternative = 0; alternative < alternatives; alternative++)
    for (int criteria = 0; criteria < criterias; criteria++)
        for (int i = 0; i < 5; i++)
            matrixNormalisedWeighted[criteria][alternative, i] = matrixNormalised[criteria][alternative, i] * matrixCriteria[criteria, i];

Console.WriteLine("\nNormalised-weighted fuzzy matrix:");
for (int criteria = 0; criteria < criterias; criteria++)
{
    Console.WriteLine($"Criterion #{criteria + 1}");

    for (int i = 0; i <= 5; i++)
        if (i == 0)
            Console.Write(String.Format("{0,16}|", "Optimal alter"));
        else
            Console.Write(String.Format("{0,16}|", $"{rNormilesedWeighted[criteria, i - 1]}"));
    Console.WriteLine();

    for (int j = 0; j <= alternatives; j++)
    {
        for (int k = 0; k <= 5; k++)
            if (j == 0 && k == 0)
                Console.Write(String.Format("{0,16}|", ""));
            else if (j > 0 && k == 0)
                Console.Write(String.Format("{0,16}|", $"Alternative {j}"));
            else if (j > 0 && k > 0)
                Console.Write(String.Format("{0,16}|", $"{matrixNormalisedWeighted[criteria][j - 1, k - 1]}"));
        Console.WriteLine();
    }
}

float[] rOverall = new float[5];
for (int i = 0; i < 5; i++)
{
    float sum = 0;
    for (int criteria = 0; criteria < criterias; criteria++)
        sum += rNormilesedWeighted[criteria, i];
    rOverall[i] = sum;
}

float[,] matrixOveral = new float[alternatives, 5];
for (int alternative = 0; alternative < alternatives; alternative++)
{
    for (int i = 0; i < 5; i++)
    {
        float sum = 0;
        for (int criteria = 0; criteria < criterias; criteria++)
            sum += matrixNormalisedWeighted[criteria][alternative, i];
        matrixOveral[alternative, i] = sum;
    }
}

Console.WriteLine("\nThe overall interval-valued fuzzy performance rating:");
for (int i = 0; i <= 5; i++)
    if (i == 0)
        Console.Write(String.Format("{0,16}|", "Optimal alter"));
    else
        Console.Write(String.Format("{0,16}|", $"{rOverall[i - 1]}"));

for (int alternative = 0; alternative <= alternatives; alternative++)
{
    for (int i = 0; i <= 5; i++)
        if (alternative > 0 && i == 0)
            Console.Write(String.Format("{0,16}|", $"Criterion {alternative}"));
        else if (alternative > 0 && i > 0)
            Console.Write(String.Format("{0,16}|", $"{matrixOveral[alternative - 1, i - 1]}"));
    Console.WriteLine();
}

float rDefuzzificated = rOverall.Sum() / 5f;
float[] matrixDefuzzificated = new float[alternatives];
for (int alternative = 0; alternative < alternatives; alternative++)
{
    float sum = 0;
    for (int i = 0; i < 5; i++)
        sum += matrixOveral[alternative, i];
    matrixDefuzzificated[alternative] = sum / 5f;
}

Console.WriteLine("\nDefuzzification:");
Console.WriteLine(String.Format("{0,16}|{1,16}|", "Optimal alter", rDefuzzificated));


for (int i = 0; i < alternatives; i++)
    Console.WriteLine(String.Format("{0,16}|{1,16}|", $"Alternative {i + 1}", $"{matrixDefuzzificated[i]}"));

float rOptimal = 1f;
float[] q = new float[alternatives];
int solutionIndex = 0;
float solutionValue = float.MinValue;
for (int alternative = 0; alternative < alternatives; alternative++)
{
    q[alternative] = matrixDefuzzificated[alternative] / rDefuzzificated;
    if (q[alternative] >= solutionValue)
    {
        solutionValue = q[alternative];
        solutionIndex = alternative;
    }
}

Console.WriteLine("\nDegree of utility:");
Console.WriteLine(String.Format("{0,16}|{1,16}|", "Optimal alter", rOptimal));
for (int i = 0; i < alternatives; i++)
    Console.WriteLine(String.Format("{0,16}|{1,16}|", $"Alternative {i + 1}", $"{q[i]}"));
Console.WriteLine(String.Format("{0,16}|{1,16}|{2,16}|", $"Solution #{solutionIndex + 1}", solutionValue, "has a rank of 1, as it is the closest to the optimal solution"));


Console.ReadKey();









