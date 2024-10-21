using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // El panel del menú de pausa
    public GameObject instructionsPanel; // Panel de instrucciones que aparece al inicio
    private bool isPaused = false; // Para verificar si el juego está pausado
    private bool isInstructionsActive = false; // Para verificar si el panel de instrucciones está activo

    // Lista para almacenar los objetos a los que se les desactivará el BoxCollider2D
    public List<GameObject> objectsToDisable; // Asigna los objetos desde el inspector
    public AudioSource audioSource; // El AudioSource donde se reproducirá el sonido

    void Start()
    {
        // Mostrar las instrucciones al inicio si el panel está asignado
        if (instructionsPanel != null)
        {
            ShowInstructions();
        }
    }

    void Update()
    {
        // Verificar si se presiona la tecla "Escape" para pausar/despausar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlaySound(); // Reproducir el sonido al pausar/despausar

            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        // Verificar si se presiona la tecla "I" para abrir/cerrar el panel de instrucciones
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlaySound(); // Reproducir el sonido al abrir/cerrar las instrucciones

            if (isInstructionsActive)
            {
                HideInstructions(); // Ocultar el panel de instrucciones
            }
            else
            {
                ShowInstructions(); // Mostrar el panel de instrucciones
            }
        }
    }

    // Método para reanudar el juego
    public void Resume()
    {

        EnableColliders(); // Activar los colliders
        pauseMenuUI.SetActive(false); // Desactivar el panel de pausa
        Time.timeScale = 1f;          // Restablecer el tiempo normal del juego
        isPaused = false;
    }

    // Método para pausar el juego
    void Pause()
    {
        DisableColliders(); // Desactivar los colliders
        pauseMenuUI.SetActive(true);  // Activar el panel de pausa
        instructionsPanel.SetActive(false); // Ocultar el panel de instrucciones
        Time.timeScale = 0f;          // Congelar el tiempo del juego
        isPaused = true;
    }

    // Método para reiniciar el nivel actual
    public void RestartLevel()
    {
        Time.timeScale = 1f;          // Restablecer el tiempo normal del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recargar la escena actual
    }

    // Método para volver al menú principal
    public void LoadMainMenu(int menuSceneIndex)
    {
        Time.timeScale = 1f;          // Restablecer el tiempo normal del juego
        SceneManager.LoadScene(menuSceneIndex); // Cargar la escena del menú principal
    }

    // Método para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    // Método para desactivar los BoxCollider2D de los objetos
    private void DisableColliders()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.enabled = false; // Desactivar el collider
            }
        }
    }

    // Método para activar los BoxCollider2D de los objetos
    private void EnableColliders()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.enabled = true; // Activar el collider
            }
        }
    }

    // Método para mostrar el panel de instrucciones al inicio
    public void ShowInstructions()
    {
        DisableColliders(); // Desactivar los colliders
        instructionsPanel.SetActive(true);
        pauseMenuUI.SetActive(false); // Ocultar el panel de pausa
        Time.timeScale = 0f; // Detener el juego mientras las instrucciones están activas
        isInstructionsActive = true;
    }

    // Método para ocultar el panel de instrucciones y reanudar el juego
    public void HideInstructions()
    {
        EnableColliders(); // Activar los colliders
        instructionsPanel.SetActive(false); // Ocultar el panel de instrucciones
        Time.timeScale = 1f;                // Reanudar el juego
        isInstructionsActive = false;
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Reproduce el sonido una única vez al hacer clic en el botón
        }
    }
}
