using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{

    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;

    public bool isDie = false;
    void Update()
    {
        hunger.ChangeBar(hunger.passiveValue*Time.deltaTime);
        stamina.ChangeBar(stamina.passiveValue*Time.deltaTime);

        if(hunger.curValue == 0f)
        {
            health.ChangeBar(-noHungerHealthDecay*Time.deltaTime);
        }

        if(health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amout)
    {
        health.ChangeBar(amout);
    }

    public void Eat(float amout)
    {
        hunger.ChangeBar(amout);
    }

    public void Die()
    {
        if (!isDie)
        {
            Debug.Log("¡Í±›");
            isDie = true;
        }
    }

    public void TakePhysicalDamage(int damage)
    {
        health.ChangeBar(-damage);
        onTakeDamage?.Invoke();
    }
}
