using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    // Referencia al objeto del men� de muerte
    public GameObject deathMenu;

    public AudioSource audio;

    // Referencia al objeto del jugador
    public GameObject player;

    private void Start()
    {
        // Aseg�rate de que el men� de muerte est� desactivado al inicio
        if (deathMenu != null)
        {
            deathMenu.SetActive(false);
        }
    }

    private void Update()
    {
        // Verifica si el jugador est� desactivado
        if (player != null && !player.activeInHierarchy)
        {
            ActivateDeathMenu();
        }
    }
    private void ActivateDeathMenu()
    {
        // Activa el men� de muerte
        if (deathMenu != null)
        {
            deathMenu.SetActive(true);
        }
    }
}
