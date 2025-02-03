using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;


public class MainMEnu : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
   public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
