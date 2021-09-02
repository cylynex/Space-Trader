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

    [Header("Sectors")]
    [SerializeField] Transform sectorConnectionsBox;
    [SerializeField] GameObject sectorDataBox;
    [SerializeField] GameObject changeSectorButton;

    [Header("Planets")]
    [SerializeField] Transform planetConnectionsBox;
    [SerializeField] GameObject planetDataBox;

    [Header("Ports")]
    [SerializeField] Transform portConnectionsBox;
    [SerializeField] GameObject portDataBox;

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
        SetupSectorDisplay();
        ShowConnections();
        ShowPlanets();
        ShowPorts();
    }

    void SetupSectorDisplay() {
        SetUIText(sectorName, sectorData.sectorName);
        SetUIText(sectorFlavorText, sectorData.sectorFlavorText);
    }

    void ShowConnections() {
        for (int s = 0; s < sectorData.connectedSectors.Length;s++) {
            GameObject sectorBox = Instantiate(sectorDataBox, transform.position, transform.rotation);
            sectorBox.transform.parent = sectorConnectionsBox;
            sectorBox.GetComponent<SectorDataBoxPopulator>().PopulateData(sectorData.connectedSectors[s]);
        }

    }

    void ShowPlanets() {
        if (sectorData.planets != null) {
            for (int p = 0; p < sectorData.planets.Length; p++) {
                GameObject planetBox = Instantiate(planetDataBox, transform.position, transform.rotation);
                planetBox.transform.parent = planetConnectionsBox;
                planetBox.GetComponent<PlanetDataBoxPopulator>().PopulateData(sectorData.planets[p]);
            }
        } else {
            print("no planets");
        }
    }

    void ShowPorts() {
        if (sectorData.ports != null) {
            for (int p = 0; p < sectorData.ports.Length; p++) {
                GameObject portBox = Instantiate(portDataBox, transform.position, transform.rotation);
                portBox.transform.parent = portConnectionsBox;
                portBox.GetComponent<PortDataBoxPopulator>().PopulateData(sectorData.ports[p]);
            }
        }

    }

    public void ChangeSector(Sector newSector) {
        currentSector = newSector;
        InitializeSector();
    }

    void SetUIText(Text field, string textToSet) {
        field.text = textToSet;
    }
}
