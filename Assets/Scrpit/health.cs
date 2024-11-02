using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currentHealth;
    public Transform respawnPoint;  // Point de réapparition après la mort
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        // Ajoute ici des effets de mort (animation, sons, etc.)
        Debug.Log("Le joueur est mort !");
        // Respawn du joueur ou affichage d'un écran de Game Over
        Respawn();
    }

    void Respawn()
    {
        // Remet la santé au maximum
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        isDead = false;
        
        // Réinitialise la position du joueur au point de réapparition
        transform.position = respawnPoint.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si le joueur entre en collision avec un monstre
        if (collision.gameObject.CompareTag("fantome"))
        {
            TakeDamage(25); // Ajuste les dégâts selon les besoins
        }
    }
}
