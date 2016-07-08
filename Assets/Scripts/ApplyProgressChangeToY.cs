using UnityEngine;
using System.Collections;

public class ApplyProgressChangeToY : MonoBehaviour
{
    public GameObject managers;
    public float stepHeight = 0.19f;

    MouseBasedProgressManager progressManager;

    // Use this for initialization
    void Start() {
        progressManager = managers.GetComponent<MouseBasedProgressManager>();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.up * stepHeight * Mathf.Abs(progressManager.ProgressChange) * (progressManager.Reversed ? -1 : 1));
    }
}
