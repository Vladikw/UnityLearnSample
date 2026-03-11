using System.Collections;
using UnityEngine;

public class MoveSample : SampleScript
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float speed = 1f;

    private void Reset()
    {
        targetPoint = new GameObject("TargetPoint").transform;
    }

    public override void Use()
    {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        Vector3 start = transform.position;
        Vector3 end = targetPoint.position;
        float distance = Vector3.Distance(start, end);
        float duration = distance / speed;

        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        transform.position = end;
    }
}