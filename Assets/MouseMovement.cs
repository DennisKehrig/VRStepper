using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
    float y, minY, maxY, centerY;

    // Use this for initialization
    void Start() {
        centerY = transform.position.y;
        y = 0;
        minY = 0;
        maxY = 0;
    }

    // Update is called once per frame
    void Update() {
        float relY = Input.GetAxis("Mouse Y");
        if (relY == 0)
            return;

        y += relY;
        float buffer = Mathf.Abs(relY) * 0.02f;
        minY += buffer;
        maxY -= buffer;

        if (y < minY)
            minY = y;
        else if (y > maxY)
            maxY = y;

        float range = maxY - minY;
        float progress = (range == 0) ? 0.5f : ((y - minY) / range);

        transform.position = new Vector3(transform.position.x, centerY + (progress - 0.5f), transform.position.z);
    }
}
