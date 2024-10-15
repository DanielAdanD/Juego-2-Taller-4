using UnityEngine;

public class DesactivarObjetosPorPuntos : MonoBehaviour
{
    [System.Serializable]
    public class ObjetoDesactivable
    {
        public GameObject objeto;    // El objeto que quieres desactivar
        public int puntosNecesarios; // Puntos perfectos necesarios para desactivar este objeto
    }

    public ObjetoDesactivable[] objetosDesactivables; // Lista de objetos que pueden ser desactivados

    void Update()
    {
        // Obtenemos los puntos perfectos desde el LevelDataNexus
        int puntosPerfect = LevelDataNexus.Instance.PuntosPerfect;

        // Recorremos la lista de objetos y los desactivamos si se cumplen los puntos necesarios
        foreach (var objetoDesactivable in objetosDesactivables)
        {
            if (objetoDesactivable.objeto != null && puntosPerfect >= objetoDesactivable.puntosNecesarios)
            {
                objetoDesactivable.objeto.SetActive(false); // Desactiva el objeto
            }
        }
    }
}
