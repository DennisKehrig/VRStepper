using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
    const float scaling = 0.05f;
    const float minStableTable = 1f;
    
    float y, minY, maxY, centerY;
    float lastMinChange, lastMaxChange;

    // Use this for initialization
    void Start () {
        centerY = transform.position.y;
        y = 0;
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

        if (y < minY) {
            minY = y;
            lastMinChange = Time.time;
            if ((Time.time - lastMaxChange) > minStableTable)
                maxY -= (minY - y);
        }
        else if (y > maxY) {
            maxY = y;
            lastMaxChange = Time.time;
            if ((Time.time - lastMinChange) > minStableTable)
                minY -= (maxY - y);
        }

        float distance = maxY - minY;
        float progress = (distance == 0) ? 0.5f : ((y - minY) / distance);
        Debug.Log("Distance: " + distance + ", progress: " + progress + ", min | cur | max --- " + minY + " | " + y + " | " + maxY);

        transform.position = new Vector3(transform.position.x, centerY + (progress - 0.5f), transform.position.z);
    }
}
