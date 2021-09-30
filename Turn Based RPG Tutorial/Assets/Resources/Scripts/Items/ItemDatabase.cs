using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

/// <summary>
/// Static class that knows what ItemTypes are
/// associated with what Items.
/// </summary>
public static class ItemDatabase
{
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
        switch (type)
        {
            case ItemType.HealthPotion:
            {
                return new HealthPotion();
            }

            default:
            {
                return null;
            }
        }
    }
}
