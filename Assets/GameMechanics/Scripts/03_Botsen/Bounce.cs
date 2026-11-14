using UnityEngine;

// Les 3: Botsen
// Beweegt heen en weer: als het object een muur raakt, keert het om.
//
// Let op: OnTriggerEnter werkt alleen als
// - één van de twee colliders 'Is Trigger' aan heeft, en
// - één van de twee objecten een Rigidbody heeft (hier: Is Kinematic aan, dan doet de zwaartekracht niets).
public class Bounce : MonoBehaviour
{
    public Vector3 speed = new Vector3(3f, 0f, 0f);
    public AudioClip bounceSound;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, Space.World);
    }

    // Wordt één keer aangeroepen als dit object een trigger binnengaat.
    void OnTriggerEnter(Collider other)
    {
        // Alleen omkeren bij objecten met de tag "Wall".
        if (other.CompareTag("Wall"))
        {
            speed = -speed;
            if (bounceSound != null)
            {
                AudioSource.PlayClipAtPoint(bounceSound, transform.position);
            }
        }
    }
}
