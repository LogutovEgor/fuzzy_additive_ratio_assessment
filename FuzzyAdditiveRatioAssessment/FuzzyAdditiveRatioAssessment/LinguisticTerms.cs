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
    }
}
