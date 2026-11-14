using UnityEngine;
using UnityEngine.InputSystem;

// Les 2: Besturen
// Beweegt de speler met de pijltjestoetsen of met W A S D.
// Een Makey Makey stuurt dezelfde toetsen, dus die werkt meteen.
public class PlayerMovement : MonoBehaviour
{
    // Snelheid in meter per seconde.
    public float speed = 5f;

    // Mag de speler ook naar voren en naar achteren? Zet uit voor een spel waarin je alleen naar links en rechts gaat.
    public bool moveForwardBack = true;

    // De speler blijft binnen dit gebied: van -limit tot +limit (in x en in z).
    public float limit = 9f;

    // De naam van de actie in Assets/GameMechanics/Input/Besturing.
    public string moveActionName = "Bewegen";

    InputAction moveAction;

    // Start wordt één keer aangeroepen, vlak voor de eerste Update.
    void Start()
    {
        moveAction = InputSystem.actions.FindAction(moveActionName);
        if (moveAction == null)
        {
            Debug.LogError("Actie '" + moveActionName + "' niet gevonden. Kijk in Assets/GameMechanics/Input/Besturing.", this);
        }
    }

    void Update()
    {
        if (moveAction == null) return;

        // De invoer is een Vector2: x = links/rechts, y = omhoog/omlaag (van -1 tot 1).
        Vector2 input = moveAction.ReadValue<Vector2>();

        // In de 3D-wereld wordt 'omhoog' op het toetsenbord 'naar voren' (de z-as).
        Vector3 direction = new Vector3(input.x, 0f, 0f);
        if (moveForwardBack)
        {
            direction.z = input.y;
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Binnen het speelveld blijven.
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -limit, limit);
        position.z = Mathf.Clamp(position.z, -limit, limit);
        transform.position = position;
    }
}
