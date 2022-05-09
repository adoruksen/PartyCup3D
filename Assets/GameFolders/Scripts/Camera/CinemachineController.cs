using System;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CinemachineController : MonoBehaviour
{
    [Header("Cinemachine Things")]
    private CinemachineComposer composer;
    private CinemachineTransposer transposer;
    private CinemachineVirtualCamera vCam;
    [NonSerialized] public float vCamFov;

    [Header("Others")]
    [SerializeField] private PositionSetter posSetter;

    [SerializeField] private GameObject basketTarget;


    private void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        vCamFov = vCam.m_Lens.FieldOfView;
        transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
        composer = vCam.GetCinemachineComponent<CinemachineComposer>();
        transposer.m_FollowOffset = posSetter.Camera1Pos;
        composer.m_TrackedObjectOffset = posSetter.Camera1Rot;
    }

    public void ChangeCamPosInTime(Vector3 target, float duration, bool isAddition = true)
    {
        var pos = isAddition ? transposer.m_FollowOffset + target : target;
        DOTween.To(() => transposer.m_FollowOffset, x => transposer.m_FollowOffset = x, pos, duration);
    }

    public void ChangeCamRotInTime(Vector3 target, float duration, bool isAddition = true)
    {
        var rot = isAddition ? composer.m_TrackedObjectOffset + target : target;
        DOTween.To(() => composer.m_TrackedObjectOffset, x => composer.m_TrackedObjectOffset = x, rot, duration);
    }

    public void FinishScene()
    {
        vCam.m_LookAt = basketTarget.transform;
        vCam.m_Follow = basketTarget.transform;


    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    ChangeCamPosInTime(posSetter.Camera2Pos, 2f, false);
        //    ChangeCamRotInTime(posSetter.Camera2Rot, 2f, false);
        //}
        //else if (Input.GetKeyUp(KeyCode.A))
        //{
        //    ChangeCamPosInTime(posSetter.Camera1Pos, 2f, false);
        //    ChangeCamRotInTime(posSetter.Camera1Rot, 2f, false);
        //}
    }

    #region Singleton Pattern

    public static CinemachineController instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
}