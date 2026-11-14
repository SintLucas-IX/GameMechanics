using UnityEngine;

// Les 6: Spawnen
// Maakt om de zoveel seconden een nieuw object aan (spawnen), op een willekeurige plek.
public class Spawner : MonoBehaviour
{
    // De prefabs die gespawnd kunnen worden. Elke keer wordt er willekeurig één gekozen.
    public GameObject[] prefabs;

    // Seconden tussen twee spawns.
    public float interval = 1f;

    // Objecten verschijnen tussen -rangeX en +rangeX links en rechts van de spawner.
    public float rangeX = 8f;

    float timer = 0f;

    void Update()
    {
        // De timer telt op met de tijd die verstreken is.
        timer = timer + Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        if (prefabs == null || prefabs.Length == 0) return;

        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        Vector3 position = transform.position + new Vector3(Random.Range(-rangeX, rangeX), 0f, 0f);

        // Instantiate maakt een kopie van de prefab in de scene.
        Instantiate(prefab, position, Quaternion.identity);
    }
}
