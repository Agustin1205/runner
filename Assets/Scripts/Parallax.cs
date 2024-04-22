using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startPos; // Longitud del sprite y posición inicial del objeto
    public float parallaxEffect = 0.5f; // Reducimos la velocidad del paralaje

    private bool isActive = true; // Controla si el efecto de paralaje debe aplicarse o no

    void Start()
    {
        startPos = transform.position.x; // Posición inicial en x 
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Obtener la longitud del sprite
    }

    void Update()
    {
        if (isActive) // Verificar si el efecto de paralaje debe aplicarse
        {
            
            transform.position = new Vector3(transform.position.x - (parallaxEffect * Time.deltaTime), transform.position.y, transform.position.z);

            
            if (transform.localPosition.x < -20)
            {
                transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }

    
    void OnBecameInvisible()
    {
        isActive = false; // Desactivar el efecto de paralaje
    }

    
    void OnBecameVisible()
    {
        isActive = true; 
    }
}