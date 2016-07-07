using UnityEngine;
using System.Collections;

public class ApplyProgressToX : MonoBehaviour
{
    public GameObject managers;

    MouseBasedProgressManager progressManager;
    float centerX;

    // Use this for initialization
    void Start() {
        progressManager = managers.GetComponent<MouseBasedProgressManager>();
        centerX = transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        float x = centerX + (progressManager.Progress - 0.5f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
