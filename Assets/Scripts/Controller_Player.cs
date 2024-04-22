using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    public float moveSpeed = 5; // Velocidad de movimiento lateral
    private float initialSize;
    private int i = 0;
    private bool floored;

    private bool isInvisible = false; // Estado de la habilidad de invisibilidad
    private float invisibleDuration = 5f; // Duración de la invisibilidad
    private float invisibleCooldown = 5f; // Tiempo de recarga de la habilidad de invisibilidad
    private float invisibleTimer = 0f; // Temporizador para la habilidad de invisibilidad

    private float slowDownFactor = 0.5f; // Factor de ralentización del tiempo

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
    }

    void Update()
    {
        GetInput();
        HandleInvisibility();
    }

    private void GetInput()
    {
        Jump();
        Duck();
        ToggleInvisibility(); // Agregamos la función para activar/desactivar la invisibilidad
        SlowDownTime(); // Agregamos la función para ralentizar el tiempo
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private void ToggleInvisibility()
    {
        // Activar/desactivar la invisibilidad al presionar la tecla "T" si la habilidad está recargada
        if (Input.GetKeyDown(KeyCode.T) && !isInvisible)
        {
            isInvisible = true;
            gameObject.SetActive(false); // Desactivar al jugador
            invisibleTimer = invisibleDuration; // Establecer el tiempo de invisibilidad
        }
    }

    private void HandleInvisibility()
    {
        // Controlar la habilidad de invisibilidad
        if (isInvisible)
        {
            invisibleTimer -= Time.deltaTime;
            if (invisibleTimer <= 0f)
            {
                isInvisible = false;
                gameObject.SetActive(true); // Activar al jugador nuevamente
                invisibleTimer = invisibleCooldown; // Reiniciar el temporizador de recarga
            }
        }
    }

    private void SlowDownTime()
    {
        // Ralentizar el tiempo al presionar la tecla "F"
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = slowDownFactor;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            Time.timeScale = 1f; // Restaurar la velocidad normal del tiempo al soltar la tecla "F"
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (gameObject.activeSelf) // Verificar si este objeto está activo
            {
                Destroy(this.gameObject);
                Controller_Hud.gameOver = true;
            }
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }
}