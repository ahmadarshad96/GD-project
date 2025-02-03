using UnityEngine;

public class playerCollision : MonoBehaviour
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
            if (uiManager != null)
            {
                uiManager.ShowWastedPanel(); // Show the death panel
            }
        }
    }
}
