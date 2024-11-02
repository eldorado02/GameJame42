// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class textanimate : MonoBehaviour
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
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text uiText;
    public float typeSpeed = 0.05f;

    private string fullText;

    void Start()
    {
        fullText = uiText.text;
        StartCoroutine(RepeatTypeText());
    }

    IEnumerator RepeatTypeText()
    {
        while (true) // Boucle infinie
        {
            uiText.text = ""; // Vide le texte à chaque début de boucle
            for (int i = 0; i < fullText.Length; i++)
            {
                uiText.text += fullText[i];
                yield return new WaitForSeconds(typeSpeed);
            }
            yield return new WaitForSeconds(2); // Pause entre les boucles
        }
    }
}


