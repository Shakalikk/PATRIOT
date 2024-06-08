using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    [Header("Парамтеры пули")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float distance;
    [SerializeField] private float damage;
    
    public Vector2 direction;

    private void Start()
    {
        StartCoroutine(MoveBullet());
    }

    

    IEnumerator MoveBullet()
    {
        while (true)
        {
           transform.Translate(direction * bulletSpeed * Time.deltaTime);  //Направление и скорость пули
            yield return null;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().IBulletDamageEnemy(damage); //Проверка на столкновение. Если true, то уничтожаем объект.
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
