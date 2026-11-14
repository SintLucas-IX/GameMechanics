using UnityEngine;

// Les 1: Bewegen
// Dit script laat een object draaien.
public class Rotator : MonoBehaviour
{
    // Hoeveel graden per seconde het object draait, om elke as (x, y, z).
    public Vector3 degreesPerSecond = new Vector3(0f, 90f, 0f);

    void Update()
    {
        transform.Rotate(degreesPerSecond * Time.deltaTime);
    }
}
