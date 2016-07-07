using UnityEngine;
using System.Collections;

public class MouseBasedProgressManager : MonoBehaviour {
    const float initialProgress = 0.5f;
    const int initialBoundariesFactor = 5;

    float y, minY, maxY;

    public float Progress { get; private set; }
    public float ProgressChange { get; private set; }

    // Use this for initialization
    void Start() {
        y = 0;
        minY = 0;
        maxY = 0;
        Progress = initialProgress;
        ProgressChange = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        float relY = Input.GetAxis("Mouse Y");
        if (relY == 0) {
            ProgressChange = 0.0f;
            return;
        }

        float diffY = Mathf.Abs(relY);
        if (minY == 0 && maxY == 0) {
            maxY = initialBoundariesFactor * diffY;
            minY = initialBoundariesFactor * -diffY;
        }

        float buffer = diffY * 0.015f;
        minY += buffer;
        maxY -= buffer;

        y += relY;
        if (y < minY)
            minY = y;
        else if (y > maxY)
            maxY = y;

        float range = maxY - minY;
        float progress = (range == 0) ? initialProgress : ((y - minY) / range);
        ProgressChange = progress - Progress;
        Progress = progress;
    }
}
