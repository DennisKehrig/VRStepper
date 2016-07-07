using UnityEngine;
using System.Collections;

public class ApplyProgressToY : MonoBehaviour {
    public GameObject managers;

    MouseBasedProgressManager progressManager;
    float centerY;

    // Use this for initialization
    void Start() {
        progressManager = managers.GetComponent<MouseBasedProgressManager>();
        centerY = transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        float y = centerY + (progressManager.Progress - 0.5f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
