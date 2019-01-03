using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	void Start () {
        UIJoystickControl.Instance.joystickDragDelegate = OnJoystickDrag;
	}
	
	void Update () {
		
	}

    public void OnJoystickDrag(Vector3 coor)
    {
        Vector3 dir = new Vector3(coor.x, 0, coor.y);
        Quaternion quaternion = Quaternion.LookRotation(dir);

        transform.rotation = quaternion;

        transform.position += transform.forward * Time.deltaTime * 2.0f;
    }
}
