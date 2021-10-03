/// <summary>
/// Static class that knows what ItemTypes are
/// associated with what Items.
/// </summary>
public static class ItemDatabase
{
    //TODO: be careful about this:
    //using one new object
    private static readonly Item[] items = new Item[] {HealthPotion.Instance};

    /// <summary>
    /// Get a new instance of the Item
    /// with the given type.
    /// </summary>
    /// <param name="type">The type of Item
    /// to get.</param>
    /// <returns>A new instance of the desired
    /// Item.</returns>
    public static Item GetItem(ItemType type)
    {
        int i = (int) type;
        return items[i];
    }
}
