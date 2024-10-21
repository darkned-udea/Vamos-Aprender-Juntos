using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject mainPanel;     // Panel principal del menú
    public GameObject creditsPanel;  // Panel de créditos
    public float creditsDuration = 5f; // Duración en segundos para mostrar los créditos

    // Método para cambiar de escena usando el índice de la escena
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Método para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    // Método para mostrar los créditos con una corrutina
    public void ShowCredits()
    {
        StartCoroutine(ShowCreditsCoroutine());
    }

    // Corrutina que muestra los créditos durante un tiempo determinado
    private IEnumerator ShowCreditsCoroutine()
    {
        // Desactivar el panel principal y activar el panel de créditos
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);

        // Esperar la duración establecida
        yield return new WaitForSeconds(creditsDuration);

        // Activar el panel principal y desactivar el panel de créditos
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}
