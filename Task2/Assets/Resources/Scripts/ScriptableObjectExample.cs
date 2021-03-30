using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "ScriptableObject")]
public class ScriptableObjectExample : ScriptableObject
{
    public List<string> objectNames = new List<string>();
}
