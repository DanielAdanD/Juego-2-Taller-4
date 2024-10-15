using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public float tiempoAntesDeTransicion = 2f;
    private GameManager gameManager;

    void Start()
    {
        // En lugar de buscar cada vez, almacenamos la referencia a GameManager al iniciar
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GuardarYCambiarEscena(string sceneName)
    {
        gameManager.MarcarNivelCompletado();
        GuardarDatosNivelActual();
        StartCoroutine(CambiarEscenaConRetraso(sceneName));
    }

    public void CambioDeEscena(string sceneName)
    {
        StartCoroutine(CambiarEscenaConRetraso(sceneName));
    }

    public void ReiniciarEscena()
    {
        StartCoroutine(CambiarEscenaConRetraso(SceneManager.GetActiveScene().name));
    }

    private IEnumerator CambiarEscenaConRetraso(string sceneName)
    {
        yield return new WaitForSeconds(tiempoAntesDeTransicion);
        SceneManager.LoadScene(sceneName);
    }

    private void GuardarDatosNivelActual()
    {
        string nombreNivel = SceneManager.GetActiveScene().name;
        DataCollectorManager.Instance.GuardarDatosNivel(
            nombreNivel, gameManager.puntos, gameManager.gemas,
            gameManager.objetosPuntos, gameManager.completado // Asegurarse de guardar el estado completado
        );
    }


    public void PausarJuego()
    {
        Time.timeScale = 0f;
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f;
    }
}
