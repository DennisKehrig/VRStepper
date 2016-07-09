using UnityEngine;
using System.Collections;

public class ApplyProgressToModel : MonoBehaviour {
    const float minAngle = -0.75f;
    const float maxAngle = 25;

    public GameObject Managers;
    public GameObject LeftPedal;
    public GameObject RightPedal;

    MouseBasedProgressManager progressManager;
    
    // Use this for initialization
    void Start () {
        progressManager = Managers.GetComponent<MouseBasedProgressManager>();
    }

    // Update is called once per frame
    void Update () {
        float progress = progressManager.Progress;
        RightPedal.transform.eulerAngles = new Vector3(minAngle +      progress  * (maxAngle - minAngle), 0, 0);
        LeftPedal.transform.eulerAngles  = new Vector3(minAngle + (1 - progress) * (maxAngle - minAngle), 0, 0);
    }
}
