using UnityEngine;
using UnityEngine.InputSystem;

// Les 4: Pingpong
// Een batje dat op en neer gaat.
// "Speler1" = W en S (Makey Makey: achterkant), "Speler2" = pijltjes op en neer (Makey Makey: voorkant).
public class Paddle : MonoBehaviour
{
    public string actionName = "Speler1";
    public float speed = 8f;

    // Het batje blijft tussen -limit en +limit (in y).
    public float limit = 3.5f;

    InputAction action;

    void Start()
    {
        action = InputSystem.actions.FindAction(actionName);
        if (action == null)
        {
            Debug.LogError("Actie '" + actionName + "' niet gevonden. Kijk in Assets/GameMechanics/Input/Besturing.", this);
        }
    }

    void Update()
    {
        if (action == null) return;

        // Een 'Axis' geeft één getal: -1 (omlaag), 0 (niets) of 1 (omhoog).
        float input = action.ReadValue<float>();
        transform.Translate(0f, input * speed * Time.deltaTime, 0f, Space.World);

        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -limit, limit);
        transform.position = position;
    }
}
