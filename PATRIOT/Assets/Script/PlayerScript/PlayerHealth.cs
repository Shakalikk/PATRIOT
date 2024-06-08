using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : AudionController, IBulletDamageEnemy, ICapsuleTrapDamage, IBulletDamageScrollEnemy, IHealthPoint
{
    public float playerHealth;
    [Header("���� ���������")]
    [SerializeField] private GameObject failImage;
    [SerializeField] private TMP_Text hpText;
    [Header("������")]
    [SerializeField] private AudioSource levelMusic;
    public void IBulletDamageEnemy(float damageBullet)
    {
        playerHealth -= damageBullet;
    }
    public void ICapsuleTrapDamage(float damageTrap)
    {
        playerHealth -= damageTrap;
    }

    public void IBulletDamageScrollEnemy(float damageBullet)
    {
        playerHealth -= damageBullet;
    }

    public void IHealthPoint(float healthPoint)
    {
        PlaySounds(sounds[0], p1: 1);
        playerHealth += healthPoint;
    }


private void Update()
    {
        hpText.text = playerHealth.ToString();
        Alive();
    }

    public void Alive()
    {
        if (playerHealth <= 0) //�������� �� ������. ���� false, �� ������ ������� � ������ ������, ���� true, �� ��������� ������ � ����� ���� ���������.
        {
            Cursor.visible = true;
            levelMusic.Pause();
            gameObject.SetActive(false);
            failImage.SetActive(true);
        }
        else
        {
            gameObject.SetActive(true);
            failImage.SetActive(false);
        }
    }

    private void Start()
    {
        hpText.text = playerHealth.ToString();
    }
}

    
