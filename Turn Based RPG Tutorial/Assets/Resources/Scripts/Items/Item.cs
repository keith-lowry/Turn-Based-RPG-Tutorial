using System;
using UnityEngine;
using Object = UnityEngine.Object;


/// <summary>
/// Abstract class representing an Item
/// that can be used in battle.
/// </summary>
public abstract class Item : ITargetable
{
    /// <summary>
    /// The Type of Unit that can be targetted
    /// by this Item.
    /// </summary>
    public TargetType TargetType
    {
        get { return targetType; }
    }

    /// <summary>
    /// The Number of Targets for this Item.
    /// </summary>
    public TargetCount TargetCount
    {
        get { return targetCount; }
    }

    /// <summary>
    /// The name of this Item.
    /// </summary>
    public string ItemName
    {
        get { return itemName; }
    }

    /// <summary>
    /// The quantity of this Item.
    /// </summary>
    protected int quantity;

    private readonly TargetType targetType;
    private readonly TargetCount targetCount;
    private readonly string itemName;

    /// <summary>
    /// Creates a new Item with a default Quantity
    /// of 1 and the given Target Type and
    /// Number of Targets.
    /// </summary>
    /// <param name="target">The type of Unit to be targetted
    /// by this Item.</param>
    /// <param name="numTargets">The number of Targets this
    /// Item needs.</param>
    /// <param name="name">The name of this Item.</param>
    public Item(string name, TargetType target, TargetCount numTargets)
    {
        itemName = name;
        targetType = target;
        targetCount = numTargets;
        quantity = 1;
    }

    /// <summary>
    /// Gets the String dialogue to be displayed
    /// when the Item is not used.
    /// </summary>
    /// <returns>The Item's non-use dialogue.</returns>
    public virtual string GetFailedUseDialogue()
    {
        if (quantity <= 0)
        {
            return "You're out of that";
        }

        return "You can't do that right now";
    }

    /// <summary>
    /// Gets the Item's String dialogue to be
    /// displayed when it is used.
    /// </summary>
    public abstract string GetUseDialogue();

    /// <summary>
    /// Increases the Item's quantity
    /// by a certain amount.
    /// </summary>
    /// <param name="q">The amount to add
    /// to the Item's quantity.</param>
    public void AddQuantity(int q)
    {
        quantity += q;
    }
}
