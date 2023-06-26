using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OnPlayerLostLifeSignal(PlayerLifeLostSignal lostSignal)
    {
        if (lostSignal.IsOutOfLives)
        {
            SceneManager.LoadScene(0); //For the sake of the prototype. Please forgive me gods of coding.
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //For the sake of the prototype.
        }
    }
}


