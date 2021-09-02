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

    void ChangeSector(Sector newSector) {
        currentSector = newSector;
        InitializeSector();
    }

    void SetUIText(Text field, string textToSet) {
        field.text = textToSet;
    }
}
