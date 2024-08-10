using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerBaseStatsScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string playerName = "Jaata Ka Chhora";
    [SerializeField]
    private float playerBaseMaxHealth = 100f;
    [SerializeField]
    private float playerBaseAttack = 25f;
    [SerializeField]
    private float playerBaseBulletSpeed = 20f;
    [SerializeField]
    private float playerBaseDefence = 0f;
    [SerializeField]
    private float playerBaseMoveSpeed = 5.5f;
    [SerializeField]
    private float playerBaseJumpForce = 28f;
    [SerializeField]
    private float playerBaseFiringDelay = 0.25f;
    
    public string getPlayerName { get { return playerName; } }
    public float getPlayerBaseMaxHealth { get { return playerBaseMaxHealth; } }
    public float getPlayerBaseAttack { get { return playerBaseAttack; } }
    public float getPlayerBaseBulletSpeed { get { return playerBaseBulletSpeed; } }
    public float getPlayerBaseDefence { get { return playerBaseDefence; } }
    public float getPlayerBaseMoveSpeed { get { return playerBaseMoveSpeed; } }
    public float getPlayerBaseJumpForce { get {  return playerBaseJumpForce; } }
    public float getPlayerBaseFiringDelay { get { return playerBaseFiringDelay; } }
    

}
