using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTask3 : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] Transform PosicionPieza;
    [SerializeField] Transform Target;
    public GameObject GM;
    public GameManager GameManager;
    bool Snaped;
    float SnapDistance = 12;

    private void Awake()
    {
        GameManager = GM.GetComponent<GameManager>();
    }


    private void FixedUpdate()
    {
        if (Snaped == true)
        {
            return;
        }
        if (Vector3.Distance(PosicionPieza.position, Target.position) < SnapDistance)
        {
            transform.position = Target.position;
            Snaped = true;


        }
    }
    public void DragHandler(BaseEventData data)
    {
        if (Snaped == true)
        {
            return;
        }
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, 
            pointerData.position, 
            canvas.worldCamera, 
            out position);

        transform.position = canvas.transform.TransformPoint(position);

    }
}
