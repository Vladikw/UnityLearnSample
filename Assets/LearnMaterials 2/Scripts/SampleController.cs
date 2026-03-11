using System.Collections.Generic;
using UnityEngine;


public class SampleController : MonoBehaviour
{
    [SerializeField]
    private List<SampleScript> samples = new List<SampleScript>();

    // Запустить Use() у всех объектов
    [ContextMenu("Activate All Samples")]
    public void ActivateAll()
    {
        foreach (var sample in samples)
        {
            if (sample != null)
                sample.Use();
        }
    }
}