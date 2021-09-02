using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorDataBoxPopulator : MonoBehaviour {

    [SerializeField] Text sectorName;
    [SerializeField] Button sectorJumpButton;
    GameController gc;

    private void Start() {
        gc = FindObjectOfType<GameController>();
    }

    public void PopulateData(Sector sector) {
        sectorName.text = sector.sectorName;
        sectorJumpButton.onClick.AddListener(() => gc.ChangeSector(sector));

    }


}