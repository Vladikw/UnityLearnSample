using System.Collections;
using UnityEngine;

public class ShrinkAndDestroySample : SampleScript
{
    [SerializeField] 
    private Transform target;

    public override void Use()
    {
        if (target != null)
            StartCoroutine(ShrinkAndDestroyChildren());
    }

    private IEnumerator ShrinkAndDestroyChildren()
    {
        foreach (Transform child in target)
        {
            StartCoroutine(ShrinkAndDestroy(child));
        }
        yield return null;
    }

    private IEnumerator ShrinkAndDestroy(Transform obj)
    {
        Vector3 startScale = obj.localScale;
        float t = 0;
        float duration = 1f;

        while (t < 1)
        {
            t += Time.deltaTime / duration;
            obj.localScale = Vector3.Lerp(startScale, Vector3.zero, t);
            yield return null;
        }
        Destroy(obj.gameObject);
    }
}