using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private UIManager uiManager; // Reference to the UIManager

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointObject")) // Check for PointObject tag
        {
            Debug.Log("Bullet hit the PointObject!");

            // Update score in the UIManager
            if (uiManager != null)
            {
                uiManager.UpdateScore(uiManager.GetCurrentScore() + 10); // Increment score by 10
            }

            Destroy(other.gameObject); // Destroy the PointObject
            Destroy(gameObject);       // Destroy the bullet
        }
    }
}
