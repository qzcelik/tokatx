using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{

    [SerializeField]
    private GameObject mouseCursor;
    private Vector3 mouseCurrenPosition = Vector3.zero;
    RaycastHit hit;
    public static event Action<Vector3> OnCursorPositionChange;
 
    private void Start()
    {
        StartCoroutine(DrawUpdate());
    }
 
    private IEnumerator DrawUpdate()
    {
        while (true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                mouseCursor.transform.position = hit.point;
            }

            mouseCurrenPosition = mouseCursor.transform.position;
            if(OnCursorPositionChange != null)
            {
                OnCursorPositionChange.Invoke(mouseCurrenPosition);
            }

            yield return new WaitForSeconds(0.005f);
        }
    }


}
