using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public bool lockScreen = false;
    public GameObject bullet;
    public Text scoreText;
    public int score = 0;
    public Animator m_Animator;
    public float direction = 1;
    public int life = 5;
    public Text LifeText;
    public Image[] LifeImage;
    public Text AmmoText;
    public int MaxAmmoAmount = 9;

    private int CurrentAmmoAmount;


    void OnLevelWasLoaded(int level) {
        if(level > 0) {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

            if(spawnPoint != null) {
                Debug.Log("Jest!");

                transform.position = spawnPoint.transform.position;
            }
        }
    }

	// Use this for initialization
	void Start () {
        CurrentAmmoAmount = MaxAmmoAmount;

        GameObject go = GameObject.FindGameObjectWithTag("LifeText");
        GameObject goAmmo = GameObject.FindGameObjectWithTag("AmmoText");
        GameObject[] goImage = GameObject.FindGameObjectsWithTag("LifeImage");

        if(go != null) {
            LifeText = go.GetComponent<Text>();
        }

        if(goAmmo != null) {
            AmmoText = goAmmo.GetComponent<Text>();
        }

        if(goImage != null) {
            LifeImage = new Image[goImage.Length];

            for(int i=0; i<goImage.Length; i++) {
                LifeImage[i] = goImage[i].GetComponent<Image>();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Reload")) {
            CurrentAmmoAmount = MaxAmmoAmount;
        }

        if(Input.GetButtonDown("Fire1") && CurrentAmmoAmount > 0) {
            GameObject go = Instantiate(bullet, 
                                transform.position,
                                Quaternion.identity) as GameObject;
            go.GetComponent<Bullet>().player = this;
            go.GetComponent<Bullet>().direction = direction;

            CurrentAmmoAmount--;
        }

        scoreText.text = score.ToString();
        LifeText.text = life.ToString();
        //AmmoText.text = CurrentAmmoAmount.ToString()+"/"+MaxAmmoAmount.ToString();

        for(int i=0; i<LifeImage.Length; i++) {
            string[] nameTrim = LifeImage[i].name.Split('_');
            int n = int.Parse(nameTrim[1]);

            if(n <= life) {
                LifeImage[i].enabled = true;
            } else {
                LifeImage[i].enabled = false;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        Destroyable go = coll.collider.GetComponent<Destroyable>();

        if(go != null) {
            life--;
        }

        if(life <= 0) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
