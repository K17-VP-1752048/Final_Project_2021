using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellData", menuName = "SpellData")]
public class SpellDataScriptable : ScriptableObject
{
    public List<Pronunciation> pronunciations;
}
