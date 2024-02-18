using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
public class PlayFabManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform canvas;
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Login()
    {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request,OnSuccess,OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Suuccess");
    }
    
    public void UpdateLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                 StatisticName = "VSquareLeaderBoard",
                 Value = score

                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Upated");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    }
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "VSquareLeaderBoard",
            StartPosition = 0,
            MaxResultsCount = 15
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(var item in result.Leaderboard) Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        int y = 200;
        foreach(var item in result.Leaderboard)
        {
             y -= 95;
             GameObject Rank = new GameObject("Rank " + item.Position.ToString());
            GameObject ID = new GameObject("ID " + item.PlayFabId.ToString());
            GameObject Score = new GameObject("Score" + item.StatValue.ToString());
              Rank.transform.SetParent(canvas);
            ID.transform.SetParent(canvas);
            Score.transform.SetParent(canvas);
 
             TextMeshProUGUI RankText = Rank.AddComponent<TextMeshProUGUI>();
             int R = item.Position + 1;
             RankText.text = R.ToString();
              TextMeshProUGUI IDText = ID.AddComponent<TextMeshProUGUI>();
              IDText.text = item.PlayFabId.ToString();
              TextMeshProUGUI ScoreText = Score.AddComponent<TextMeshProUGUI>();
              ScoreText.text = item.StatValue.ToString();

             RectTransform RankRect = Rank.GetComponent<RectTransform>();
             RankRect.anchoredPosition = new Vector2(-401, y);
             RectTransform IDRect = ID.GetComponent<RectTransform>();
             IDRect.anchoredPosition = new Vector2(-17, y);
             RectTransform ScoreRect = Score.GetComponent<RectTransform>();
             ScoreRect.anchoredPosition = new Vector2(393, y);

            
        }
    }
}
