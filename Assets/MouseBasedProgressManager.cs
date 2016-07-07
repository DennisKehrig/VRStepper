using UnityEngine;
using System.Collections;

public class MouseBasedProgressManager : MonoBehaviour {
    float y, minY, maxY;

    public float Progress { get; private set; }
    public float ProgressChange { get; private set; }

    // Use this for initialization
    void Start() {
        y = 0;
        minY = 0;
        maxY = 0;
        Progress = 0.5f;
        ProgressChange = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        float relY = Input.GetAxis("Mouse Y");
        if (relY == 0) {
            ProgressChange = 0.0f;
            return;
        }

        y += relY;
        float buffer = Mathf.Abs(relY) * 0.015f;
        minY += buffer;
        maxY -= buffer;

        if (y < minY)
            minY = y;
        else if (y > maxY)
            maxY = y;

        float range = maxY - minY;
        float progress = (range == 0) ? 0.5f : ((y - minY) / range);
        ProgressChange = progress - Progress;
        Progress = progress;
    }
}
