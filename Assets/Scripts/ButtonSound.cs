using UnityEngine;
using UnityEngine.UI; // Para manejar UI como botones

public class ButtonSound : MonoBehaviour
{
    public Button myButton; // Asignar el botón desde el inspector
    public AudioSource audioSource; // El AudioSource donde se reproducirá el sonido

    void Start()
    {
        // Asegúrate de que el AudioSource está asignado
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Buscar el AudioSource en el objeto si no está asignado
        }

        // Añadir el evento de escuchar al botón
        myButton.onClick.AddListener(PlaySound);
    }

    // Método para reproducir el sonido
    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Reproduce el sonido una única vez al hacer clic en el botón
        }
    }
}
