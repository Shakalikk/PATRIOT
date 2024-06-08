using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyManager : MonoBehaviour
{
    [Header("Пуля")]
    [SerializeField] private GameObject bullets;
    [Header("Позиция пули")]
    [SerializeField] private Transform shootPosition;
    [Header("Задержка между выстрелами")]
    private float time;
    [SerializeField] private float startTimer = 0.8f;
    [Header("Триггер")]
    public float detectionDistance = 5f;
    [Header("Игрок")]
    public Transform _player;
    [Header("Враг")]
    public EnemyController _enemy;


    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Vector2.Distance(transform.position, _player.position) < detectionDistance)//Проверка вхождение игрока в поле триггера
        {
            if (time <= 0)//Перезарядка
            {
                GameObject bullet = Instantiate(bullets, shootPosition.transform.position, transform.rotation); // Спавн пули
                BulletEnemyController bulletEnemy = bullet.GetComponent<BulletEnemyController>();
                if (_enemy.facingRight)//Направление пули
                {
                    bulletEnemy.direction = Vector2.right;
                }
                else
                {
                    bulletEnemy.direction = Vector2.left;
                }
                time = startTimer;
                
            }
            else
            {
                time -= Time.deltaTime;
            }
        }

    }

    private void OnDrawGizmosSelected()//Отрисовка дистанции
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }
}
