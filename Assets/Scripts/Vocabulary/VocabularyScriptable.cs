using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="VocabulariesData", menuName ="VocabulariesData")]
public class VocabularyScriptable : ScriptableObject
{
    public List<Vocabulary> vocabularies;
}
