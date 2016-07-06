using UnityEngine;
using System.Collections;

public class AutonomousMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float time = Time.timeSinceLevelLoad % (2 * Mathf.PI);
        float amount = Mathf.Sin(time * 3);
        this.transform.position = new Vector3(amount, this.transform.position.y, this.transform.position.z);
    }
}
