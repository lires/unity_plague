using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeLeft = 45f;
    public TMP_Text timerText;
    public int score = 0;
    public int targetScore = 10;
    private bool isGameOver = false;
    private Vector3 originalScale;
    private float pulseSpeed = 4f;
    private float pulseAmount = 0.15f;
    public TMP_Text scoreText;
    public int maxScore = 10;

    void Start()
    {
        if (timerText != null)
            originalScale = timerText.transform.localScale;

        UpdateScoreDisplay();
    }

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(0, timeLeft);

        UpdateTimerDisplay();
        AnimatePulse();

        if (timeLeft <= 0)
        {
            EndGameCheck();
        }
    }

    void AnimatePulse()
    {
        if (timerText != null)
        {
            float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
            timerText.transform.localScale = originalScale * scale;
        }
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeLeft);
        timerText.text = seconds + "s";
    }

    void EndGameCheck()
    {
        isGameOver = true;

        if (score < targetScore)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    public void AddScore(int value)
    {
        if (isGameOver) return;

        score += value;
        score = Mathf.Clamp(score, 0, maxScore);
        UpdateScoreDisplay();

        if (score >= targetScore)
        {
            isGameOver = true;
            SceneManager.LoadScene("WinScene");
        }
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = score + "/" + maxScore;
        }
    }
}
