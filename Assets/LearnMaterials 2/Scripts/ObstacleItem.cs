using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float currentValue = 1f;

    public UnityEvent onDestroyObstacle;

    private Material material;
    private Color startColor = Color.white;
    private Color endColor = Color.red;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            UpdateColor();
        }
    }

    public void GetDamage(float value)
    {
        currentValue = Mathf.Clamp01(currentValue - value);
        UpdateColor();

        if (currentValue <= 0)
        {
            onDestroyObstacle?.Invoke();
            Destroy(gameObject);
        }
    }

    private void UpdateColor()
    {
        if (material != null)
        {
            material.color = Color.Lerp(endColor, startColor, currentValue);
        }
    }
}