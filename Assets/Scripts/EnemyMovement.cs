using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public float updateSpeed = 0.1f;
    private NavMeshAgent agent;
    private GameObject playerObj = null;
    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowTarget());
    }
    private IEnumerator FollowTarget(){
        WaitForSeconds wait = new WaitForSeconds(updateSpeed);
        while (enabled){
            agent.SetDestination(playerObj.transform.position);
            yield return wait;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
