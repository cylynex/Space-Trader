using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Port")]
public class Port : ScriptableObject {

    public string portName;
    [TextArea(25, 50)] public string portDescription;

}