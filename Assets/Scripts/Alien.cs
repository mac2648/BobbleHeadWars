using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Alien : MonoBehaviour
{
    public Transform target;
    public float navigationUpdate;
    private float navigationTime = 0;

    public UnityEvent OnDestroy;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navigationTime += Time.deltaTime;
        if (navigationTime > navigationUpdate && target)
        {
            agent.destination = target.position;
            navigationTime = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
        Die();
    }

    public void Die()
    {
        OnDestroy.Invoke();
        OnDestroy.RemoveAllListeners();
        Destroy(gameObject);
    }
}
