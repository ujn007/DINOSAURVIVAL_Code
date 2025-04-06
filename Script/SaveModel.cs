using BehaviorDesigner.Runtime.Tasks.Unity.UnityNavMeshAgent;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
#if UNITY_EDITOR
using UnityEditor.VersionControl;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class SaveModel : MonoSingleton<SaveModel>
{
    GameObject playerGroup;
    DinoControll[] dinos;
    int currentNum;

    private PlayableDirector playAbleDirector;
    private SignalReceiver signal;

    [SerializeField]
    private CinemachineVirtualCamera[] vCams;
    [SerializeField]
    private CinemachineVirtualCamera[] vCams2;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "1.SuccessScene" ||
            SceneManager.GetActiveScene().name == "2.FailScene")
        {
            playAbleDirector = FindObjectOfType<PlayableDirector>();
            signal = playAbleDirector.GetComponent<SignalReceiver>();
            playerGroup = GameObject.Find("PlayerGroup");
            currentNum = 1;
            dinos = playerGroup.GetComponentsInChildren<DinoControll>();
            foreach (var d in dinos)
            {
                d.gameObject.SetActive(false);
            }

            Save();
        }
    }

    public void CheackChar(int _playerNum)
    {
        currentNum = _playerNum;
    }

    private DinoControll curDino;
    private void Save()
    {
        if (playerGroup == null) return;

        GameObject dino = playerGroup.transform.GetChild(currentNum).gameObject;
        dino.SetActive(true);
        curDino = dino.GetComponent<DinoControll>();
        //GameObject d = GameObject.Find("Player");
        //print(d.name);

        if (SceneManager.GetActiveScene().name == "1.SuccessScene")
        {
            ChangeSuccessScene(dino);
        }
        else
        {
            FailScene(dino);
        }

        for (int i = 0; i < vCams.Length; i++)
        {
            vCams[i].LookAt = dino.transform.Find("Look");
        }
        for (int i = 0; i < vCams2.Length; i++)
        {
            vCams2[i].Follow = dino.transform.Find("Follow");
        }
    }

    private void ChangeSuccessScene(GameObject dino)
    {
        var timeline = playAbleDirector.playableAsset as TimelineAsset;
        foreach (var track in timeline.GetOutputTracks())
        {
            if (track.name == "Animation Track")
            {
                playAbleDirector.SetGenericBinding(track, dino.GetComponent<Animator>());
                break;
            }
        }

    }

    private void FailScene(GameObject dino)
    {
        var timeline = playAbleDirector.playableAsset as TimelineAsset;
        foreach (var track in timeline.GetOutputTracks())
        {
            if (track.name == "Animation Track (4)" || track.name == "Animation Track (1)")
            {
                playAbleDirector.SetGenericBinding(track, dino.GetComponent<Animator>());
                break;
            }
        }

    }

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SwitchEyeShape(int index)
    {
        curDino.SwitchEyeShape(index);
    }

    public void Moving() => curDino.Moveing();
    public void ChangeSpeed(int speed) => curDino.ChangeSpeed(speed);
}