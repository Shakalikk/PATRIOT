using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrollEnemyController : MonoBehaviour
{
    [Header("Парамтеры пули")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;

    IEnumerator MoveBullet()
    {
        while (true)
        {
            transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime); //Направление и скорость пули
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().IBulletDamageScrollEnemy(damage); //Проверка на столкновение. Если true, то уничтожаем объект.
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(MoveBullet());
    }

}
