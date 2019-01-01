using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJoystickControl : MonoBehaviour {

    public delegate void JoystickDragDelegate(Vector3 coor);
    public JoystickDragDelegate joystickDragDelegate;

    public delegate void JoystickDropDelegate();
    public JoystickDropDelegate joystickDropDelegate;


    public Transform border;

	private float moveDistance;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {

		startPosition = transform.position;

		moveDistance = Vector3.Distance(transform.position, border.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (joystickDragDelegate != null) {
            if (Vector3.Distance(transform.position, startPosition) > 0.1f) {
                Vector3 dir = (Input.mousePosition - startPosition).normalized;
                joystickDragDelegate(dir);
                print(dir);
            }
        }
	}

	//drag event callback
	public void OnJoystickDrag()
	{
		if(Vector3.Distance(Input.mousePosition, startPosition) < moveDistance){
			transform.position = Input.mousePosition;
		}else{
			Vector3 dir = (Input.mousePosition - startPosition).normalized;
			transform.position = startPosition + moveDistance * dir;
		}
	}

	//drop event callback
	public void OnJoystickDrop()
	{
		transform.position = startPosition;

        if (joystickDropDelegate != null) {
            joystickDropDelegate();
        }
	}
}
