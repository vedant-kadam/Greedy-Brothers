
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public GameObject MyPlayer;
    public int targetAquiredCount = 0;
    public int TotalTarget = 10;
    public TextMeshProUGUI CollectedGodNo,AMmoCount;
    Player IfoPlayer;
    public Slider ShieldBar,TankBar,BalsterBar;
    public int Maxtarget = 10;
    public GameObject WinPannel;
    public GameObject deathPannel;

   
    private void Awake()
    {
        IfoPlayer = FindObjectOfType<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        CollectedGodNo.text = targetAquiredCount.ToString();
        ShieldBar.maxValue = IfoPlayer.ShieldHealth;
        TankBar.maxValue = IfoPlayer.BackHealthh;
        BalsterBar.maxValue = IfoPlayer.LauncherHealth;
        AMmoCount.text = "10";
        //  FindObjectOfType<AudioManager>().StopPlayingAll();
        FindObjectOfType<AudioManager>().StopPlaying();
        FindObjectOfType<AudioManager>().PlayMe("Mains");
        WinPannel.SetActive(false);
        deathPannel.SetActive(false);

    }

    // Update is called once per frame
    bool targetReacher = false;
    void Update()
    {
        setShieldBarValue(IfoPlayer.TshieldHealth);
        setLauncherBarValue(IfoPlayer.ALauncgerHealth);
        setTankBarValue(IfoPlayer.TbackHealth);
        AMmoCount.text = IfoPlayer.shootCount.ToString();
        if(targetAquiredCount ==  Maxtarget)
        {
            //game Won 
            Time.timeScale = 0f;
            
           if(!targetReacher)
            {
               //Time.timeScale = 0f;
                MyPlayer.SetActive(false);
                FindObjectOfType<AudioManager>().StopPlaying();
                FindObjectOfType<AudioManager>().PlayMe("win");
                FindObjectOfType<AudioManager>().PlayMe("Mains");
                WinPannel.SetActive(true);
                targetReacher = true;
            }
           
            // 
            

        }

        
    }
    public void targetAquireq()
    {
        targetAquiredCount++;
        FindObjectOfType<AudioManager>().PlayMe("gold");
        CollectedGodNo.text = targetAquiredCount.ToString();
    }

    public void setShieldBarValue(float infoVal)//float valueToSet)
    {
        ShieldBar.value = infoVal;
    }

    public void setTankBarValue(float infoVal)
    {
        TankBar.value = infoVal;
    }
    public void setLauncherBarValue(float infoVal)
    {
        BalsterBar.value = infoVal;
    }
    public void GoHome()
    {
        //open a pannel
        FindObjectOfType<AudioManager>().PlayMe("select");
        SceneManager.LoadScene(0);
       // FindObjectOfType<AudioManager>().StopPlaying();
    }

    public void playerDeathRituals()
    {
        deathPannel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestrtGame()
    {
        FindObjectOfType<AudioManager>().PlayMe("select");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void homeBaxk()
    {
        SceneManager.LoadScene(0);
    }

}
