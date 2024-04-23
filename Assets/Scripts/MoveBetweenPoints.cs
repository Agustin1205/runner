using UnityEngine;

public class MoveBetweenGameObjects : MonoBehaviour
{
    public GameObject pointA; // GameObject que representa el punto A
    public GameObject pointB; // GameObject que representa el punto B

    public float speed = 5.0f; // Velocidad de movimiento

    private Vector3 targetPosition; // Posición objetivo actual
    private GameObject targetObject; // Objeto objetivo actual

    void Start()
    {
        // Establecer el punto A como destino inicial
        SetDestination(pointA);
    }

    void Update()
    {
        // Mover el objeto hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Si el objeto llega al punto objetivo, cambiar el objetivo al punto opuesto
        if (transform.position == targetPosition)
        {
            if (targetObject == pointA)
                SetDestination(pointB);
            else
                SetDestination(pointA);
        }
    }

    // Método para establecer el destino y la posición objetivo
    void SetDestination(GameObject destination)
    {
        targetObject = destination;
        targetPosition = destination.transform.position;
    }
}