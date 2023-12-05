using Unity.VisualScripting;
using UnityEngine;

public class ParticleManager
{
    public static void SpawnParticle(ParticleSystem particle, Vector3 pos, Transform parent, float size = 1f)
    {
        var p = Object.Instantiate(particle, pos, Quaternion.identity, parent);
        p.AddComponent<ParticleAutoDestroyer>();
        p.transform.localScale *= size;
    }

    public static void SpawnParticle(ParticleSystem particle, Vector3 pos, float size = 1f)
    {
        SpawnParticle(particle, pos, null, size);
    }
}