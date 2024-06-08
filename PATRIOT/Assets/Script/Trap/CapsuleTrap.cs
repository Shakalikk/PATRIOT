using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTrap : MonoBehaviour
{
    [Header("Точки")]
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [Header("Скорость")]
    [SerializeField] private float trapSpeed;
    private bool movingToTarget1 = true;
    [Header("Игрок")]
    [SerializeField] private PlayerHealth _player;
    [Header("Урон")]
    [SerializeField] private float damage;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("damage");
            _player.GetComponent<PlayerHealth>().ICapsuleTrapDamage(damage); //Находим скрипт ХП у игрока и отнимаем заданное кол-во ХП
        }
    }

    IEnumerator MoveTrap()
    {
        while (true)
        {
            if (movingToTarget1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target1.position, trapSpeed * Time.deltaTime); //Пермещение к 1 точке
                if (Vector2.Distance(transform.position, target1.position) < 0.01f)
                {
                    movingToTarget1 = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target2.position, trapSpeed * Time.deltaTime); //Пермещение к 2 точке
                if (Vector2.Distance(transform.position, target2.position) < 0.01f)
                {
                    movingToTarget1 = true;
                }
            }
            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(MoveTrap());
    }
}
