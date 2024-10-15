using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxFlecha : MonoBehaviour
{

    public Animator anim;

    public int daño;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            if (collision.transform.GetComponent<Damagable>() != null)
                collision.transform.GetComponent<Damagable>().TakeDamage(daño);
                anim.Play("FlechaHit");
        }
        if(collision.CompareTag("Muro"))
        {
            anim.Play("FlechaHit");
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}

