using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour, Damagable
{
    public UnityEvent onHit, onDeath, onTimerEnd;
    public int hp;

    // void Awake()
    // {
    // pc = GetComponent<PlayerController>();
    // }
    
    public void TakeDamage(int daño)
    {
        hp -= daño;
        CheckHP();
    }

    void CheckHP()
    {
        if (hp < 0)
            OnDeath();

    }

    void OnHit()
    {   
        onHit.Invoke();
        // pc.isLocked = true;
    }

    void OnDeath()
    {
        StartCoroutine(Timer());
        onDeath.Invoke();
        Debug.Log("BANG you're dead!");
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds (1.0f);
        
        onTimerEnd.Invoke();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
