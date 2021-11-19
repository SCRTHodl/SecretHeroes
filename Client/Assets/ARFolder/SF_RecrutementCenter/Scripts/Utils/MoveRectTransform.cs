using System.Collections;
using UnityEngine;
//using DG.Tweening;

public class MoveRectTransform : MonoBehaviour
{
    public GameObject movedObject;
    public float duration;
    public bool loop;
    public GameObject[] goals;
    private void Start()
    {
        StartCoroutine(StartMovement());
    }
    //AR changed to LeanTween from DG 9/4
    private IEnumerator StartMovement()
    {
        do {
            foreach (var goal in goals)
            {
                movedObject.transform.LeanMove(goal.transform.localPosition, duration).setEase(LeanTweenType.linear);
                yield return new WaitForSeconds(duration);
            }
        }while (loop);
    }
}