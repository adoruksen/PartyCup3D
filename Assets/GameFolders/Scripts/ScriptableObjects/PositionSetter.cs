using UnityEngine;

[CreateAssetMenu(fileName = "PositionSetter", menuName = "ScriptableObjects/PositionSystem/PositionSetter", order = 1)]
public class PositionSetter : ScriptableObject
{
    #region PlayerRegion
    [Header("Player")]
    [SerializeField] private Vector3 playerTargetPos;
    [SerializeField] private Vector3 playerMoneyPos;

    public Vector3 PlayerTargetPos => playerTargetPos;
    public Vector3 PlayerMoneyPos => playerMoneyPos;

    #endregion

    #region EnemyRegion
    [Header("Enemy")]
    [SerializeField] private Vector3 enemyTargetPos;
    [SerializeField] private Vector3 enemyMoneyPos;

    public Vector3 EnemyTargetPos => enemyTargetPos;



    public Vector3 EnemyMoneyPos => enemyMoneyPos;

    #endregion

    #region CameraRegion
    [Header("Camera 1")]
    [SerializeField] private Vector3 camera1Pos;
    [SerializeField] private Vector3 camera1Rot;

    public Vector3 Camera1Pos => camera1Pos;
    public Vector3 Camera1Rot => camera1Rot;


    [Header("Camera 2")]
    [SerializeField] private Vector3 camera2Pos;
    [SerializeField] private Vector3 camera2Rot;
    public Vector3 Camera2Pos => camera2Pos;
    public Vector3 Camera2Rot => camera2Rot;


    [Header("Camera 3")]
    [SerializeField] private Vector3 camera3Pos;
    [SerializeField] private Vector3 camera3Rot;

    public Vector3 Camera3Pos => camera3Pos;
    public Vector3 Camera3Rot => camera3Rot;


    [Header("Camera 4")]
    [SerializeField] private Vector3 camera4Pos;
    [SerializeField] private Vector3 camera4Rot;

    public Vector3 Camera4Pos => camera4Pos;
    public Vector3 Camera4Rot => camera4Rot;
    #endregion
}