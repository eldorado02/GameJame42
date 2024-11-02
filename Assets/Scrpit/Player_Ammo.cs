using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public  int ammo = 0;
    public Slider AmmoSlider;
    public int maxAmmo = 5;
    private int currentAmmo;

    void Start()
    {
        currentAmmo = maxAmmo;
        AmmoSlider.maxValue = maxAmmo;
        AmmoSlider.value = ammo;
    }
    // Update is called once per frame
    void Update()
    {
        AmmoSlider.value = ammo;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kollectible"))
        {
            ammo++;
            if (ammo > maxAmmo)
                ammo = 5;
        }
        if (collision.gameObject.CompareTag("fantome"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
