
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUi : MonoBehaviour
{

    public GameObject guide0, guide1, guide2, guide,Me;
    private void Start()
    {
        guide.SetActive(false);
        FindObjectOfType<AudioManager>().StopPlaying();
        FindObjectOfType<AudioManager>().PlayMe("home");
    }
  public   void OnPLayClick()
    {
        FindObjectOfType<AudioManager>().PlayMe("select");

        SceneManager.LoadScene(1);
    }

   public  void OnGuideClick()
    {
        FindObjectOfType<AudioManager>().PlayMe("select");
        //OpenTheGuideWindow
        guide.SetActive(true);
        guide0.SetActive(true);
        guide1.SetActive(true);
        guide2.SetActive(false);
    }
  public   void OnGuideNectClick1()
    {
        FindObjectOfType<AudioManager>().PlayMe("select");
        guide0.SetActive(false);
        guide1.SetActive(false);
        guide2.SetActive(true);
    }
    public void OnGuideNectClick2()
    {
        FindObjectOfType<AudioManager>().PlayMe("select");
        guide0.SetActive(true);
        guide1.SetActive(true);
        guide2.SetActive(false);
    }
    public void GoHomeBack()
    {
        FindObjectOfType<AudioManager>().PlayMe("select");
        guide.SetActive(false);
    }

    public void uitIt()
    {
        Application.Quit();
    }

    public void me()
    {
        FindObjectOfType<AudioManager>().PlayMe("select");
        Me.SetActive(true);
        guide.SetActive(false);
            
    }
    public void backfromMe()
    {
        FindObjectOfType<AudioManager>().PlayMe("select");
        Me.SetActive(false);
    }
}
