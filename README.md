# GameMechanics

Unity-template voor **SKILLS REALISATIE, periode 4** van de opleiding IX (Immersive Experience), SintLucas.
Je leert hier gameplay programmeren in C#: losse game mechanics die samen een game worden.

Unity-versie: **6000.3.28f1** (Universal Render Pipeline, nieuw Input System).

## Het project openen

1. Klik op deze pagina op **Code → Download ZIP**.
2. Pak de ZIP uit naar een map op je laptop (bijvoorbeeld `Documenten\Unity`). Kies een korte map, niet je bureaublad en niet in OneDrive.
3. Na het uitpakken heb je een map **GameMechanics-main**. Staat daarin nog een map **GameMechanics-main**? Dan is de binnenste map het project.
   Het project is de map waarin je **Assets**, **Packages** en **ProjectSettings** ziet.
4. Open **Unity Hub** → **Add** → **Add project from disk** → kies die map.
5. Open het project met Unity **6000.3.28f1**. De eerste keer duurt het openen een paar minuten.

## Wat zit erin?

Alles staat in `Assets/GameMechanics`. Elke les heeft een eigen scene (`Scenes`) en eigen scripts (`Scripts`).

| Scene | Mechanic | Scripts |
|---|---|---|
| 01_Bewegen | bewegen en draaien met `Update` en `Time.deltaTime` | Mover, Rotator |
| 02_Besturen | besturen met toetsen en knoppen | PlayerMovement, ChangeColorOnAction |
| 03_Botsen | triggers en tags: oppakken, raken, terugkaatsen | Collector, Bounce |
| 04_Pingpong | een game voor twee spelers | PongBall, Paddle |
| 05_Score | punten bijhouden en tonen in de UI | ScoreManager |
| 06_Spawnen | objecten aanmaken met prefabs | Spawner, DestroyBelow |
| 07_GameState | levens, tijd, game over en opnieuw beginnen | GameManager |
| 08_MijnGame | lege start voor je eigen game | |

Verder: `Prefabs` (speler, munten, obstakels), `Materialen`, `Audio` en `Input`.

## Besturing en Makey Makey

De besturing staat in `Assets/GameMechanics/Input/Besturing` (ook te vinden via **Edit → Project Settings → Input System Package**).
Een **Makey Makey** gedraagt zich als toetsenbord en muis, dus werkt hij zonder extra code.

| Actie | Toetsen | Makey Makey |
|---|---|---|
| Bewegen | pijltjes, W A S D | voorkant: pijltjes; achterkant: W A S D |
| Actie | spatiebalk | voorkant: SPACE |
| Klik | linkermuisknop | voorkant: CLICK |
| Speler1 | W en S | achterkant: W en S |
| Speler2 | pijltjes op en neer | voorkant: pijltjes op en neer |

In een script lees je een actie zo uit:

```csharp
InputAction moveAction = InputSystem.actions.FindAction("Bewegen");
Vector2 input = moveAction.ReadValue<Vector2>();
```

De geluiden en de textuur zijn voor dit project gemaakt en mag je vrij gebruiken.
