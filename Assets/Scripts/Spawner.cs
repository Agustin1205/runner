using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // El prefab que quieres spawnear
    public float spawnInterval = 1.0f; // El intervalo de tiempo entre cada spawn
    private float timer = 0.0f;

    void Update()
    {
        // Incrementar el temporizador
        timer += Time.deltaTime;

        // Verificar si es tiempo de spawnear un nuevo prefab
        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0.0f; // Resetear el temporizador
        }
    }

    void SpawnPrefab()
    {
        // Spawnear el prefab en la posición del spawner
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}