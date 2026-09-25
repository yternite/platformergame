using UnityEngine;
using UnityEngine.AI;

public enum VijandState
{
    Patrouilleren,
    Achtervolgen,
    Aanvallen
}

public class EnemyAi : MonoBehaviour
{
    public VijandState huidigeState = VijandState.Patrouilleren;
    public NavMeshAgent agent;
    public Transform player;
    
        
        
        
    void Start()
    {
        //haalt mesh op
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        switch (huidigeState)
        {
            case VijandState.Patrouilleren:
                Patrouilleren();
                break;
            
            case VijandState.Achtervolgen:
                Achtervolgen();
                break;
            
            case VijandState.Aanvallen:
                Aanvallen();
                break;
                
        }
    }

    public void Patrouilleren()
    {
        
    }

    public void Achtervolgen()
    {
        
    }

    public void Aanvallen()
    {
        
    }

    public void ZetState(VijandState nieuweState)
    {
        if (nieuweState == huidigeState)
        {
            huidigeState = nieuweState;
        }
    }
}
