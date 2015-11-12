using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject m_StartGame;
    public GameObject m_ExitGame;
    public GameObject m_MainMenu;
    public bool pause = false;
    public static GameController instance;

    // Use this for initialization
    void Start () {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Cancel")) {
            pause = !pause;
        }

        if(Application.loadedLevel == 0) {
            m_StartGame.SetActive(true);
            m_ExitGame.SetActive(true);

            m_MainMenu.SetActive(false);
        } else {
            m_StartGame.SetActive(false);
            m_ExitGame.SetActive(false);

            if(pause) {
                m_MainMenu.SetActive(true);
            } else {
                m_MainMenu.SetActive(false);
            }
        }
	}

    public void StartGame() {
        Application.LoadLevel(1);
    }

    public void MainMenu() {
        pause = false;
        Application.LoadLevel(0);
    }

    public void ExitGame() {
        Application.Quit();
    }

}
