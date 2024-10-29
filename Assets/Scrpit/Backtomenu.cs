// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Backtomenu : MonoBehaviour
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

public class MenuButton : MonoBehaviour
{
    // Fonction à lier au bouton pour charger la scène du menu principal
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("SampleScene"); // Remplace "MainMenu" par le nom exact de ta scène
    }
}
