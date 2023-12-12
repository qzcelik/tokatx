using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovePath : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private List<Vector3> pathScreen;
    [SerializeField]
    private float MoveTime = 0.0f;
    public static MovePath instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetPath(List<Vector3> pathScreen)
    {
        this.pathScreen = pathScreen;
        StartCoroutine(RunPath());
    }
    IEnumerator RunPath()
    {

        for (int i = 0; i < pathScreen.Count; i++)
        {
            LeanTween.move(Target, pathScreen[i], MoveTime).setEaseLinear();
            Target.transform.LookAt(pathScreen[i]);
            yield return new WaitForSeconds(MoveTime);
        }
        Target.transform.eulerAngles = new Vector3(0,90,0);

    }
}
