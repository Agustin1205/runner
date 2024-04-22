using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    // indica si el juego ha terminado
    public static bool gameOver = false;

    
    public Text distanceText;
    public Text gameOverText;

    private float distance = 0;

    void Start()
    {
        // Al inicio del juego, reiniciar las variables y desactivar el texto de "Game Over"
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Si el juego ha terminado
        if (gameOver)
        {
            // texto de "Game Over" y la distancia recorrida
            Time.timeScale = 0;
            int roundedDistance = Mathf.RoundToInt(distance); 
            gameOverText.text = "Game Over \n Total Distance: " + roundedDistance.ToString();
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            
            distance += Time.deltaTime;
            int roundedDistance = Mathf.RoundToInt(distance);
            distanceText.text = roundedDistance.ToString();
        }
    }
}