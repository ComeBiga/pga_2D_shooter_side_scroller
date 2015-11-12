using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 10;
    public Player player;
    public GameObject boom;
    public float direction = 1;

	void Start () {
        rb.velocity = new Vector2(speed * direction, 0);
	}
	
	void Update () {
	
	}
	
    void OnCollisionEnter2D(Collision2D coll) {
        GameObject go = Instantiate(boom,
                                transform.position,
                                Quaternion.identity) as GameObject;
        Destroy(go, 0.25f);
        Destroy(gameObject);
    }
}
