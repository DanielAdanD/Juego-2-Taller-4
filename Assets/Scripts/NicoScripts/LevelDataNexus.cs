using UnityEngine;
using TMPro;

public class LevelDataNexus : MonoBehaviour
{
    public static LevelDataNexus Instance; // Singleton para fácil acceso
    public LevelDataDisplay[] levelDataDisplays; // Lista de LevelDataDisplays en la escena
    public TMP_Text textoPuntosPerfect; // TMP_Text para mostrar los puntos perfect
    public int PuntosPerfect = 0; // Contador de niveles perfect

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ActualizarDatosNiveles();
        ActualizarPuntosPerfect();
    }

    void ActualizarDatosNiveles()
    {
        foreach (var display in levelDataDisplays)
        {
            if (display != null)
            {
                display.ActualizarDatos(); // Actualiza los datos del display si coinciden los nombres
            }
        }
    }

    public void RegistrarPerfect()
    {
        PuntosPerfect++; // Aumentar el contador de perfects
        ActualizarPuntosPerfect(); // Actualizar el texto
    }

    void ActualizarPuntosPerfect()
    {
        if (textoPuntosPerfect != null)
        {
            textoPuntosPerfect.text = $":{PuntosPerfect}";
        }
    }
}
