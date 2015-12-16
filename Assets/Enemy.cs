using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public List<WayPoint> wayPoints = new List<WayPoint>();
    public float wayPointTime = 2;
    public float moveSpeed = 5;
    public Rigidbody2D rb;

    private float currentWayPointTime = 0;
    private int currentWaypointIndex = 0;
    private bool destinationReached = false;

    public GameObject target = null;

    void Awake() {
        rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(target != null) {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            rb.velocity = direction * moveSpeed;
        } else {
            if(!destinationReached) {
                if(Vector3.Distance(transform.position, wayPoints[currentWaypointIndex].transform.position) > 0.1f) {
                    //transform.position = Vector3.Lerp(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime);
                    Vector2 direction = wayPoints[currentWaypointIndex].transform.position - transform.position;
                    direction.Normalize();

                    rb.velocity = direction * moveSpeed;
                } else {
                    transform.position = wayPoints[currentWaypointIndex].transform.position;
                    wayPointTime = wayPoints[currentWaypointIndex].waitTime;

                    destinationReached = true;
                    currentWaypointIndex = (++currentWaypointIndex) % wayPoints.Count;
                }
            } else {
                currentWayPointTime += Time.deltaTime;

                //Debug.Log(currentWayPointTime);

                if(currentWayPointTime >= wayPointTime) {
                    destinationReached = false;
                    currentWayPointTime = 0;
                }
            }
        }
        //Debug.Log(Vector3.Distance(transform.position, wayPoints[currentWaypointIndex].transform.position));
    }

    void OnTriggerEnter2D(Collider2D other) {
        Player player = other.GetComponent<Player>() as Player;

        if(player != null) {
            target = player.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        Player player = other.GetComponent<Player>() as Player;

        if(player != null) {
            target = null;
        }
    }
}
