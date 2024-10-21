using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 startPos; // Posición inicial de la pieza
    private bool isDragging = false;
    public GameObject targetPosition; // Objeto cuyo posición se usará como objetivo
    public float snapDistance = 0.5f; // Distancia mínima para ajustar la pieza en su lugar
    public bool isPlaced = false; // Indica si la pieza está en su posición correcta
    public AudioSource correct; // Sonido al colocar la pieza correctamente
    public AudioSource incorrect; // Sonido al colocar la pieza incorrectamente


    void OnMouseDown()
    {
        // Guarda la posición inicial de la pieza antes de ser arrastrada
        startPos = transform.position;
        isDragging = true;
        Debug.Log("Pieza arrastrada: " + gameObject.name);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Captura la posición del mouse
            Vector3 mousePos = Input.mousePosition;

            // Convierte la posición del mouse de pantalla a mundo 2D
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // Actualiza la posición de la pieza (Z en 0 para que no se mueva en el eje Z)
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Comprueba si se ha asignado un objeto objetivo
        if (targetPosition != null)
        {
            // Distancia entre la pieza y el objeto objetivo
            float distance = Vector3.Distance(transform.position, targetPosition.transform.position);
            Debug.Log("Distancia a objetivo: " + distance);

            // Ajusta la pieza a la posición del objeto objetivo si está dentro del rango
            if (distance <= snapDistance)
            {
                transform.position = targetPosition.transform.position;
                isPlaced = true; // La pieza se ha colocado correctamente
                OnPiecePlaced(); // Llama al método cuando la pieza se coloca correctamente
                Debug.Log("Pieza colocada en la posición de: " + targetPosition.name);

                PlaySound(correct); // Reproduce el sonido al colocar la pieza correctamente
            }
            else
            {
                // Si no está dentro del rango, vuelve a su posición original
                transform.position = startPos;
                Debug.Log("Pieza devuelta a la posición inicial: " + startPos);

                PlaySound(incorrect); // Reproduce el sonido al colocar la pieza incorrectamente
            }
        }
        else
        {
            // Si no se ha asignado un objeto objetivo, vuelve a su posición original
            transform.position = startPos;
            Debug.Log("Pieza devuelta a la posición inicial: " + startPos);
        }
    }

    // Método que se ejecuta cuando la pieza se coloca en la posición correcta
    private void OnPiecePlaced()
    {
        Debug.Log(gameObject.name + " ha sido colocada correctamente.");
        // Aquí puedes añadir más lógica, como activar animaciones, sonidos, etc.
    }

    void PlaySound(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Reproduce el sonido una única vez al hacer clic en el botón
        }
    }
}
