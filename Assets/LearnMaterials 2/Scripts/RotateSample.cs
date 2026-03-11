using System.Collections;
using UnityEngine;

public class RotateSample : SampleScript
{
    [SerializeField] 
    private Vector3 rotationAngle = new Vector3(0, 90, 0);

    [SerializeField] 
    private float rotationSpeed = 10f;

    public override void Use()
    {
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        Quaternion start = transform.rotation;
        Quaternion end = start * Quaternion.Euler(rotationAngle);
        float maxAngle = rotationAngle.magnitude;
        float duration = maxAngle / rotationSpeed;

        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            transform.rotation = Quaternion.Slerp(start, end, t);
            yield return null;
        }
        transform.rotation = end;
    }
}