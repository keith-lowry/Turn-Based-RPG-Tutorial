using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTest
{
    private GameObject playerPrefab;
    private Unit unit;

    /**
     * Sets up the testing environment before
     * each test method is called.
     */
    [SetUp]
    public void SetUp()
    {
        playerPrefab = Object.Instantiate
            (Resources.Load<GameObject>("Prefabs/Player"));
        unit = playerPrefab.GetComponent<Unit>();
    }

    /**
     * Resets the testing environement after
     * each test method is called.
     */
    [TearDown]
    public void TearDown()
    {
        MonoBehaviour.Destroy(playerPrefab);
    }

    /**
     * Check that fields are initialized properly
     * within the prefab.
     */
    [Test]
    public void TestUnitFields()
    {
        Assert.AreEqual(unit.Stats.MaxHealth, 200);
        Assert.AreEqual(unit.CurrentHP, unit.Stats.MaxHealth);
        Assert.AreEqual(unit.Stats.Attack, 30);
    }

    /**
     * Test that Unit script's TakeDamage() method
     * properly updates currentHP.
     */
    [Test]
    public void TestUnitTakeDamage()
    { 
        Assert.AreEqual(unit.CurrentHP, 200);

        unit.TakeDamage(10); 
        Assert.AreEqual(unit.CurrentHP, 190); //unit took 10 damage
    }

    /**
     * Test that the Unit script's TakeDamage() method returns
     * false when unit does not die and true when
     * unit does die.
     */
    [Test]
    public void TestUnitDie()
    {
        Assert.AreEqual(unit.CurrentHP, 200);

        Assert.IsFalse(unit.TakeDamage(10)); //unit does not die
        Assert.IsTrue(unit.TakeDamage(200)); //unit dies
        Assert.IsTrue(unit.CurrentHP <= 0);
    }


}
