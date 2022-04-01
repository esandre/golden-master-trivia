namespace Trivia.Ports
{
    internal interface IRandomNumberGenerator
    {
        int Next(int maxValue);
    }
}
