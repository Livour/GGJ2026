using System.Collections.Generic;

public sealed class House
{
    public int Id { get; }

    private readonly HashSet<int> _seenMasks;

    public House(int id)
    {
        Id = id;
        _seenMasks = new HashSet<int>();
    }

    public bool HasSeenMask(int maskId) => _seenMasks.Contains(maskId);

    public void RegisterMask(int maskId) => _seenMasks.Add(maskId);

    public void Reset() => _seenMasks.Clear();

    public int SeenCount => _seenMasks.Count;
}
