using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//household list
[CreateAssetMenu(fileName = "SpellHouseholdData", menuName = "SpellHouseholdData")]
public class SpellHouseholdDataScriptable : ScriptableObject
{
    public List<Pronunciation> pronunciations;
}
