using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePathStatic : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private Transform path;
    [SerializeField]
    private float MoveTime = 0.0f;

    void Start()
    {
        LeanTween.move(Target,path.position,MoveTime).setRepeat(10);
    }
}
