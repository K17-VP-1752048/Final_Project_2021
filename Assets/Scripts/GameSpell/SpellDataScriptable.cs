using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//animals list
[CreateAssetMenu(fileName = "SpellData", menuName = "SpellData")]
public class SpellDataScriptable : ScriptableObject
{
    public List<Pronunciation> pronunciations;
}