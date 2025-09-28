using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class RanlkUIManager : MonoBehaviour
{
    public GameObject rankDataPrefab;
    public Transform rankPanal;

    public List<PlayerData> playerDatas = new List<PlayerData>();
    public List<GameObject> createdPlayerDatas = new List<GameObject>();

    void Start()
    {
        CreatreRankData();
    }
    public void CreatreRankData()
    {
        for (int i = 0; i < playerDatas.Count; i++)
        {
            GameObject rankObj = Instantiate(rankDataPrefab, rankPanal);
            RankData rankData = rankObj.GetComponent<RankData>();

            rankData.playerData = new PlayerData
                (
                playerDatas[i].rankNumber,
                playerDatas[i].playerName,
                playerDatas[i].playerScore,
                playerDatas[i].profileImage

                );

            rankData.UpdateData();
            createdPlayerDatas.Add(rankObj);
        }
    }

    private void SortRankData()
    {
        List<PlayerData> sortRankPlayer = new List<PlayerData>();
        sortRankPlayer = playerDatas.OrderByDescending(data => data.playerScore).ToList();

        for (int i = 0; i < sortRankPlayer.Count; i++)
        {
            PlayerData changedRankNumber = sortRankPlayer[i];
            changedRankNumber.rankNumber = i + 1;

            sortRankPlayer[i] = changedRankNumber;
        }
        playerDatas = sortRankPlayer;
    }
    private void ClearRankData()
    {
        foreach (GameObject createdData in createdPlayerDatas)
        {
            Destroy(createdData);
        }

        createdPlayerDatas.Clear();
    }

    [ContextMenu("Reload")]
    public void ReloadRankData()
    {
        ClearRankData();
        SortRankData();
        CreatreRankData();
    }
}
