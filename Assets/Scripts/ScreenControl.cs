using UnityEngine;

public class ScreenControl : MonoBehaviour{

    public Transform m_Cam;

	void Start ()
    {

        if (m_Cam != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Warning: no main camera found");
        }

    }
	
    Vector3 pos;
    bool isPointerDowwn;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0)) {
            isPointerDowwn = true;
            pos = Input.mousePosition;
            if (pos.x < transform.position.x) {
                return;
            }
        }

        if (Input.GetMouseButton(0) && isPointerDowwn){
            Debug.Log(transform.position);
            float distance = (Input.mousePosition - pos).x;
            float ditrction = distance > 0 ? 1.0f : -1.0f;
            float tmpDis = Mathf.Abs(distance) / 300.0f * 100;
            m_Cam.Rotate(Vector3.up, ditrction * tmpDis * 1.0f * Time.deltaTime, Space.World);
        }
    }

}
