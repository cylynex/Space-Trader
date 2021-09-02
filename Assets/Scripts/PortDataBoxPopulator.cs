using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortDataBoxPopulator : MonoBehaviour {

    [SerializeField] Text portName;
    [SerializeField] Text portDescription;

    public void PopulateData(Port port) {
        print("portdatago");
        portName.text = port.portName;
        portDescription.text = port.portDescription;
    }

}