namespace Menso.Tools.Scrambler;

public static class EnumerableExtensions
{
    public static void Shuffle<T>(this List<T> list, int seed)
    {
        var random = new Random(seed);
        var count = list.Count;
        while (count > 1)
        {
            var shortedIndex = random.Next(count--);
            (list[count], list[shortedIndex]) = (list[shortedIndex], list[count]);
        }
    }
}
