using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float verticalSpeed = 2f; // Velocidad vertical
    public float verticalRange = 4f; // Rango vertical de movimiento

    private float initialY; // Posición inicial en Y

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        // Movimiento vertical
        float newY = initialY + Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}