using UnityEngine;

// Les 1: Bewegen
// Dit script laat een object elke frame een stukje bewegen.
public class Mover : MonoBehaviour
{
    // De snelheid in meter per seconde, voor elke as (x, y, z).
    // Pas deze waarde aan in de Inspector en kijk wat er gebeurt.
    public Vector3 speed = new Vector3(1f, 0f, 0f);

    // Update wordt elke frame aangeroepen: vaak 60 keer per seconde of vaker.
    void Update()
    {
        // Time.deltaTime is de tijd sinds de vorige frame, in seconden.
        // Door daarmee te vermenigvuldigen beweegt het object op elke computer even snel.
        transform.Translate(speed * Time.deltaTime, Space.World);
    }
}
