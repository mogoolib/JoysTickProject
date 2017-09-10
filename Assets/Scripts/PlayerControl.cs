using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Joystick m_Joystick;

    private void Start()
    {
        m_Joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        float h = m_Joystick.targetDirection.x;
        float v = m_Joystick.targetDirection.y;
        if (h != 0 || v != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
