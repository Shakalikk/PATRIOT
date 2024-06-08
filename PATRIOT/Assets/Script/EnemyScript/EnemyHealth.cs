
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IBulletDamagePlayer
{
    [Header("Здоровье")]
    public float enemyHealth;
    [Header("Очки")]
    public int scoreAddition;
    [SerializeField] private PLayerScore _player;

    public void IBulletDamageEnemy(float damageBullet)
    {
        enemyHealth -= damageBullet;
        Alive();
    }

    public void Alive()// здоровье врага
    {
        if (enemyHealth <= 0)
        {
            _player.GetComponent<PLayerScore>().IScore(scoreAddition);
            Destroy(gameObject);
        }
    }
}
