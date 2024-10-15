using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SpikeTrap : MonoBehaviour
{
    public Transform spike; // El objeto que se va a mover (ej. los pinchos)
    public Vector3 targetOffset = new Vector3(1, 0, 0); // Desplazamiento de la posici�n (ej. X +1)
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float returnDelay = 2f; // Tiempo que tarda en regresar a su posici�n original
    public float startDelay = 0.5f; // Delay antes de iniciar el movimiento

    public UnityEvent OnMove;
    private Vector3 initialPosition; // Posici�n original del objeto
    private bool isMoving = false;

    void Start()
    {
        // Guardamos la posici�n inicial del objeto
        initialPosition = spike.position;
    }

    // Detecta cuando el jugador entra en el trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador") && !isMoving)
        {
            // Inicia el movimiento despu�s del delay
            StartCoroutine(MoveSpike());
        }
    }

    // Corrutina para manejar el movimiento del objeto
    IEnumerator MoveSpike()
    {
        
        isMoving = true;

        // Esperar el delay inicial antes de mover
        yield return new WaitForSeconds(startDelay);

        // Calcular la nueva posici�n del spike
        Vector3 targetPosition = initialPosition + targetOffset;

        // Mover el spike a la nueva posici�n
        yield return StartCoroutine(MoveToPosition(targetPosition));

        // Esperar un tiempo antes de regresar a la posici�n original
        yield return new WaitForSeconds(returnDelay);

        // Mover de regreso a la posici�n original
        yield return StartCoroutine(MoveToPosition(initialPosition));

        isMoving = false;
    }

    // M�todo para mover el objeto a una posici�n espec�fica
    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(spike.position, targetPosition) > 0.01f)
        {
            spike.position = Vector3.MoveTowards(spike.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        spike.position = targetPosition; // Asegura que llegue exactamente a la posici�n destino
        OnMove.Invoke();
    }
}
