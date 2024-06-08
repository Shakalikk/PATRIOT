
using System.Collections;
using UnityEngine;

public class BulletPlayerController : MonoBehaviour
{
    [Header("Парамтеры пули")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float distance;
    [SerializeField] private float damage;
    [Header("Игрок")]
    public PlayerController _player;
    private Vector2 direction;

    private void Start()
    {
        direction = _player.isFacingRight ? Vector2.right : Vector2.left;
        StartCoroutine(MoveBullet());
    }
    IEnumerator MoveBullet()
    {
        while (true)
        {
            transform.Translate(direction * bulletSpeed * Time.deltaTime); //Направление и скорость пули
            yield return null;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().IBulletDamageEnemy(damage); //Проверка на столкновение. Если true, то уничтожаем объект.
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}

