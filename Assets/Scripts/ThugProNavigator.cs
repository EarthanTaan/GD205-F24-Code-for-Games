using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class ThugProNavigator : MonoBehaviour
{
    NavMeshAgent BossAgent;

    public Transform target;

    void Start()
    {
        BossAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Ray targetSelectRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit whereClick = new RaycastHit();


        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(targetSelectRay, out whereClick))
            {
                BossAgent.SetDestination(whereClick.point);
            }
            
        }

        
    }
}
