using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Les 7: Game state
// De game is altijd in één toestand (state): aan het spelen, of afgelopen.
// Per toestand gebeurt er iets anders in Update.
public enum GameState
{
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public float timeLeft = 60f;

    [Header("UI")]
    public TMP_Text livesText;
    public TMP_Text timeText;
    public TMP_Text messageText;

    [Header("Mag leeg blijven")]
    public ScoreManager scoreManager;
    public AudioClip gameOverSound;

    // Met deze knop start je opnieuw als de game afgelopen is.
    public string restartActionName = "Actie";

    GameState state = GameState.Playing;
    InputAction restartAction;

    void Start()
    {
        // De tijd loopt weer gewoon (na een vorige game stond hij op 0).
        Time.timeScale = 1f;
        restartAction = InputSystem.actions.FindAction(restartActionName);
        if (messageText != null) messageText.text = "";
        UpdateTexts();
    }

    void Update()
    {
        switch (state)
        {
            case GameState.Playing:
                timeLeft = timeLeft - Time.deltaTime;
                if (timeLeft <= 0f)
                {
                    timeLeft = 0f;
                    EndGame("Tijd om!");
                }
                UpdateTexts();
                break;

            case GameState.GameOver:
                if (restartAction != null && restartAction.WasPressedThisFrame())
                {
                    Restart();
                }
                break;
        }
    }

    // Wordt aangeroepen door Collector als de speler een obstakel raakt.
    public void LoseLife()
    {
        if (state != GameState.Playing) return;

        lives = lives - 1;
        UpdateTexts();
        if (lives <= 0)
        {
            EndGame("Game over");
        }
    }

    void EndGame(string message)
    {
        state = GameState.GameOver;

        // Alles stilzetten: Time.deltaTime wordt 0, dus niets beweegt of spawnt meer.
        Time.timeScale = 0f;

        if (gameOverSound != null && Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position);
        }

        if (messageText != null)
        {
            string score = scoreManager != null ? "\nScore: " + scoreManager.score : "";
            messageText.text = message + score + "\n\nDruk op spatie om opnieuw te spelen";
        }
    }

    void Restart()
    {
        // De scene opnieuw laden zet alles terug naar het begin.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateTexts()
    {
        if (livesText != null) livesText.text = "Levens: " + lives;
        if (timeText != null) timeText.text = "Tijd: " + Mathf.CeilToInt(timeLeft);
    }
}
