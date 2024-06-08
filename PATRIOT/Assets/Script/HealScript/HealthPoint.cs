
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField] private float heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().IHealthPoint(heal); //���� ����� ���������� � �������� + ��
            Destroy(gameObject);
        }
    }
}
