using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Menso.Tools.Scrambler;

public static class ListExtensions
{
    /// <summary>
    /// Shuffle of all items in the list.
    /// </summary>
    /// <typeparam name="T">The generic type of the list to extend.</typeparam>
    /// <param name="list">The list to extend.</param>
    /// <param name="seed">Shuffle list by seed</param>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Shuffle<T>(this IList<T> list, int seed)
    {
        ArgumentNullException.ThrowIfNull(list);
        var random = new Random(seed);
        var count = list.Count;
        while (count > 1)
        {
            var shortedIndex = random.Next(count--);
            (list[count], list[shortedIndex]) = (list[shortedIndex], list[count]);
        }
    }
    
    /// <summary>
    /// Shuffle of all items in the list.
    /// </summary>
    /// <typeparam name="T">The generic type of the list to extend.</typeparam>
    /// <param name="list">The list to extend.</param>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Shuffle<T>(this IList<T> list)
    {
        ArgumentNullException.ThrowIfNull(list);

        var count = list.Count;
        while (count > 1)
        {
            var shortedIndex = Random.Shared.Next(count--);
            (list[count], list[shortedIndex]) = (list[shortedIndex], list[count]);
        }
    }
    
    /// <summary>
    /// Cryptographically-strong thread-safe shuffle of all items in the list. Less performant than.
    /// </summary>
    /// <typeparam name="T">The generic type of the list to extend.</typeparam>
    /// <param name="list">The list to extend.</param>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CryptoStrongShuffle<T>(this IList<T> list)
    {
        ArgumentNullException.ThrowIfNull(list);
        
        var count = list.Count;
        using var generator = RandomNumberGenerator.Create();
        while (count > 1)
        {
            var data = new byte[sizeof(uint)];
            generator.GetBytes(data);
            var randomUint = BitConverter.ToUInt32(data, 0);
            var shortedIndex = (int)Math.Floor(count-- * (randomUint / (uint.MaxValue + 1.0)));
            (list[count], list[shortedIndex]) = (list[shortedIndex], list[count]);
        }
    }
}
