using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    [Header("�� ����")]
    public float minute;
    [Header("�� ����")]
    public float sec;
    private float totalTimeSec;
    private float _endTime;
    [SerializeField] private float currentTime;
    [SerializeField] private float _maxMinute;
    [SerializeField] private string _badEndingScene;
    [SerializeField] private string _hppayEndingScene;
    [SerializeField] private TextMeshProUGUI _DangersTxt;
    private TextMeshProUGUI _timmer;
    private bool _isDangers;
    private void Awake()
    {
        _timmer = GetComponent<TextMeshProUGUI>();
        _DangersTxt.enabled = false;
    }

    void Start()
    {
        // Ÿ�̸Ӹ� ������ �� �ʱ�ȭ
        totalTimeSec = minute * 60f + sec;
        _endTime = minute * 60f + sec;
        currentTime = 0.0f;
    }

    void Update()
    {
        if (((GameScene)SceneManagement.Instance.CurrentScene).Player == null) return;
        currentTime += Time.deltaTime;
        var M = totalTimeSec / 60 - currentTime / 60;
        _timmer.SetText($"운석 충돌까지 {((int)M).ToString("D2")} : {((int)59 - (int)currentTime % 60).ToString("D2")}");

        if (currentTime >= _endTime)
        {

            currentTime = 0.0f;
            if (((GameScene)SceneManagement.Instance.CurrentScene).Player.CurrentLevel >= 30)
            {
                SceneControlManager.FadeOut(() => SceneManager.LoadScene(_hppayEndingScene));
            }
            else
            {
                SceneControlManager.FadeOut(() => SceneManager.LoadScene(_badEndingScene));
            }
        }
        if (currentTime >= _endTime - _endTime / 3 && _isDangers == false)
        {
            _isDangers = true;
            StartCoroutine(DangersStart());
        }
    }

    private IEnumerator DangersStart()
    {

        _DangersTxt.enabled = true;
        yield return new WaitForSeconds(1f);
        _DangersTxt.enabled = false;
        yield return new WaitForSeconds(1f);
        _DangersTxt.enabled = true;
        yield return new WaitForSeconds(1f);
        _DangersTxt.enabled = false;
        yield return new WaitForSeconds(1f);
        _DangersTxt.enabled = true;
        yield return new WaitForSeconds(1f);
        _DangersTxt.enabled = false;

    }
}
