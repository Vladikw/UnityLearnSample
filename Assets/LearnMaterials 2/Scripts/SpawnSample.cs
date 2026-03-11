using UnityEngine;

public class SpawnSample : SampleScript
{
    [SerializeField] 
    private GameObject prefab;


    [SerializeField] 
    private int count = 5;


    [SerializeField] 
    private float step = 1f;

    public override void Use()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, transform.position + transform.forward * step * i, transform.rotation);
        }
    }
}