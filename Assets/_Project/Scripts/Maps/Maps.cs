using System;
using UnityEngine;

public class Maps : MonoBehaviour
{
    [SerializeField] private GameObject[] mapsArr;
    [SerializeField] private Transform[] mapsSpawner;

    private int arrIndex;
    private int indexDespawn;

    public void OnEnterBehaviour()
    {
        arrIndex = (arrIndex + 1) % mapsSpawner.Length;
        GameObject maps = mapsArr[arrIndex];
        maps.SetActive(true);
        maps.transform.SetPositionAndRotation(new Vector3(mapsSpawner[arrIndex].position.x, mapsSpawner[arrIndex].position.y), Quaternion.identity);
    }

    public void OnExitBehaviour()
    {
        indexDespawn = (arrIndex - 1 + mapsArr.Length) % mapsArr.Length;
        GameObject mapToDespawn = mapsArr[indexDespawn];
        mapToDespawn.SetActive(false);
    }
}
