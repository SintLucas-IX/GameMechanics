using UnityEngine;

// Les 3: Botsen (en later: les 5 Score, les 7 Game state)
// Zet dit script op de speler. Het reageert op wat de speler raakt:
// - een object met de tag "Pickup": oppakken (geluid, punten, weg);
// - een object met de tag "Obstacle": geraakt (geluid, leven kwijt, weg).
// De speler heeft een Rigidbody met 'Is Kinematic' aan; de pickups en obstakels hebben 'Is Trigger' aan.
public class Collector : MonoBehaviour
{
    [Header("Les 3: geluid")]
    public AudioClip pickupSound;
    public AudioClip hitSound;

    [Header("Les 5: score (mag leeg blijven)")]
    public ScoreManager scoreManager;
    public int pointsPerPickup = 1;

    [Header("Les 7: levens (mag leeg blijven)")]
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            PlaySound(pickupSound);
            if (scoreManager != null)
            {
                scoreManager.AddPoints(pointsPerPickup);
            }
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            PlaySound(hitSound);
            if (gameManager != null)
            {
                gameManager.LoseLife();
            }
            Destroy(other.gameObject);
        }
    }

    // Speelt een geluid af bij de camera, zodat je het altijd even hard hoort.
    void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        Vector3 position = Camera.main != null ? Camera.main.transform.position : transform.position;
        AudioSource.PlayClipAtPoint(clip, position);
    }
}
