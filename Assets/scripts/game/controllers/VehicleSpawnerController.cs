using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawnerController : MonoBehaviour {

    [SerializeField]
    GameObject m_movingVehiclesParent;

    public void SpawnVehicle(ISellVehicle vehicle)
    {
        //GameObject spawnedVehicle = Instantiate(vehicle.Prefab, m_movingVehiclesParent.transform);
    }

    public void OnVehicleFinished()
    {

    }
}
