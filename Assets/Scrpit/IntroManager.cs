// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class IntroManager : MonoBehaviour
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

public class IntroManager : MonoBehaviour
{
    public float displayTime = 3.0f; // Temps d'affichage en secondes
    public string nextSceneName; // Nom de la scène suivante

    private void Start()
    {
        // Commence la transition après le délai spécifié
        Invoke("LoadNextScene", displayTime);
    }

    private void LoadNextScene()
    {
        // Charge la scène suivante
        SceneManager.LoadScene(nextSceneName);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Ou une autre touche de ton choix
        {
            LoadNextScene();
        }
    }

}
