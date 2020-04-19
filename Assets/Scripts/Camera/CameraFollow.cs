using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Controller2D target;
    float offsetX = 5;

    private void LateUpdate() {
        transform.position = Vector3.right * (target.transform.position.x + offsetX) + Vector3.up * 2.44f + Vector3.forward * -10;
    }
}
