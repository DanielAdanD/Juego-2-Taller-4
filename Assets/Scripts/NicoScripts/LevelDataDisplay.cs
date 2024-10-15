using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LevelDataDisplay : MonoBehaviour
{
    [Header("Referencias a TextMeshPro")]
    public TMP_Text textoGemas;
    public TMP_Text textoPuntos;
    public TMP_Text textoObjetosPuntos;

    [Header("Configuración Manual")]
    public string nombreNivel; // Nombre del nivel asignado en el inspector
    public int totalGemasManual; // Valor manual de gemas totales en el nivel
    public int totalObjetosPuntoManual; // Valor manual de objetos puntos totales en el nivel

    [Header("Objetos que se activarán/destruirán")]
    public List<GameObject> objetosAEliminar; // Lista de objetos a eliminar
    public List<GameObject> objetosAActivar; // Lista de objetos a activar
    public List<GameObject> objetosPerfectActivar; // Lista de objetos que se activarán si se logra un perfect

    [Header("Estado del nivel")]
    public bool completado = false;
    public bool perfect = false; // Nueva variable para el estado "perfect"
    private bool perfectRegistrado = false; // Nueva variable para evitar registrar múltiples veces

    private void Start()
    {
        // Inicializar los TMP_Text con valores por defecto
        textoGemas.text = $": 0/{totalGemasManual}";
        textoObjetosPuntos.text = $": 0/{totalObjetosPuntoManual}";
        textoPuntos.text = $"Score: 0";

        ActualizarDatos(); // Llamar al iniciar
    }

    public void ActualizarDatos()
    {
        // Obtener datos del nivel específico desde el DataCollectorManager
        var datos = DataCollectorManager.Instance.ObtenerDatosNivel(nombreNivel);

        // Verificar si el nivel tiene datos guardados
        if (datos != null)
        {
            // Mostrar los datos actuales de gemas y objetos en la UI
            if (textoGemas != null) textoGemas.text = $": {datos.gemas}/{totalGemasManual}";
            if (textoObjetosPuntos != null) textoObjetosPuntos.text = $": {datos.objetosPuntos}/{totalObjetosPuntoManual}";
            if (textoPuntos != null) textoPuntos.text = $"Score: {datos.puntos}";

            // Actualizar estado completado basado en los datos
            completado = datos.completado;

            // Verificar si el nivel está completado y activar/desactivar objetos
            if (completado)
            {
                foreach (var obj in objetosAEliminar)
                {
                    obj.SetActive(false); // Eliminar cada objeto en la lista solo si completado es true
                }

                foreach (var obj in objetosAActivar)
                {
                    obj.SetActive(true); // Activar cada objeto en la lista solo si completado es true
                }
            }

            // Verificar si se cumple la condición de "perfect"
            if (!perfectRegistrado && datos.gemas >= totalGemasManual && datos.objetosPuntos >= totalObjetosPuntoManual)
            {
                perfect = true;
                perfectRegistrado = true; // Asegurarse de que solo se registre una vez

                // Activar todos los objetos asociados al "perfect"
                foreach (var obj in objetosPerfectActivar)
                {
                    obj.SetActive(true); // Activar cada objeto en la lista si se logra el perfect
                }

                LevelDataNexus.Instance.RegistrarPerfect(); // Informar al LevelDataNexus (asumo que tienes este método en LevelDataNexus)
            }
        }
    }
}
