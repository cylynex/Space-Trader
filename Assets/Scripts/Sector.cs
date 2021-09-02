using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Sector")]
public class Sector : ScriptableObject {

    [SerializeField] public string sectorName;
    [TextArea(50, 100)] [SerializeField] public string sectorFlavorText;
    [SerializeField] public Sector[] connectedSectors;
    [SerializeField] public Planet[] planets;

    public SectorData GetSectorData() {
        SectorData sectorData = new SectorData();
        sectorData.sectorName = sectorName;
        sectorData.sectorFlavorText = sectorFlavorText;
        sectorData.connectedSectors = connectedSectors;
        sectorData.planets = planets;
        return sectorData;
    }


}
