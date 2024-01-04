using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CalculatePlayerPath: MonoBehaviour {
    public Transform target;
    private NavMeshPath path;
    private LineRenderer line;
    private List<Vector3> points;
    private float elapsed = 0.0f;
    void Start() {
        path = new NavMeshPath();
        line = GetComponent<LineRenderer>();
        elapsed = 0.0f;
    }
    void Update() {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f) {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        }
        //Get the total points from path inside line 
        line.positionCount = path.corners.Length;
        //save all the points inside list
        points =path.corners.ToList();
        //draw line
        for(int i = 0; i < points.Count; i++) {
            line.SetPosition(i, points[i]);
        }
    }
}
