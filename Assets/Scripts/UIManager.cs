using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{    
    
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private TextMeshProUGUI _inGamePanelScore;
    [SerializeField] private TextMeshProUGUI _GameOverPanelScore;
    private bool _isGameOver=false;

   
    private void Start()
    {
        _inGamePanelScore.text="0";

       
            InvokeRepeating("InvokeScore", 1f, .2f);
        
        
    }

    public void OnGameDone()
    {
        _gameOverPanel.SetActive(true);
        _isGameOver = true;
    }

    public void PressedRestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);       
    }

    private void Update()
    {
        if (_isGameOver)
        {
            _GameOverPanelScore.text = _inGamePanelScore.text;
            CancelInvoke("InvokeScore");
            
            _inGamePanel.SetActive(false);
            
           
        }
    }


    public void InvokeScore()
    {

        _inGamePanelScore.text = (int.Parse(_inGamePanelScore.text) + 1).ToString();
    }


   


}


