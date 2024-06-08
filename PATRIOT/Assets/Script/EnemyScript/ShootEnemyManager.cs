using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyManager : MonoBehaviour
{
    [Header("����")]
    [SerializeField] private GameObject bullets;
    [Header("������� ����")]
    [SerializeField] private Transform shootPosition;
    [Header("�������� ����� ����������")]
    private float time;
    [SerializeField] private float startTimer = 0.8f;
    [Header("�������")]
    public float detectionDistance = 5f;
    [Header("�����")]
    public Transform _player;
    [Header("����")]
    public EnemyController _enemy;


    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Vector2.Distance(transform.position, _player.position) < detectionDistance)//�������� ��������� ������ � ���� ��������
        {
            if (time <= 0)//�����������
            {
                GameObject bullet = Instantiate(bullets, shootPosition.transform.position, transform.rotation); // ����� ����
                BulletEnemyController bulletEnemy = bullet.GetComponent<BulletEnemyController>();
                if (_enemy.facingRight)//����������� ����
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

    private void OnDrawGizmosSelected()//��������� ���������
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }
}
