using System.Text;

namespace FuzzyAdditiveRatioAssessment
{
    public static class LinguisticTerms
    {
        public const string VERY_LOW = "VL"; // very low 
        public const string LOW = "L"; // low 
        public const string MEDIUM_LOW = "ML"; // medium low
        public const string MEDIUM = "M"; // medium
        public const string MEDIUM_HIGH = "MH"; // medium high
        public const string HIGH = "H"; // high
        public const string VERY_HIGH = "VH"; // very high

        public static string[] GetAll => new string[7] {
            VERY_LOW,
            LOW,
            MEDIUM_LOW,
            MEDIUM,
            MEDIUM_HIGH,
            HIGH,
            VERY_HIGH
        };

        public static TriangularNumber ConvertToTriangularFromLinguistic(string linguisticTerm) =>
            linguisticTerm switch
            {
                VERY_LOW => new TriangularNumber(0, 0, 0.1f),
                LOW => new TriangularNumber(0, 0.1f, 0.3f),
                MEDIUM_LOW => new TriangularNumber(0.1f, 0.3f, 0.5f),
                MEDIUM => new TriangularNumber(0.3f, 0.5f, 0.7f),
                MEDIUM_HIGH => new TriangularNumber(0.5f, 0.7f, 0.9f),
                HIGH => new TriangularNumber(0.7f, 0.7f, 1f),
                VERY_HIGH => new TriangularNumber(0.9f, 1f, 1f),
                _ => new TriangularNumber()
            };

        public static string GroupedLingusticTermsToString(string[] groupedLingusticTerms)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            foreach(string term in groupedLingusticTerms)
                stringBuilder.Append($" {term}");
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        public static string GroupedTriangularTermsToString(TriangularNumber[] groupedLingusticTerms)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            foreach (TriangularNumber term in groupedLingusticTerms)
                stringBuilder.Append($" {term}");
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
    }
}
