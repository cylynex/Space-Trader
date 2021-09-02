using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetController : MonoBehaviour {

    [SerializeField] Planet planet;

    [Header("UI")]
    [SerializeField] Text planetName;


    GameController gc;

    private void Start() {
        gc = FindObjectOfType<GameController>();
        planet = gc.currentPlanet;
        planetName.text = planet.planetName;
    }

}