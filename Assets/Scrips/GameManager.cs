using UnityEngine;

public class GameManager : MonoBehaviour

{

    [SerializeField] private GameObject menuScherm;
    [SerializeField] private GameObject spelScherm;
    [SerializeField] private GameObject eindeScherm;

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
        eindeScherm.SetActive(true);
        menuScherm.SetActive(false);
        spelScherm.SetActive(false);
        
        //alles staat still
        Time.timeScale = 0;
    }
}