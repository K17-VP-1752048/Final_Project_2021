using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//food list
[CreateAssetMenu(fileName = "SpellFoodData", menuName = "SpellFoodData")]
public class SpellFoodDataScriptable : ScriptableObject
{
    public List<Pronunciation> pronunciations;
}
