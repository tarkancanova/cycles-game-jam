using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
  
    



    public void OnPressedStart()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void OnPressedQuit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }



}
