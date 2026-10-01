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
    public int huidigePunt = 0;
    private float afstandTotPunt;
    private float zichtAfstand = 10;
    private float aanvalAfstand = 5;
    private float afstand;
    private float aanvalCooldown = 1.5f;
    public float tijdTotVolgendeAanval = 0;
    private Vector3 kijkRichting;
    public Animator animator;
   

    
        
        
    void Start()
    {
        //haalt mesh op
        agent = GetComponent<NavMeshAgent>();
        
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

        animator.SetFloat("Speed", agent.velocity.magnitude);
       // animator.SetBool("Attacking", Attacking);
        animator.SetBool("Attacking", huidigeState == VijandState.Aanvallen);
    }

    private void Patrouilleren()
    //loopt langs plekken)
    {
        //agent.isStopped = true;
        agent.SetDestination(patrouillePunten[huidigePunt].position);
        
        //waar ik ben ongeveer?
        //afstand tussen mijn positie en het punt
        afstandTotPunt = Vector3.Distance(transform.position, patrouillePunten[huidigePunt].position);
        if (afstandTotPunt < 1f)
        {
            huidigePunt += 1;
            if (huidigePunt == patrouillePunten.Count)
            {
                huidigePunt = 0;
            }
        }

    }

    private void Achtervolgen()
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

    private void ZetState(VijandState nieuweState)
    {
        if (nieuweState != huidigeState)
        {
            huidigeState = nieuweState;
        }
    }
}
