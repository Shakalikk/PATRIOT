
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IBulletDamagePlayer
{
    [Header("��������")]
    public float enemyHealth;
    [Header("����")]
    public int scoreAddition;
    [SerializeField] private PLayerScore _player;

    public void IBulletDamageEnemy(float damageBullet)
    {
        enemyHealth -= damageBullet;
        Alive();
    }

    public void Alive()// �������� �����
    {
        if (enemyHealth <= 0)
        {
            _player.GetComponent<PLayerScore>().IScore(scoreAddition);
            Destroy(gameObject);
        }
    }
}
