public sealed class Mask
{
    public int Id { get; }
    public string Description { get; }

    public Mask(int id, string description)
    {
        Id = id;
        Description = description;
    }

    public override string ToString() => Description;
}