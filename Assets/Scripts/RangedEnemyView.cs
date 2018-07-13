using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyView : EnemyView
{
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private GameObject throwingPos;
    [SerializeField] private GameObject explosionPrefab;

    /// <summary>
    /// calling at the end of anim
    /// </summary>
    public void ThrowGrenade()
    {
        StartCoroutine(ThrowingGrenade());
    }

    private IEnumerator ThrowingGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwingPos.transform);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(1f, 1f) * 5;
        yield return new WaitForSeconds(0.6f);
        GameObject explosion = Instantiate(explosionPrefab, throwingPos.transform);
        explosion.transform.position = grenade.transform.position;
        yield return null;
        
        Destroy(grenade);
    }
}
