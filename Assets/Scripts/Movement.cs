using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public GameObject player;
    public float speed = 1;
    public float force = 10; 
    public Rigidbody2D rb;
    public Player m_player;

    public bool grounded = false;
    public Animator m_Animator;
    
	// Use this for initialization
	void Start () {
	
	}
	
    void Update() {

    }

	// Update is called once per frame
	void FixedUpdate () {
	    if(Input.GetButton("Horizontal")) {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed*Time.fixedDeltaTime, rb.velocity.y);
            
            if(Input.GetAxis("Horizontal") >= 0) {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            } else {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }

            m_player.direction = Mathf.Sign(rb.velocity.x);
        }

        

        m_Animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if(Input.GetButton("Jump") && grounded) {
            rb.AddForce(new Vector2(0, Input.GetAxis("Jump")*force*Time.fixedDeltaTime));
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        grounded = false;
    }

}
