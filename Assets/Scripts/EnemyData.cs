using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "ScriptableObjects/EnemyData", order = 0)]
public class EnemyData : ScriptableObject
{
    public float MinX = -15, MaxX = 15;
    public float MoveSpeed = 5;
    public float ShootCooldown;
    public Projectile projectile;
    public ParticleSystem DamageParticle;
}