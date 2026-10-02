using UnityEngine;

public class GameManager : MonoBehaviour

{

    [SerializeField] public GameObject menuScherm;
    [SerializeField] public GameObject spelScherm;
    [SerializeField] public GameObject eindeScherm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ToonMenu();
    }

    public void ToonMenu()
    {
        menuScherm.SetActive(true);
        spelScherm.SetActive(false);
        eindeScherm.SetActive(false);
        
        //staat still
        Time.timeScale = 0;
        
    }

    public void StartSpel()
    {
        menuScherm.SetActive(false);
        spelScherm.SetActive(true);
        eindeScherm.SetActive(false);
        
        //staat niet meer steel
        Time.timeScale = 1;
    }

    public void BeeindigSpel()
    { 
        menuScherm.SetActive(false);
        eindeScherm.SetActive(true);
        spelScherm.SetActive(false);
        
        //alles staat still
        Time.timeScale = 0;
    }

    public void OpnieuwBeginnen()
    {
        Time.timeScale = 1;
    }
}