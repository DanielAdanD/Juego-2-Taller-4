using UnityEngine;

public class ObjetoGema : MonoBehaviour
{
    public int valorGemas = 1; // Valor en gemas del objeto

    public AudioSource audio;
    public Animator animator;

    // M�todo que se llama al colisionar con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.SumarGemas(valorGemas); // Sumar gemas y puntos
            animator.Play("Obtenido");
            audio.Play();
            
        }
    }
    
    //Este se llama como AnimationEvent en la animación Obtenido.
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
