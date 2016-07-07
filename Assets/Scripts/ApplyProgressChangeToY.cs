using UnityEngine;
using System.Collections;

public class ApplyProgressChangeToY : MonoBehaviour
{
    public GameObject managers;

    MouseBasedProgressManager progressManager;
    float initialY;

    // Use this for initialization
    void Start() {
        progressManager = managers.GetComponent<MouseBasedProgressManager>();
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.up * 0.1f * Mathf.Abs(progressManager.ProgressChange));
    }
}
