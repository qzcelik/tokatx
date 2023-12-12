

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float speed;
    private Vector3 cursorPosition;
    private void Start()
    {
        RayController.OnCursorPositionChange += GetCurrentMouseCursor;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var instanceBullet =  Instantiate(bullet, target.transform.position, Quaternion.identity);
            instanceBullet.transform.LookAt(cursorPosition);
            instanceBullet.GetComponent<Rigidbody>().velocity = target.transform.right*speed;
        }
    }

    void GetCurrentMouseCursor(Vector3 cursorPosition)
    {
        this.cursorPosition = cursorPosition;
    }

    void GunVisibilty(bool visibility)
    {
        target.transform.parent.gameObject.SetActive(!visibility);
    }
}
