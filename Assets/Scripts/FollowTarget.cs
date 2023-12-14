using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x - 25, target.transform.position.y + 35, target.transform.position.z);
    }
}
