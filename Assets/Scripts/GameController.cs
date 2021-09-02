using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [Header("Data")]
    SectorData sectorData;
    [SerializeField] Sector currentSector;

    [Header("UI")]
    
    [SerializeField] Text sectorFlavorText;
    [SerializeField] Text sectorConnections;
    [SerializeField] Text sectorName;

    [SerializeField] Transform sectorConnectionsBox;
    [SerializeField] GameObject changeSectorButton;

    [SerializeField] Transform planetConnectionsBox;
    [SerializeField] GameObject planetDataBox;
    [SerializeField] GameObject landOnPlanetButton;

    private void Start() {
        print("Game Initialized");
        InitializeSector();
    }

    void InitializeSector() {

        // Clear anything in the action box (currently just using sector connection box)
        foreach (Transform child in sectorConnectionsBox) {
            Destroy(child.gameObject);
        }

        sectorData = currentSector.GetSectorData();
        ShowConnections();
        ShowPlanets();
    }

    void ShowConnections() {
        for (int i = 0;i < sectorData.connectedSectors.Length;i++) {
            GameObject thisButton = Instantiate(changeSectorButton, transform.position, transform.rotation);
            thisButton.transform.parent = sectorConnectionsBox;
            thisButton.GetComponentInChildren<Text>().text = "M: "+sectorData.connectedSectors[i].sectorName;
            Sector buttonSector = sectorData.connectedSectors[i];
            Button button = thisButton.GetComponent<Button>();
            button.onClick.AddListener(() => ChangeSector(buttonSector));
        }
    }

    void ShowPlanets() {
        if (sectorData.planets != null) {
            for (int p = 0; p < sectorData.planets.Length; p++) {
                print("planet found: " + sectorData.planets[p].planetName);

                //GameObject thisButton = Instantiate(landOnPlanetButton, transform.position, transform.rotation);
                GameObject planetBox = Instantiate(planetDataBox, transform.position, transform.rotation);
                planetBox.transform.parent = planetConnectionsBox;
                planetBox.GetComponent<PlanetDataBoxPopulator>().PopulateData(sectorData.planets[p]);


            }
        } else {
            print("no planets");
        }
    }

    void ChangeSector(Sector newSector) {
        currentSector = newSector;
        InitializeSector();
    }

    void SetUIText(Text field, string textToSet) {
        field.text = textToSet;
    }
}
