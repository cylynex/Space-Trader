using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Planet")]
public class Planet : ScriptableObject {

    public string planetName;
    [TextArea(25, 50)] public string planetDescription;

}