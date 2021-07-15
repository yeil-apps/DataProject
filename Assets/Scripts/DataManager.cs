using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private string _bestPlayerName;
    public string BestPlayerName
    {
        get { return _bestPlayerName; }
    }

    private int _bestScore;
    public int BestScore
    {
        get { return _bestScore; }
    }

    private string _currentPlayerName;


    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestResult();
    }


    public void ChangePlayerName(string newName)
    {
        DataManager.Instance._currentPlayerName = newName;
    }

    public void CheckAndChangeBestScore(int newScore)
    {
        if (newScore > _bestScore)
        {
            _bestScore = newScore;
            _bestPlayerName = _currentPlayerName;
            SaveBestResult();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayer;
        public int BestScore;
    }

    public void SaveBestResult()
    {
        SaveData data = new SaveData();
        data.BestPlayer = _currentPlayerName;
        data.BestScore = _bestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestResult()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            _bestScore = data.BestScore;
            _bestPlayerName = data.BestPlayer;
        }
    }
}
