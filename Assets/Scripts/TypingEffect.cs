using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Importar el espacio de nombres para gestionar escenas

public class TypingEffect : MonoBehaviour
{
    public TMP_Text textMeshPro; // Referencia al componente TextMeshPro
    public float typingSpeed = 0.1f; // Velocidad de escritura en segundos por letra
    public string fullText; // Texto completo que se va a mostrar
    private string currentText = ""; // Texto que se muestra actualmente
    public int initialSceneIndex; // Índice de la escena inicial a cargar

    private void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TMP_Text>(); // Obtener el componente si no se asignó desde el inspector
        }

        fullText = textMeshPro.text; // Guardar el texto completo
        textMeshPro.text = ""; // Limpiar el texto al inicio
    }

    // Método para activar el efecto de escritura
    public void StartTyping()
    {
        StopAllCoroutines(); // Detener cualquier escritura anterior
        StartCoroutine(TypeText()); // Iniciar la corrutina de escritura
    }

    // Corrutina para escribir el texto letra por letra
    private IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            currentText += letter; // Agregar la letra actual al texto mostrado
            textMeshPro.text = currentText; // Actualizar el texto en pantalla
            yield return new WaitForSeconds(typingSpeed); // Esperar un tiempo determinado
        }

        // Esperar un momento antes de cambiar de escena (opcional)
        yield return new WaitForSeconds(3f); // Ajusta el tiempo si lo deseas

        // Cambiar a la escena inicial
        SceneManager.LoadScene(initialSceneIndex);
    }
}
