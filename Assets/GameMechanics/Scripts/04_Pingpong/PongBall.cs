using UnityEngine;

// Les 4: Pingpong
// De bal stuitert tegen de muren (tag "Wall") en de batjes (tag "Paddle").
// Gaat de bal in een doel (tag "Goal"), dan begint hij opnieuw in het midden.
public class PongBall : MonoBehaviour
{
    public Vector3 speed = new Vector3(6f, 4f, 0f);

    // Na elke tik tegen een batje gaat de bal iets sneller (1.05 = 5% sneller).
    public float speedUp = 1.05f;

    public AudioClip bounceSound;

    Vector3 startSpeed;

    void Start()
    {
        startSpeed = speed;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            // Weg van de muur: boven de muur omhoog, onder de muur omlaag.
            // Zo kan de bal nooit 'vast' komen te zitten in de muur.
            float direction = Mathf.Sign(transform.position.y - other.transform.position.y);
            speed.y = Mathf.Abs(speed.y) * direction;
            PlaySound();
        }
        else if (other.CompareTag("Paddle"))
        {
            float direction = Mathf.Sign(transform.position.x - other.transform.position.x);
            speed.x = Mathf.Abs(speed.x) * direction;
            speed = speed * speedUp;
            PlaySound();
        }
        else if (other.CompareTag("Goal"))
        {
            Debug.Log("Punt! De bal is in het doel bij " + other.name);
            // Opnieuw in het midden, richting de speler die net het punt kreeg.
            transform.position = Vector3.zero;
            speed = new Vector3(-Mathf.Sign(speed.x) * startSpeed.x, startSpeed.y, 0f);
        }
    }

    void PlaySound()
    {
        if (bounceSound != null)
        {
            AudioSource.PlayClipAtPoint(bounceSound, Camera.main != null ? Camera.main.transform.position : transform.position);
        }
    }
}
