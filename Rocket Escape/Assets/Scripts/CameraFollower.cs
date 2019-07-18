using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform Target;
    [SerializeField][Range(0,1)] float CameraLockSpeed = 1;
    private Vector3 Velocity = Vector3.zero;

    private void LateUpdate()
    {
        if(Target != null)
        {
            Vector3 DesiredPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            Vector3 SmoothPosition = Vector3.SmoothDamp(transform.position, DesiredPosition, ref Velocity, CameraLockSpeed);
            transform.position = SmoothPosition;
        }
    }

}
