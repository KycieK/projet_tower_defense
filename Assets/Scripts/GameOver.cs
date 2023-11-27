using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI wavesText;

    void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex); //load la scene actuelle pour éviter de la perdre si on change l'index ou le nom
    }

    public void Menu()
    {
        Debug.Log("Go to menu.");
    }
}
