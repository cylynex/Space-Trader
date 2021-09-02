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

    private void Update() {
        GetInput(); 
    }

    void GetInput() {

        for (int index = 0;index < sectorData.connectedSectors.Length;index++) {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index)) {
                currentSector = sectorData.connectedSectors[index];
                InitializeSector();
            }
        }

    }

    void InitializeSector() {
        sectorData = currentSector.GetSectorData();
        SetUIText(sectorFlavorText, sectorData.sectorFlavorText);
        SetUIText(sectorName, sectorData.sectorName);
        ShowConnections();
    }

    void ShowConnections() {
        //int keycode = 1;
        //string output = "";
        for (int i = 0;i < sectorData.connectedSectors.Length;i++) {
            //output += keycode + " - " + sectorData.connectedSectors[i].sectorName+"("+i+")\n";
            //keycode++;

            GameObject thisButton = Instantiate(changeSectorButton, transform.position, transform.rotation);
            thisButton.transform.parent = sectorConnectionsBox;
            thisButton.GetComponentInChildren<Text>().text = sectorData.connectedSectors[i].sectorName;
            Sector buttonSector = sectorData.connectedSectors[i];
            Button button = thisButton.GetComponent<Button>();
            button.onClick.AddListener(() => ChangeSector(buttonSector));
        }
        
        //SetUIText(sectorConnections, output);
    }

    void ChangeSector(Sector newSector) {
        print(newSector.sectorName);
    }


    void SetUIText(Text field, string textToSet) {
        field.text = textToSet;
    }
}
