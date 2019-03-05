using UnityEngine;

public class UIScreenControl : MonoBehaviour{

    public Transform player;
    public Camera camera;

    public float hight = 1.0f;
    public float distance = -3.0f;

    private Vector3 diff;

	void Start ()
    {
        camera.transform.position = player.position + new Vector3(0, hight, distance);

        diff = camera.transform.position - player.position;
    }

    void Update ()
    {
        if (Input.GetMouseButton(1))
        {
            //rotate
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            Vector3 rotate = new Vector3(y, x, 0);
            Vector3 cameraEulerAngle = camera.transform.eulerAngles;
            cameraEulerAngle = cameraEulerAngle + rotate;
            camera.transform.eulerAngles = cameraEulerAngle;

            //position
            diff = camera.transform.position - player.position;
            camera.transform.position = player.position + Quaternion.Euler(rotate) * diff;
        }
    }

}
