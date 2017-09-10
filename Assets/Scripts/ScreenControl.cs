using UnityEngine;

public class ScreenControl : MonoBehaviour {

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
	
	void Update ()
    {

	}
}
