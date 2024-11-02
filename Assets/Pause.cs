using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Assigné dans l'inspecteur, c’est ton Canvas de pause.
    private bool isPaused = false;

    void Update()
    {
        // Vérifie si la touche Esc est pressée et si le joueur est en mode jeu
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Pause")
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        pauseMenuCanvas.SetActive(true); // Affiche le Canvas de pause
        Time.timeScale = 0f; // Met le temps en pause
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false); // Cache le Canvas de pause
        Time.timeScale = 1f; // Reprend le temps normal
        isPaused = false;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f; // Assure que le temps est rétabli avant de quitter
        SceneManager.LoadScene("SampleScene"); // Remplace "MainMenu" par le nom de ta scène du menu principal
    }
}
