using UnityEngine;
using TMPro;

public class ColorChanger : MonoBehaviour
{
    public TMP_Text textMeshPro; // Referencia al componente TextMeshPro
    public Color[] colors; // Array de colores para cambiar
    public float duration = 1f; // Duración del cambio de color

    private int currentColorIndex = 0; // Índice del color actual
    private Color targetColor; // Color objetivo al que interpolar
    private float lerpTime = 0f; // Tiempo que ha pasado en la interpolación

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TMP_Text>(); // Obtener el componente si no se asignó desde el inspector
        }

        if (colors.Length > 0)
        {
            textMeshPro.color = colors[currentColorIndex]; // Establecer el color inicial
            targetColor = colors[currentColorIndex]; // Establecer el color objetivo inicial
        }
    }

    void Update()
    {
        if (colors.Length > 0)
        {
            // Interpolar el color actual hacia el color objetivo
            lerpTime += Time.deltaTime / duration; // Aumentar el tiempo de interpolación
            textMeshPro.color = Color.Lerp(textMeshPro.color, targetColor, lerpTime); // Cambiar el color gradualmente

            // Comprobar si se ha alcanzado el color objetivo
            if (lerpTime >= 1f)
            {
                lerpTime = 0f; // Reiniciar el tiempo de interpolación
                currentColorIndex = (currentColorIndex + 1) % colors.Length; // Cambiar al siguiente color
                targetColor = colors[currentColorIndex]; // Establecer el nuevo color objetivo
            }
        }
    }
}
