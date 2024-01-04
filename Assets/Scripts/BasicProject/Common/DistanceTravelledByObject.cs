using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTravelledByObject : MonoBehaviour
{
    public Text distanceText;
    public Text displayDistance;
    private Vector3 lastPosition;
    private float totalDistance;

    private void Start() {
        lastPosition = transform.position;
    }

    private void Update() {
        float distance = Vector3.Distance(lastPosition, transform.position);
        totalDistance += distance;
        lastPosition = transform.position;
        distanceText.text = string.Format("Distance:{0:#0.0} km", totalDistance / 1000f);
        displayDistance.text= string.Format("Distance:{0:#0.0} km", totalDistance / 1000f);
    }
    private void OnDestroy() {
        Debug.Log("Total distance travelled:" + totalDistance);
    }
}
