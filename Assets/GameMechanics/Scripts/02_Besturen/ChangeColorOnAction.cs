using UnityEngine;
using UnityEngine.InputSystem;

// Les 2: Besturen
// Geeft het object een andere kleur als je een knop indrukt.
// "Actie" = spatiebalk (Makey Makey: SPACE), "Klik" = linkermuisknop (Makey Makey: CLICK).
[RequireComponent(typeof(Renderer))]
public class ChangeColorOnAction : MonoBehaviour
{
    public string actionName = "Actie";
    public Color[] colors = { Color.white, Color.yellow, Color.cyan, Color.magenta };

    InputAction action;
    Renderer objectRenderer;
    int colorIndex = 0;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        action = InputSystem.actions.FindAction(actionName);
        if (action == null)
        {
            Debug.LogError("Actie '" + actionName + "' niet gevonden. Kijk in Assets/GameMechanics/Input/Besturing.", this);
        }
    }

    void Update()
    {
        // WasPressedThisFrame is alleen 'true' in de frame waarin je de knop indrukt, niet zolang je hem vasthoudt.
        if (action != null && action.WasPressedThisFrame())
        {
            colorIndex = (colorIndex + 1) % colors.Length;
            objectRenderer.material.color = colors[colorIndex];
        }
    }
}
