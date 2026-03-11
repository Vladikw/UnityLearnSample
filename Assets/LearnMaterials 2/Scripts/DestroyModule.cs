using System.Collections;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1RMamVxE-yUpSfsPD_dEa4-Ak1qu6NTo83qY1O4XLxUY/edit?usp=sharing")]
public class DestroyModule : MonoBehaviour
{
    [Header("Destroy Settings")]

    [SerializeField]  // Делает приватное поле видимым в инспекторе
    [Range(0.1f, 5f)]
    [Tooltip("Задержка между уничтожением объектов (в секундах)")]
    private float destroyDelay = 1f;
    [SerializeField]
    [Range(0, 20)]
    [Tooltip("Минимальное количество объектов, которое должно остаться")]
    private int minimalDestroyingObjectsCount = 1;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    [ContextMenu("Activate Destroy Module")]
    public void ActivateModule()
    {
        StartCoroutine(DestroyRandomChildObjectCoroutine());
    }

    private IEnumerator DestroyRandomChildObjectCoroutine()
    {
        while (myTransform.childCount > minimalDestroyingObjectsCount)
        {
            int index = Random.Range(0, myTransform.childCount - 1);
            Destroy(myTransform.GetChild(index).gameObject);
            yield return new WaitForSeconds(destroyDelay);
        }
        Destroy(gameObject, Time.deltaTime);
    }
}
