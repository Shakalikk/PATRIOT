
using System.Collections;
using UnityEngine;

public class BulletPlayerController : MonoBehaviour
{
    [Header("��������� ����")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float distance;
    [SerializeField] private float damage;
    [Header("�����")]
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
            transform.Translate(direction * bulletSpeed * Time.deltaTime); //����������� � �������� ����
            yield return null;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().IBulletDamageEnemy(damage); //�������� �� ������������. ���� true, �� ���������� ������.
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}

