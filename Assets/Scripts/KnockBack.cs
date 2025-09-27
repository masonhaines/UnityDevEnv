using System;
using System.Collections;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float knockBackTime = 0.5f;
    private Rigidbody2D knockBackRigidbody2D;
    public bool bKnockedBack = false;

    private void Awake()
    {
        knockBackRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void CreateKnockBack(Transform damageSource, float knockBackAmount, float knockBackLiftAmount)
    {
        //---------------------// Victim of attack //
        Vector2 difference = (transform.position - damageSource.position).normalized;
        bKnockedBack = true;
        difference.y = knockBackLiftAmount;
        knockBackRigidbody2D.AddForce(difference * knockBackAmount * knockBackRigidbody2D.mass, ForceMode2D.Impulse);
    }

    private IEnumerator KnockBackCoroutine()
    {
        yield return new WaitForSeconds(knockBackTime);
        bKnockedBack = false;
    }
}
