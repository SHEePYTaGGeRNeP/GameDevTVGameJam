using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trait", menuName = "ScriptableObjects/GamePlay/Traits")]
public class Trait : ScriptableObject
{
    public string type;
    public Color color;
}
