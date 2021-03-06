using System;

/// <summary>
/// Singleton Item representing a simple
/// health potion.
/// 
/// Not a MonoBehavior.
/// </summary>
public class HealthPotion : SingleTargetItem
{
    public static readonly int baseHeal = 30;

    /// <summary>
    /// Gets the instance of the
    /// HealthPotion.
    /// </summary>
    public static HealthPotion Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new HealthPotion();
            }

            return _instance;
        }
    }

    //Singleton Instance
    private static HealthPotion _instance;

    private string useDialogue;
    private string failedUseDialogue;

    /// <summary>
    /// Creates a new HealthPotion with
    /// a default quantity of 1.
    /// </summary>
    private HealthPotion() : base("Health Potion", TargetType.Friendly)
    {
        useDialogue = "";
        failedUseDialogue = "";
    }

    public override bool Use(Unit targetUnit)
    {
        if (quantity <= 0)
        {
            SetFailedUseDialogue(false);
            return false;
        }


        int hpBefore = targetUnit.CurrentHP;

        bool healBlocked = !targetUnit.Heal(baseHeal);

        int hpAfter = targetUnit.CurrentHP;


        if (healBlocked)
        { 
            SetFailedUseDialogue(true);
            return false;
        }

        int deltaHP = hpAfter - hpBefore;
        quantity--;
        SetUseDialogue(targetUnit.unitName, deltaHP);
        return true;
    }


    public override String GetFailedUseDialogue()
    {
        return failedUseDialogue;
    }

    public override string GetUseDialogue()
    {
        return useDialogue;
    }

    /// <summary>
    /// Sets the nonUse Dialogue.
    /// </summary>
    /// <param name="healBlocked">Was the heal blocked because
    /// the target Unit was at full HP?</param>
    private void SetFailedUseDialogue(bool healBlocked)
    {
        if (healBlocked)
        {
            failedUseDialogue = "This Unit is already at full HP";
        }
        else if (quantity <= 0)
        {
            failedUseDialogue = "You're out of that";
        }
        else
        {
            failedUseDialogue = "You can't do that right now";
        }
    }

    /// <summary>
    /// Sets the Use Dialogue.
    /// </summary>
    /// <param name="targetName">The name of the target Unit.</param>
    /// <param name="deltaHP">The change in HP of the target Unit.</param>
    private void SetUseDialogue(String targetName, int deltaHP)
    {
        useDialogue = targetName + " healed " + deltaHP + " HP ";
    }
}
