using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public DragAndDrop[] pieces; // Array para almacenar todas las piezas
    public GameObject congratulationsPanel; // Panel de felicitaciones
    public TypingEffect typingEffect; // Referencia al script de efecto de escritura
    private bool allPiecesPlacedExecuted = false; // Variable para verificar si ya se ha ejecutado la acción
    public AudioSource audioSource; // El AudioSource donde se reproducirá el sonido

    void Update()
    {
        // Comprobar si todas las piezas están colocadas
        if (AllPiecesPlaced() && !allPiecesPlacedExecuted)
        {
            allPiecesPlacedExecuted = true; // Marcar que la acción se ha ejecutado
            Debug.Log("¡Todas las piezas están en su lugar!");

            PlaySound(); // Reproducir el sonido al completar el rompecabezas

            congratulationsPanel.SetActive(true); // Activar el panel de felicitaciones

            typingEffect.StartTyping(); // Iniciar el efecto de escritura
        }
    }

    // Método para verificar si todas las piezas están colocadas
    private bool AllPiecesPlaced()
    {
        foreach (DragAndDrop piece in pieces)
        {
            if (!piece.isPlaced) // Si alguna pieza no está colocada, retorna false
            {
                return false;
            }
        }
        return true; // Si todas las piezas están colocadas, retorna true
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Reproduce el sonido una única vez al hacer clic en el botón
        }
    }
}
