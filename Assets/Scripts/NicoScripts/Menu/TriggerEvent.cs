using UnityEngine;
using UnityEngine.Events; // Necesario para usar UnityEvent
using System.Collections.Generic; // Para usar List

public class TriggerEvent : MonoBehaviour
{
    [Header("Eventos al entrar en el trigger")]
    public List<UnityEvent> eventos; // Lista de eventos que se activar�n al entrar en el trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que entr� en el trigger tiene un tag espec�fico, si es necesario
        if (other.CompareTag("Jugador")) // Cambia "Player" por el tag que necesites
        {
            ActivarEventos();
        }
    }

    // M�todo que activa todos los eventos en la lista
    private void ActivarEventos()
    {
        foreach (UnityEvent evento in eventos)
        {
            evento.Invoke(); // Invoca cada evento en la lista
        }
    }
}
