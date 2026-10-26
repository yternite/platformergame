using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    [SerializeField] public GameObject menuScherm;
    [SerializeField] public GameObject spelScherm;
    [SerializeField] public GameObject deathScherm;
    [SerializeField] public GameObject winnerScherm;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
      // SceneManager.LoadScene("Scenes/Menu");
        ToonMenu();
    }

    public void ToonMenu()
    {
        menuScherm.SetActive(true);
        spelScherm.SetActive(false);
        deathScherm.SetActive(false);
        winnerScherm.SetActive(false);
        
        //staat still
        Time.timeScale = 0;
        
    }

    public void StartSpel()
    {
        menuScherm.SetActive(false);
        spelScherm.SetActive(true);
        deathScherm.SetActive(false);
        winnerScherm.SetActive(false);
       
       // SceneManager.LoadScene("Scenes/level1");
        
        //staat niet meer steel
        Time.timeScale = 1;
    }

    public void Doodgegeaan()
    { 
        menuScherm.SetActive(false);
        deathScherm.SetActive(true);
        spelScherm.SetActive(false);
        winnerScherm.SetActive(false);
        
        //alles staat still
        Time.timeScale = 0;
    }

    public void Winnerswin()
    {
        menuScherm.SetActive(false);
        spelScherm.SetActive(false);
        deathScherm.SetActive(false);
        winnerScherm.SetActive(true);
        
        Time.timeScale = 0;
    }

    public void OpnieuwBeginnen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void HelemaalBeginnen()
    {
        SceneManager.LoadScene("Scenes/Level1");
        Time.timeScale = 1;
    }
    
    
    
}