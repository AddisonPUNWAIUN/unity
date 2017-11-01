using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glacier : Terrains
{
    public List<GameObject> plates;
    public int waterUnits = 10;
    Transform water;
    
    void Start ()
    {
        water = transform.Find("Water");
        Transform icePlates = transform.Find("IcePlates");
        Transform ices = transform.Find("Ices");
        GameObject ice;
        Vector3 startPos = ices.position;
        int cols = (int)water.localScale.x;
        int rows = (int)water.localScale.z;
        for (int i = 0; i < ices.childCount; i++)
        {
            ice = ices.GetChild(i).gameObject;
            plates.Add(ice);
        }
        for (int x = 0; x < cols; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                    Instantiate(plates[Random.Range(0, plates.Count)],
                    startPos + new Vector3(x * waterUnits + Random.Range(-2f, 2f), 0, z * waterUnits + Random.Range(-2f, 2f)),
                    Quaternion.Euler(Vector3.up * Random.Range(0, 360)),
                    icePlates);
            }
        }
    }
	
	void Update ()
    {

	}
}
