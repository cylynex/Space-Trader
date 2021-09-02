using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Sector")]
public class Sector : ScriptableObject {

    [SerializeField] public string sectorName;
    [TextArea(50, 100)] [SerializeField] public string sectorFlavorText;
    [SerializeField] public Sector[] connectedSectors;

    public SectorData GetSectorData() {
        SectorData sectorData = new SectorData();
        sectorData.sectorFlavorText = sectorFlavorText;
        sectorData.connectedSectors = connectedSectors;
        sectorData.sectorName = sectorName;
        return sectorData;
    }


}
