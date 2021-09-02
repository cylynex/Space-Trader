using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetDataBoxPopulator : MonoBehaviour {

    [SerializeField] Text planetName;
    [SerializeField] Text planetDescription;
    [SerializeField] Button landButton;

    public void PopulateData(Planet planet) {
        planetName.text = planet.planetName;
        planetDescription.text = planet.planetDescription;
    }

}