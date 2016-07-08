using UnityEngine;
using System.Collections;

public class MouseBasedProgressManager : MonoBehaviour {
    const float initialProgress = 0.5f;
    const float toleranceOnEnter = 0.1f;
    const float toleranceOnLeave = 0.2f;
    const float extremeTolerance = 0.2f;
    const float minRange = 3;
    const int proximityCountForAdjustment = 3;

    bool initialized;
    float y, minY, maxY;

    float recentMinY, recentMaxY;
    int proximityMinYCount, proximityMaxYCount;

    bool wasCentered, wasIncreasing;

    public float Progress { get; private set; }
    public float ProgressChange { get; private set; }
    public bool Reversed { get; private set; }

    // Use this for initialization
    void Start() {
        initialized = false;
        y = 0;
        minY = maxY = 0;

        recentMinY = float.MaxValue;
        recentMaxY = float.MinValue;
        proximityMinYCount = proximityMaxYCount = 0;

        wasCentered = false;
        wasIncreasing = false;

        Reversed = false;
        Progress = initialProgress;
        ProgressChange = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        // Get the relative change
        float relY = Input.GetAxis("Mouse Y");

        // If nothing changed, there's nothing to do: report no change and return
        if (relY == 0) {
            ProgressChange = 0.0f;
            return;
        }

        // Apply the change, but remember the previous value
        float previousY = y;
        y += relY;

        // Before we've seen a sufficient range of values, data is too random to interpret, so simply collect more
        if (!initialized) {
            if (y < minY)
                minY = y;
            else if (y > maxY)
                maxY = y;
        }

        if (!initialized) {
            // Check whether we have enough data
            if ((maxY - minY) > minRange)
                initialized = true;
            // Else return
            else
                return;
        }

        // If we're still here, we've seen a sufficiently large difference between minY and maxY

        // If the value is decreasing
        if (relY < 0) {
            float thresholdMinY = minY + extremeTolerance * (maxY - minY);

            if (y <= thresholdMinY) {
                if (previousY > thresholdMinY)
                    proximityMinYCount++;
                if (y < recentMinY)
                    recentMinY = y;
            }
            if (y < minY || proximityMinYCount >= proximityCountForAdjustment) {
                minY = y < recentMinY ? y : recentMinY;
                recentMinY = float.MaxValue;
                proximityMinYCount = 0;
            }
        }
        // If the value is increasing
        else {
            float thresholdMaxY = maxY - extremeTolerance * (maxY - minY);

            if (y >= thresholdMaxY) {
                if (previousY < thresholdMaxY)
                    proximityMaxYCount++;
                if (y > recentMaxY)
                    recentMaxY = y;
            }
            if (y > maxY || proximityMaxYCount >= proximityCountForAdjustment) {
                maxY = y > recentMaxY ? y : recentMaxY;
                recentMaxY = float.MinValue;
                proximityMaxYCount = 0;
            }
        }

        float progress = ((y - minY) / (maxY - minY));

        float lowerCenterLimit = 0.5f - ((!wasCentered || wasIncreasing)  ? toleranceOnEnter : toleranceOnLeave);
        float upperCenterLimit = 0.5f + ((!wasCentered || !wasIncreasing) ? toleranceOnEnter : toleranceOnLeave);
        bool isCentered = !(progress < lowerCenterLimit || progress > upperCenterLimit);
        if (isCentered != wasCentered) {
            if (wasCentered) {
                wasCentered = false;
                bool isIncreasing = relY > 0;
                if (isIncreasing != wasIncreasing)
                    Reversed = !Reversed;
            }
            else {
                wasCentered = true;
                wasIncreasing = relY > 0;
            }
        }

        ProgressChange = progress - Progress;
        Progress = progress;
    }
}
