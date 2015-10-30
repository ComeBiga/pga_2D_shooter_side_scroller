using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public bool lockScreen = false;
    public GameObject bullet;
    public Text scoreText;
    public int score = 0;
    public Animator m_Animator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1")) {
            GameObject go = Instantiate(bullet, 
                                transform.position,
                                Quaternion.identity) as GameObject;
            go.GetComponent<Bullet>().player = this;
        }

        scoreText.text = score.ToString();
	}
}
