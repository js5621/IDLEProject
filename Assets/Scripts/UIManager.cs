using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerSo playerSoData;
    public Text playerHP;
    public Text GameStage;
    public Text MissionText;
    public SpawnSO spawnSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        GameStage.text = $"STAGE {playerSoData.playerStage}";
        MissionText.text = $"ALIEN : {spawnSO.SpawnMonsterCount}";
        Debug.Log(spawnSO.SpawnMonsterCount);
        printPlayerHp(playerSoData.playerHp);
        if(playerSoData.playerHp < 4 )
        {
            playerHP.color = Color.red; 
        }
    }

    void printPlayerHp(int hp)
    {
        
        playerHP.text = "";
        for (int i = 0; i < hp; i++)
        {
            
            playerHP.text += "|";
           
        }
    }
}
