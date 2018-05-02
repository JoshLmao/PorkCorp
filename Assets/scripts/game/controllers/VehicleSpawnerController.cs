using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class VehicleSpawnerController : MonoBehaviour {

    [SerializeField]
    GameObject m_movingVehiclesParent;

    [SerializeField]
    Transform m_startPosition;

    [SerializeField]
    Transform m_stopPosition;

    [SerializeField]
    Transform m_endPosition;

    [SerializeField]
    GameObject[] m_vehiclePrefabs;

    DistributionManager m_distributionManager = null;
    List<GameObject> m_spawnedVehicles = new List<GameObject>();
    List<int> m_cooldownIndexes = new List<int>();

    const float VEHICLE_UPDATE_SECONDS = 5f;
    const float VEHICLE_COOLDOWN_SECONDS = 30f;

    private void Awake()
    {
        m_distributionManager = FindObjectOfType<DistributionManager>();
    }

    private void Start()
    {
        StartCoroutine(SpawnVehicles());
    }

    public void SpawnVehicle(ISellVehicle vehicle)
    {
        GameObject foundPrefab = m_vehiclePrefabs.FirstOrDefault(x => x.name == vehicle.Name);
        if (foundPrefab == null)
            return;

        GameObject spawnedVehicle = Instantiate(foundPrefab, m_movingVehiclesParent.transform);
        VehicleController vehicleController = spawnedVehicle.GetComponent<VehicleController>();
        vehicleController.SetStop(m_stopPosition.position);
        vehicleController.SetEnd(m_endPosition.position);
        vehicleController.Info = vehicle;
        vehicleController.OnVehicleFinished += OnVehicleFinished;

        m_spawnedVehicles.Add(spawnedVehicle);
    }

    public void OnVehicleFinished(GameObject vehicle)
    {
        if (m_spawnedVehicles.Contains(vehicle))
        {
            VehicleController vehicleController = vehicle.GetComponent<VehicleController>();
            vehicleController.OnVehicleFinished -= OnVehicleFinished;
            m_spawnedVehicles.Remove(vehicle);
            Destroy(vehicle);
            
            if(vehicleController.Info !=null)
                StartCoroutine(WaitAndRemove(vehicleController.Info.VehicleIndex));
        }
        else
        {
            Debug.Log("Can't find spawned vehicle to remove");
        }
    }

    IEnumerator SpawnVehicles()
    {
        while (true)
        {
            if (m_spawnedVehicles.Count == 0 && m_distributionManager.BoughtVehicles != null)
            {
                int randIndex = Random.Range(0, m_distributionManager.BoughtVehicles.Count - 1);
                //Only spawn if index isn't on cooldown
                if (!m_cooldownIndexes.Contains(randIndex))
                {
                    ISellVehicle vehicle = m_distributionManager.BoughtVehicles.ElementAt(randIndex);
                    SpawnVehicle(vehicle);
                    m_cooldownIndexes.Add(vehicle.VehicleIndex);
                }
            }
            
            yield return new WaitForSeconds(VEHICLE_UPDATE_SECONDS);
        }
    }

    IEnumerator WaitAndRemove(int index)
    {
        yield return new WaitForSeconds(VEHICLE_COOLDOWN_SECONDS);
        m_cooldownIndexes.Remove(index);
    }
}
