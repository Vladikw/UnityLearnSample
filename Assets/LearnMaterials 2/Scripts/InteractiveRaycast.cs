using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab; 
    private InteractiveBox selectedBox;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Левая кнопка
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Клик по плоскости с тегом InteractivePlane
                if (hit.collider.CompareTag("InteractivePlane"))
                {
                    Vector3 spawnPos = hit.point + hit.normal * 0.5f;
                    Instantiate(prefab, spawnPos, Quaternion.identity);
                }
                // Клик по объекту с InteractiveBox
                else if (hit.collider.TryGetComponent(out InteractiveBox box))
                {
                    if (selectedBox == null)
                    {
                        selectedBox = box; 
                    }
                    else
                    {
                        selectedBox.AddNext(box); 
                        selectedBox = null; 
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) // Правая кнопка
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out InteractiveBox box))
                {
                    Destroy(box.gameObject); 
                }
            }
        }
    }
}