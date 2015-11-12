using UnityEngine;
using System.Collections;

public class CanvasSingleton : MonoBehaviour {
    public static CanvasSingleton instance;

    void Start () {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
	
	void Update () {
	
	}
}
