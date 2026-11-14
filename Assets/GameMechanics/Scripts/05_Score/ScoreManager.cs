using TMPro;
using UnityEngine;

// Les 5: Score
// Houdt de score bij en laat die zien in een tekst op het scherm.
// Andere scripts (zoals Collector) roepen AddPoints aan.
public class ScoreManager : MonoBehaviour
{
    // De tekst in de UI (Canvas) waarin de score staat.
    public TMP_Text scoreText;

    public int score = 0;

    void Start()
    {
        UpdateText();
    }

    // 'public', zodat andere scripts deze methode kunnen aanroepen.
    public void AddPoints(int points)
    {
        score = score + points;
        UpdateText();
    }

    void UpdateText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
