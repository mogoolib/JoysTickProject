using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour , IDragHandler , IPointerDownHandler , IPointerUpHandler{

    [Header("[摇杆背景RectTeansform]")]
    public RectTransform joysTickBGRect;

    [Header("[摇杆按钮Teansform]")]
    public Transform joysTickBtnTransForm;

    [Header("[摇杆移动半径]")]
    public float radius = 60;

    [Header("[摇杆复位复位方式]")]
    [Tooltip("0：差值运动 1：自定义动作")]
    [Range(0,1)]
    public int resetType = 0; //0：差值运动 1：自定义动作

    [Header("[摇杆复位速度系数]")]
    public float spFactor = 3.0f;

    [Header("[摇杆自定义动作]")]
    public AnimationCurve customAnimCurve;

    [Header("[摇杆自定义动作持续时间]")]
    public float durationTime = 2.0f;

    private bool pointerUp = false; //是否抬起
    private bool isActionPlay = false;
    private float deltaX = 0;
    private Vector3 defaultPositionX = Vector3.zero;

    void Start () {
        Debug.Log("resetType == " + resetType);
	}

	void Update () {
        if (pointerUp){
            joysTickBtnTransForm.localPosition = Vector3.Lerp(joysTickBtnTransForm.localPosition, Vector3.zero, Time.deltaTime * spFactor);
        }
        if (isActionPlay) {
            deltaX += Time.deltaTime/durationTime;
            joysTickBtnTransForm.localPosition = Vector3.LerpUnclamped(defaultPositionX, Vector3.zero, customAnimCurve.Evaluate(deltaX));
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joysTickBGRect, eventData.position,eventData.enterEventCamera,out localPosition);
        joysTickBtnTransForm.localPosition = Vector2.ClampMagnitude(localPosition,radius);
        pointerUp = false;
        isActionPlay = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (resetType == 0) {
            pointerUp = true;
        } else if (resetType == 1) {
            isActionPlay = true;
            deltaX = 0;
            defaultPositionX = joysTickBtnTransForm.localPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
    
}
