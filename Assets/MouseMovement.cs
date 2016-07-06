using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
    const float scaling = 0.05f;
    const float minStableTable = 1f;
    
    float y, minY, maxY, centerY;
    float lastMinChange, lastMaxChange;
    double distanceMoved;

    // Use this for initialization
    void Start () {
        centerY = transform.position.y;
        y = 0;
        distanceMoved = 0;
        minY = 0;
        maxY = 0;
        lastMinChange = Time.time;
        lastMaxChange = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float relY = Input.GetAxis("Mouse Y");
        if (relY == 0)
            return;
        y += relY;
        distanceMoved += Mathf.Abs(relY);
        float buffer = (float)(distanceMoved * 0.01d);

        float effectiveMinY = minY + buffer;
        float effectiveMaxY = maxY - buffer;

        if (y < effectiveMinY) {
            minY = effectiveMinY = y;
            maxY = effectiveMaxY;
            distanceMoved = 0;
        }
        else if (y > effectiveMaxY) {
            maxY = effectiveMaxY = y;
            minY = effectiveMinY;
            distanceMoved = 0;
        }

        float range = effectiveMaxY - effectiveMinY;
        float progress = (range == 0) ? 0.5f : ((y - effectiveMinY) / range);

        transform.position = new Vector3(transform.position.x, centerY + (progress - 0.5f), transform.position.z);
    }
}
