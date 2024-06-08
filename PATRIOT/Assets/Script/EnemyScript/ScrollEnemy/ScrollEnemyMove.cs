using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollEnemyMove : MonoBehaviour
{
    [Header("Точки")]
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [Header("Скорость")]
    [SerializeField] private float scrollEnemySpeed;
    private bool movingToTarget1 = true;
    [Header("Игрок")]
    [SerializeField] private PlayerHealth _player;

    IEnumerator MoveEnemy()
    {
        while (true)
        {
            if (movingToTarget1)//Движение к точке 1
            {
                transform.position = Vector2.MoveTowards(transform.position, target1.position, scrollEnemySpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, target1.position) < 0.01f)
                {
                    movingToTarget1 = false;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target2.position, scrollEnemySpeed * Time.deltaTime);//Движение к точке 2
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
        StartCoroutine(MoveEnemy());
    }
}
