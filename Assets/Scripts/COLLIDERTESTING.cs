using UnityEngine;
using UnityEngine.UIElements;
[ExecuteInEditMode]
public class COLLIDERTESTING : MonoBehaviour
{
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, ~0, QueryTriggerInteraction.Collide);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("Hit");
        }
    }
}