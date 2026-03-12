using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    private InteractiveBox next;
    private LineRenderer line;

    private void Start()
    {
        // Добавляем LineRenderer для визуализации луча
        line = gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.cyan;
        line.endColor = Color.blue;
        line.enabled = false;
    }

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    private void Update()
    {
        if (next != null)
        {
            // Луч Scene View 
            Debug.DrawLine(transform.position, next.transform.position, Color.green);

            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, next.transform.position);

            // Пускаем луч от текущего бокса к следующему
            Vector3 direction = (next.transform.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, next.transform.position);

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, distance))
            {
                // Если луч попал в ObstacleItem
                ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                if (obstacle != null)
                {
                    obstacle.GetDamage(Time.deltaTime); // Урон каждый кадр
                }
            }
        }
        else
        {
            // Если нет next — выключаем линию
            if (line != null) line.enabled = false;
        }
    }
}