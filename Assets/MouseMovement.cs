﻿using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
    public GameObject managers;

    MouseBasedProgressManager progressManager;
    float centerY;

    // Use this for initialization
    void Start() {
        Debug.Log("Managers: " + managers);
        progressManager = managers.GetComponent<MouseBasedProgressManager>();
        Debug.Log("Progress manager: " + progressManager);
        centerY = transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x, centerY + (progressManager.Progress - 0.5f), transform.position.z);
    }
}
