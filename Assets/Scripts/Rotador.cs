using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    public float invisibleDuration = 5f; // Duraci�n de la invisibilidad
    private bool consumed = false; // Estado de si ha sido consumido o no

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !consumed)
        {
            // Desactivar el renderizador del jugador
            Renderer playerRenderer = other.GetComponent<Renderer>();
            if (playerRenderer != null)
            {
                playerRenderer.enabled = false;
            }

            // Establecer una corrutina para hacer visible al jugador despu�s de la duraci�n de la invisibilidad
            StartCoroutine(MakePlayerVisibleAfterDelay(other.gameObject));
            consumed = true;
        }
    }

    private IEnumerator MakePlayerVisibleAfterDelay(GameObject player)
    {
        // Esperar la duraci�n de la invisibilidad
        yield return new WaitForSeconds(invisibleDuration);

        // Activar el renderizador del jugador nuevamente
        Renderer playerRenderer = player.GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            playerRenderer.enabled = true;
        }
    }
}