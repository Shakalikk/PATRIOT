using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrollEnemyController : MonoBehaviour
{
    [Header("��������� ����")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;

    IEnumerator MoveBullet()
    {
        while (true)
        {
            transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime); //����������� � �������� ����
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().IBulletDamageScrollEnemy(damage); //�������� �� ������������. ���� true, �� ���������� ������.
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
