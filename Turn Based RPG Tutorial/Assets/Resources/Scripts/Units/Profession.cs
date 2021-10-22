using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Profession", menuName = "Profession")]
public class Profession : ScriptableObject
{
    public string title;

    public List<Skill> skills;
}
