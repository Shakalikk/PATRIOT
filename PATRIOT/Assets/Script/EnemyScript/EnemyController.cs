using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Скорсоть врага")]
    [SerializeField] private float enemySpeed;
    [Header("Позиция игрока")]
    [SerializeField] private Transform player;
    public bool facingRight = false;
    [Header("Триггер")]
    [SerializeField] private float distancePlayer;

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < distancePlayer) //Дистанция вхождения игрока
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);//Пеередвжиение врага
        }

        if (!facingRight && player.transform.position.x > transform.position.x)
        {
            Flip();
        }
        else if (facingRight && player.transform.position.x < transform.position.x)
        {
            Flip();
        }

    }

    private void Flip()//Перевороот врага
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distancePlayer);
    }

}
