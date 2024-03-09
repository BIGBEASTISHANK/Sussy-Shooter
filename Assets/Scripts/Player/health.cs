using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class health : MonoBehaviour
{
    [SerializeField] private float playerHealth;
    [SerializeField] private TMPro.TMP_Text healthText;
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.maxValue = playerHealth;
        slider.value = playerHealth;
        healthText.text = playerHealth.ToString();
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        healthText.text = playerHealth.ToString();
        slider.value = playerHealth;

        if (playerHealth <= 0) SceneManager.LoadScene("Scenes/Level 1");
    }
}