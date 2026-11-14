using UnityEngine;

// Les 6: Spawnen
// Ruimt een object op als het onder de vloer is gevallen.
// Zonder opruimen blijven er steeds meer objecten bestaan en wordt je game traag.
public class DestroyBelow : MonoBehaviour
{
    public float minY = -2f;

    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
