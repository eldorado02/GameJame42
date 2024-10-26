// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MenuManager : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Fonction pour le bouton "Play"
    public void PlayGame()
    {
        // Charge la scène du jeu (remplace "GameScene" par le nom de ta scène de jeu)
        SceneManager.LoadScene("GameScene");
    }

    // Fonction pour le bouton "Exit"
    public void ExitGame()
    {
        // Quitte le jeu (cela fonctionne uniquement dans l'application buildée)
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
}
