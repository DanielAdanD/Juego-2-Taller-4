using UnityEngine;
using System.Collections.Generic;

public class DataCollectorManager : MonoBehaviour
{
    public static DataCollectorManager Instance;

    [System.Serializable]
    public class DatosNivel
    {
        public string nombreNivel;
        public int puntos;
        public int gemas;
        public int objetosPuntos;
        public bool completado; // Campo para el estado de completado del nivel
    }

    // Diccionario para almacenar los datos de varios niveles
    public Dictionary<string, DatosNivel> nivelesDatos = new Dictionary<string, DatosNivel>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Asegura que este objeto persista entre escenas
        }
        else
        {
            Destroy(gameObject); // Destruye cualquier instancia duplicada
        }
    }

    // Guardar los datos de un nivel
    public void GuardarDatosNivel(string nombreNivel, int puntos, int gemas, int objetosPuntos, bool completado)
    {
        if (nivelesDatos.ContainsKey(nombreNivel))
        {
            // Si el nivel ya existe, actualizamos los datos
            nivelesDatos[nombreNivel].puntos = puntos;
            nivelesDatos[nombreNivel].gemas = gemas;
            nivelesDatos[nombreNivel].objetosPuntos = objetosPuntos;
            nivelesDatos[nombreNivel].completado = completado;
        }
        else
        {
            // Si no existe, lo añadimos al diccionario
            DatosNivel nuevoNivel = new DatosNivel
            {
                nombreNivel = nombreNivel,
                puntos = puntos,
                gemas = gemas,
                objetosPuntos = objetosPuntos,
                completado = completado
            };
            nivelesDatos.Add(nombreNivel, nuevoNivel);
        }
    }

    // Obtener los datos de un nivel por su nombre
    public DatosNivel ObtenerDatosNivel(string nombreNivel)
    {
        if (nivelesDatos.ContainsKey(nombreNivel))
        {
            return nivelesDatos[nombreNivel];
        }
        else
        {
            return null; // Retorna null si no hay datos del nivel
        }
    }
}
