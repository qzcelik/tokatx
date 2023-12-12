using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

   
    [SerializeField]
    private float speed = 0;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x+Time.deltaTime* speed, transform.position.y, transform.position.z);
    }
}
