using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text element for score
    public Text winText;   // Reference to the UI Text element for the win message
    public GameObject wastedPanel; // Reference to the wasted panel
    private int currentScore = 0; // Track the current score

    private void Start()
    {
        // Hide winText and wastedPanel at the start
        if (winText != null)
        {
            winText.gameObject.SetActive(false); // Ensure winText is hidden at game start
        }

        if (wastedPanel != null)
        {
            wastedPanel.SetActive(false); // Ensure wasted panel is hidden at game start
        }

        UpdateScore(0); // Initialize score to 0
    }

    // Method to update the score on the UI
    public void UpdateScore(int newScore)
    {
        currentScore = newScore; // Update the current score
        scoreText.text = "Score: " + currentScore;

        // Check for win condition
        if (currentScore >= 100)
        {
            ShowWinMessage();
            StopGame(); // Stop the game when the player wins
        }
    }

    // Method to retrieve the current score
    public int GetCurrentScore()
    {
        return currentScore;
    }

    // Method to show the win message
    public void ShowWinMessage()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(true); // Show win message
        }
    }

    // Method to show the wasted panel
    public void ShowWastedPanel()
    {
        if (wastedPanel != null)
        {
            wastedPanel.SetActive(true); // Show the wasted panel
        }

        StopGame(); // Stop the game on death
    }

    // Method to pause the game
    public void StopGame()
    {
        Time.timeScale = 0; // Pause the game
    }
}
