using UnityEngine;

[CreateAssetMenu(fileName = "Player Info", menuName = "Scriptable Object/Player Info")]
public class PlayerSo : ScriptableObject
{
    public int playerHp;// 플레이어의 HP정보 
    public int playerStage;
}
