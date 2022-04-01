namespace Trivia.Ports
{
    public interface IRandomNumberGenerator
    {
        int Next(int maxValue);
    }
}
