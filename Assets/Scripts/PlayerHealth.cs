using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public SimpleHealthBar healthBar;
    public int maxHp = 100;
    public int lives = 1;
    private int currentHp;

    // Use this for initialization
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void DealDmg(float v)
    {
        currentHp -= (int)v;
        if (currentHp < 0)
        {
            ResetLife();
        }
        healthBar.UpdateBar(currentHp, maxHp);
    }

    internal void ResetLife()
    {
        lives--;
        currentHp = maxHp;
        healthBar.UpdateBar(currentHp, maxHp);
    }

    public void OneUp()
    {
        currentHp = maxHp;
        healthBar.UpdateBar(currentHp, maxHp);
        print(lives);
    }
}
