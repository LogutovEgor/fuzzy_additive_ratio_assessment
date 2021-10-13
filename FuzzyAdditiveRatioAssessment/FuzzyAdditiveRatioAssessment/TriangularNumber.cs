namespace FuzzyAdditiveRatioAssessment
{
    public class TriangularNumber
    {
        public float Left { get; private set; } = default;
        public float Middle { get; private set; } = default;
        public float Right { get; private set; } = default;

        public TriangularNumber()
        {
            
        }
        public TriangularNumber(float left, float middle, float right)
        {
            Left = left;
            Middle = middle;
            Right = right;
        }

        public override string ToString() => $"<{Left} {Middle} {Right}>";
    }
}
