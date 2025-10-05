using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int rankNumber;
    public int playerScore;
    public Texture profileImage;

    public PlayerData(int rankNumber, string playerName, int playerScore, Texture profileImage)
    {
        this.rankNumber = rankNumber;
        this.playerName = playerName;
        this.playerScore = playerScore;
        this.profileImage = profileImage;
    }
}
public class RankData : MonoBehaviour
{
    public PlayerData playerData;
    [Space]
    [SerializeField] private TMP_Text rankText;
    [SerializeField] private RawImage profileImg;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text scoreText;

    public void UpdateData()
    {
        rankText.text = playerData.rankNumber.ToString();
        profileImg.texture = playerData.profileImage;
        playerNameText.text = playerData.playerName;
        scoreText.text = playerData.playerScore.ToString("0");
    }
}
