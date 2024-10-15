using UnityEngine;

public class ObjetoPunto : MonoBehaviour
{
    public int valorPuntos = 10; // Valor en puntos del objeto

    public AudioSource audio;
    public Animator animator;

    // M�todo que se llama al colisionar con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.SumarObjetoPunto(); // Sumar puntos y aumentar contador de objetos puntos
            animator.Play("ObtenidoMoneda");
            audio.pitch = UnityEngine.Random.Range(1f, 1.5f);
            audio.Play();
        }
    }

    //Este se llama como AnimationEvent en la animación ObtenidoMoneda.
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
