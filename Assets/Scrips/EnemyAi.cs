using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

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
    public List<Transform> patrouillePunten;
    public float huidigePunt = 0;
    public float afstandTotPunt;
    private float zichtAfstand = 10;
    private float aanvalAfstand = 2;
    public float afstand;
    private float aanvalCooldown = 1.5f;
    public float tijdTotVolgendeAanval = 0;
    public Vector3 kijkRichting;
    public Animation animator;

    
        
        
        
    void Start()
    {
        //haalt mesh op
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animation>();
    }

    void Update()
    {
        afstand = Vector3.Distance(player.position, transform.position);
        // Global transitions: gelden vanuit elke state

        if (afstand < aanvalAfstand)
        {
            ZetState(VijandState.Aanvallen);
        }else if (afstand < zichtAfstand)
        {
            ZetState(VijandState.Achtervolgen);
        }else{
            ZetState(VijandState.Patrouilleren);
        }
        
        // En dan doen wat bij de huidige state hoort
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

        //animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void Patrouilleren()
    //loopt langs plekken)
    {
        agent.isStopped = true;
        agent.SetDestination(patrouillePunten[0].position);
        
        //waar ik ben ongeveer?
        //afstand tussen mijn positie en het punt
        afstandTotPunt = Vector3.Distance(transform.position, patrouillePunten[0].position);
        if (afstandTotPunt < 1.5)
        {
            huidigePunt = +1;
            if (huidigePunt == patrouillePunten.Count)
            {
                huidigePunt = 0;
            }
        }

    }

    public void Achtervolgen()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    public void Aanvallen()
    {
        //blijft staan tijdens het aanvallen
        agent.isStopped = true;
        // Kijk naar de speler, maar blijf rechtop
        kijkRichting = player.position - transform.position;
        kijkRichting.y = 0;
        //draai naar kijkRichting
        transform.rotation = Quaternion.LookRotation(kijkRichting);
        
        tijdTotVolgendeAanval = tijdTotVolgendeAanval - Time.deltaTime;

        if (tijdTotVolgendeAanval <= 0)
        {
            Debug.Log("aanval");
            tijdTotVolgendeAanval = aanvalCooldown;
        }
        
    }

    public void ZetState(VijandState nieuweState)
    {
        if (nieuweState == huidigeState)
        {
            huidigeState = nieuweState;
        }
    }
}
