using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public  int ammo = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kollectible"))
        {
            ammo++;
        }
        if (collision.gameObject.CompareTag("fantome"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
