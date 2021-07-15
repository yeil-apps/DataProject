using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField] private Text NewPlayerNameOnScene;
    [SerializeField] private Text BestPlayerText;
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null)
        {
            string playerName = DataManager.Instance.BestPlayerName;
            int bestScore = DataManager.Instance.BestScore;
            BestPlayerText.text = "Best Score : " + playerName + " : " + bestScore;
        }
    }
    
    public void StartNewGame()
    {
        if (NewPlayerNameOnScene.text != null)
            DataManager.Instance.ChangePlayerName(NewPlayerNameOnScene.text);
        else
            DataManager.Instance.ChangePlayerName("Unknown Player");

        SceneManager.LoadScene(1);
    }

}
