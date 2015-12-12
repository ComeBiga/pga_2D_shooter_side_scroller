using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public List<GameObject> wayPoints = new List<GameObject>();
    public float wayPointTime = 2;

    private float currentWayPointTime = 0;
    private int currentWaypointIndex = 0;
    private bool destinationReached = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Vector3.Distance(transform.position, wayPoints[currentWaypointIndex].transform.position));

        if(!destinationReached) {
            if(Vector3.Distance(transform.position, wayPoints[currentWaypointIndex].transform.position) > 0.41f) {
                transform.position = Vector3.Lerp(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime);
            } else {
                transform.position = wayPoints[currentWaypointIndex].transform.position;
                destinationReached = true;
                currentWaypointIndex = (++currentWaypointIndex) % wayPoints.Count;
            }
        } else {
            currentWayPointTime += Time.deltaTime;

            if(currentWayPointTime >= wayPointTime) {
                destinationReached = false;
                currentWayPointTime = 0;
            }
        }

	}
}
