using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanetDataBoxPopulator : MonoBehaviour {

    [SerializeField] Text planetName;
    [SerializeField] Text planetDescription;
    [SerializeField] Button landButton;
    GameController gc;

    private void Start() {
        gc = FindObjectOfType<GameController>();
    }

    public void PopulateData(Planet planet) {
        planetName.text = planet.planetName;
        planetDescription.text = planet.planetDescription;
        landButton.onClick.AddListener(() => LandOnPlanet(planet)); // WILL NEED SECTOR DATA AS WELL, EVENTUALLY.  Probably in GC
    }

    void LandOnPlanet(Planet planet) {
        print("clear to land");
        gc.currentPlanet = planet;
        SceneManager.LoadScene("Planet");
    }


}