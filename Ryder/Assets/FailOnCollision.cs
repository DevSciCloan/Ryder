using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FailOnCollision : MonoBehaviour
{
    private Collider2D failCollider;
    public UnityEvent onFail;
    [SerializeField] GameObject failScreen;

    void Awake()
    {
        failCollider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Track")
        {
            onFail?.Invoke();
            
        }
    }

    public void CoroutineFailScreenActivate()
    {
        StartCoroutine(FailScreenSetActive());
    }

    IEnumerator FailScreenSetActive()
    {
        yield return new WaitForSeconds(1.2f);
        failScreen.SetActive(true);
    }
}
