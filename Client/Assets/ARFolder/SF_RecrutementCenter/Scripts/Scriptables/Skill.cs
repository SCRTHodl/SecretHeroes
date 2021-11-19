using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSkillUI", menuName = "Characters/SkillUI")]

public class SkillUI : ScriptableObject
{

    public Sprite skillIcon;
    public GameObject skill;

    public string description;

}
