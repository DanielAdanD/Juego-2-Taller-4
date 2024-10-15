using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Contadores del Jugador")]
    public int puntos;
    public int gemas;
    public int objetosPuntos;
    public bool completado; // Nueva variable para indicar si el nivel est� completado

    [Header("Configuraci�n de Puntos")]
    public int puntosPorGema = 100;
    public int puntosPorObjetoPunto = 10;

    [Header("UI TextMeshPro")]
    public TMP_Text textoPuntos;
    public TMP_Text textoGemas;
    public TMP_Text textoPuntosTotales;

    [Header("Contador de Objetos en la Escena")]
    public int totalGemasEnEscena;
    public int totalObjetosPunto;

    [Header("Men� de Victoria")]
    public TMP_Text victoriaPuntos;
    public TMP_Text victoriaGemas;
    public TMP_Text victoriaObjetosPuntos;

    private DataCollectorManager dataCollectorManager;

    void Start()
    {
        puntos = gemas = objetosPuntos = 0;
        completado = false; // Inicializar completado como falso
        dataCollectorManager = DataCollectorManager.Instance;
        ContabilizarGemasEnEscena();
        ContabilizarPuntosEnEscena();
        ActualizarUI();
    }

    public void NivelCompletado()
    {
        completado = true; // Nivel completado
        // L�gica para activar/desactivar objetos
        GameObject.Find("ObjetoAEliminar").SetActive(false); // Ejemplo de objeto que se destruye
        GameObject.Find("ObjetoAActivar").SetActive(true); // Ejemplo de objeto que se activa
        GuardarDatos();
    }

    // M�todo para sumar puntos al jugador
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    // M�todo para sumar gemas al jugador, tambi�n suma puntos
    public void SumarGemas(int cantidad)
    {
        gemas += cantidad;
        SumarPuntos(cantidad * puntosPorGema); // Sumar puntos correspondientes a las gemas recogidas
        ActualizarUI();
    }

    public void MarcarNivelCompletado()
    {
        completado = true; // Marcar el nivel como completado
        GuardarDatos(); // Guardar el estado completado en el DataCollectorManager
    }

    // M�todo para sumar un objeto punto al jugador
    public void SumarObjetoPunto()
    {
        objetosPuntos++;
        SumarPuntos(puntosPorObjetoPunto); // Sumar puntos correspondientes al objeto punto
        ActualizarUI();
    }

    // M�todo para contar gemas en la escena
    void ContabilizarGemasEnEscena()
    {
        totalGemasEnEscena = FindObjectsOfType<ObjetoGema>().Length;
    }

    // M�todo para contar objetos puntos en la escena
    void ContabilizarPuntosEnEscena()
    {
        // Buscar todos los objetos con el tag "Puntos"
        GameObject[] objetosConTag = GameObject.FindGameObjectsWithTag("Puntos");
        totalObjetosPunto = 0;

        // Filtrar los que tienen el componente ObjetoPunto
        foreach (GameObject obj in objetosConTag)
        {
            if (obj.GetComponent<ObjetoPunto>() != null)
            {
                totalObjetosPunto++;
            }
        }
    }

    // M�todo para actualizar la UI con los valores actuales
    void ActualizarUI()
    {
        if (textoPuntos != null) textoPuntos.text = $"Score: {puntos}";
        if (textoGemas != null) textoGemas.text = $": {gemas}/{totalGemasEnEscena}";
        if (textoPuntosTotales != null) textoPuntosTotales.text = $": {objetosPuntos}/{totalObjetosPunto}";

        // Actualiza tambi�n los textos del men� de victoria
        if (victoriaPuntos != null) victoriaPuntos.text = $"Score: {puntos}";
        if (victoriaGemas != null) victoriaGemas.text = $": {gemas}/{totalGemasEnEscena}";
        if (victoriaObjetosPuntos != null) victoriaObjetosPuntos.text = $": {objetosPuntos}/{totalObjetosPunto}";
    }

    // M�todo para guardar los datos en DataCollectorManager
    void GuardarDatos()
    {
        dataCollectorManager.GuardarDatosNivel(
            SceneManager.GetActiveScene().name, puntos, gemas, objetosPuntos, completado
        );
    }
}
