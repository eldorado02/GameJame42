using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Fonction appelée lors du clic sur le bouton Exit
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Pour tester dans l'éditeur Unity
        #else
            Application.Quit(); // Pour quitter le jeu après le build
        #endif
    }
}
