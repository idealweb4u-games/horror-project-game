using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : Singleton<VehicleManager>
{
    public GameObject currentVehicle;
    public Session session;
    private List<Transform> vehicles =new List<Transform>();
    private void Start() {
        //Get All levels
        foreach (Transform child in transform) {
            vehicles.Add(child);
            //Debug.Log(vehicles.Count);
        }
   
        //Inactive All the Levels
        foreach (Transform vehicle in vehicles) {
            vehicle.gameObject.SetActive(false);
        }
       // currentVehicle = vehicles[session.carNumber].gameObject;
        currentVehicle.SetActive(true);
    }
}
