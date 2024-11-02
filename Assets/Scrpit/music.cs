using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource introMusic;
    public AudioSource menuMusic;

    void Start()
    {
        introMusic.Play(); // Pour démarrer l’intro
    }

    public void SwitchToMenuMusic()
    {
        introMusic.Stop();
        menuMusic.Play(); // Pour lancer la musique du menu
    }
}
