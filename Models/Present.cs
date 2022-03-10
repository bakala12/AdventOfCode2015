namespace AdventOfCode2015.Models
{
    public record struct Present(int A, int B, int C)
    {
        public int PaperNeeded => 2 * (A * B + B * C + C * A) + Math.Min(A * B, Math.Min(B * C, C * A));

        public int RibonNeeded => 2* Math.Min(A + B, Math.Min(B + C, C + A)) + A * B * C;
    }
}