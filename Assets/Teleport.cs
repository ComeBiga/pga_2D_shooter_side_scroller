using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Player") {
            Debug.Log("Jest gracz!");

            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

}
