using System.Reflection.Metadata.Ecma335;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text bestTimeText = null;

    [SerializeField] private TMP_Text gameTimeText = null;
    private float currentGameTime = 0.0f;

    private bool isFinished = false;



    private static GameManager instance = null;

    public static GameManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }


    private void Start()
    {
        SaveManager.Instance.Load();
        GameData data = SaveManager.Instance.GetGameData();
        bestTimeText.text = data.FastestTime.ToString("F2");
        gameTimeText.text = currentGameTime.ToString("F2");
    }

    public void StartGame()
    {
        currentGameTime = 0.0f;
        isFinished = false;
    }

    public void EndGame()
    {
        isFinished = true;
        GameData data = SaveManager.Instance.GetGameData();
        if (data.FastestTime > currentGameTime)
        {
            data.FastestTime = currentGameTime;
        }
        bestTimeText.text = data.FastestTime.ToString("F2");
        gameTimeText.text = currentGameTime.ToString("F2");


        data.TopFiveTimes.Add(currentGameTime);
        data.TopFiveTimes.Sort();
        while (data.TopFiveTimes.Count > 5)
        {
            data.TopFiveTimes.RemoveAt(data.TopFiveTimes.Count - 1);
        }
        SaveManager.Instance.SetGameData(data);
        SaveManager.Instance.Save();
    }




    private void Update()
    {
        if (!isFinished)
        { 
            currentGameTime += Time.deltaTime;
            gameTimeText.text = currentGameTime.ToString("F2");
        }
    }

}
