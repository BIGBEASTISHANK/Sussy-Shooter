using UnityEngine;
using UnityEngine.SceneManagement;

public class levelComplete : MonoBehaviour
{
    [SerializeField] private float totalEnemy;
    [SerializeField] private GameObject killEnemies;
    [HideInInspector] public float killedEnemy;

    private void Start()
    {
        killEnemies.SetActive(false);
    }

    private void Update()
    {
        if (killedEnemy == totalEnemy)
        {
            killEnemies.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (killedEnemy == totalEnemy)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            killEnemies.SetActive(true);
        }
    }
}