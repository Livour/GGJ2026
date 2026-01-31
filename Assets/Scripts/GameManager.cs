using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager
{
    public static GameManager I { get; } = new GameManager();

    private readonly List<Mask> _masks = new List<Mask>();
    private List<int> _availableMaskIds = new List<int>();
    private int[] _maskUseCount = Array.Empty<int>();
    private House[] _houses = Array.Empty<House>();

    public int HouseCount { get; private set; }
    public IReadOnlyList<Mask> Masks => _masks;

    public int Candies { get; private set; }
    public float TimeLeft { get; private set; }
    public bool IsRunning { get; private set; }
    public bool IsOver { get; private set; }

    public int LastHouseIndex { get; private set; } = -1;

    public int CurrentMaskId { get; private set; } = -1;
    public Mask CurrentMask => (CurrentMaskId >= 0 && CurrentMaskId < _masks.Count) ? _masks[CurrentMaskId] : null;

    private GameManager() { }

    // Call once on boot
    public void ConfigureMasks(IEnumerable<string> maskNames)
    {
        _masks.Clear();

        int id = 0;
        foreach (var name in maskNames)
        {
            _masks.Add(new Mask(id, name));
            id++;
        }
    }

    // Call when starting a new run
    public void StartRun(int houseCount,int maskCount, float durationSeconds)
    {
        if (_masks.Count == 0)
            throw new InvalidOperationException("No masks configured. Call ConfigureMasks() first.");

        if (houseCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(houseCount));

        HouseCount = houseCount;
        TimeLeft = durationSeconds;

        _houses = new House[houseCount];
        for (int h = 0; h < houseCount; h++)
            _houses[h] = new House(h);

        _maskUseCount = new int[maskCount];

        _availableMaskIds = new List<int>();

        for (int i = 0; i < maskCount && i < _masks.Count; i++)
        {
            _availableMaskIds.Add(_masks[i].Id);
        }

        Candies = 0;
        LastHouseIndex = -1;

        IsRunning = true;
        IsOver = false;

        PickNextMask();
    }

    public void Tick(float deltaTime)
    {
        if (!IsRunning || IsOver) return;

        TimeLeft -= deltaTime;
        if (TimeLeft <= 0f)
        {
            TimeLeft = 0f;
            EndRunInternal();
        }
    }

    // UI helper, use this to disable last house click
    public bool IsHouseSelectable(int houseIndex)
    {
        if (!IsRunning || IsOver) return false;
        if (houseIndex < 0 || houseIndex >= HouseCount) return false;
        return houseIndex != LastHouseIndex;
    }

    // Core interaction
    public ActionResult TryVisitHouse(int houseIndex)
    {
        if (!IsRunning || IsOver)
            return ActionResult.RunEnded;

        if (houseIndex < 0 || houseIndex >= HouseCount)
            return ActionResult.IllegalMove;

        if (houseIndex == LastHouseIndex)
            return ActionResult.IllegalMove;

        var house = _houses[houseIndex];

        if (house.HasSeenMask(CurrentMaskId))
            return GameOverInternal();

        // Success Section
        house.RegisterMask(CurrentMaskId);
        Candies++;
        LastHouseIndex = houseIndex;

        _maskUseCount[CurrentMaskId]++;

        // Remove mask when it has visited all houses
        if (_maskUseCount[CurrentMaskId] >= HouseCount)
        {
            _availableMaskIds.Remove(CurrentMaskId);

            // No masks left means the run ends (perfect clear)
            if (_availableMaskIds.Count == 0)
            {
                EndRunInternal();
                return ActionResult.RunEnded;
            }
        }

        PickNextMask();
        return ActionResult.Success;
    }

    private void PickNextMask()
    {
        int pick = UnityEngine.Random.Range(0, _availableMaskIds.Count);
        CurrentMaskId = _availableMaskIds[pick];
    }

    private ActionResult GameOverInternal()
    {
        IsOver = true;
        IsRunning = false;
        return ActionResult.AlreadyVisited;
    }

    private void EndRunInternal()
    {
        IsOver = true;
        IsRunning = false;
    }
}
