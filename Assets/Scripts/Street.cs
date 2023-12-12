using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Street
{
    public GameObject building;
    public BuildType buildingType;
    public string buildName;


    public enum BuildType
    {
        Small,
        Medium,
        Big
    }
}
