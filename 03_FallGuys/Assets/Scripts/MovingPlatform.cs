using Microsoft.Extensions.Logging.Abstractions;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform platform = null;
    [SerializeField] private Transform endPoint = null;
    [SerializeField] private float moveSPeed = 2.0f;
    [SerializeField] private float waitDuration = 2.0f;

    private Coroutine movingCoroutine = null;
    private bool moveToEnd = true;


    private void OnEnable()
    { 
        ClearCoroutine();
        if (moveToEnd)
        {
            MoveToEnd();
        }
    }


    private void OnDisable()
    {
        ClearCoroutine();
    }

    private void ClearCoroutine()
    {
        if (movingCoroutine != null)
        {
            StopCoroutine(movingCoroutine);
        }
    }

    private void MoveToEnd()
    {
        moveToEnd = true;
        movingCoroutine = StartCoroutine(MovePlatform());
    }


    private void MoveToStart()
    {
        moveToEnd = false;
        movingCoroutine = StartCoroutine(MovePlatform());
    }


    IEnumerator MovePlatform()
    {
        while (true)
        {
            Vector3 targetPos = moveToEnd ? endPoint.transform.position : transform.position;
            //pause here for a frame, next frame start next line
            yield return null;

            //time = distance / speed;
            float duration = (platform.transform.position - targetPos).magnitude / moveSPeed;
            Tween moveTween = platform.DOMove(targetPos, duration);

            //come back when this animation is complete
            yield return moveTween.WaitForCompletion();

            moveTween.Kill();
            // paude for the wait duration
            yield return new WaitForSeconds(waitDuration);
            moveToEnd = !moveToEnd;
        }
    }
}

//platform.position += velocity * Time.deltaTime;
//