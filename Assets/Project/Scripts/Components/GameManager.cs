using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string mapa;
    [SerializeField] private Button playButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Animator programPanelAnim;

    private static bool isPlaying;
    private static bool created = false;

    [Header("Prefabs")]
    [SerializeField] private GameObject dataPrefab;

    private static GameManager instance = null;
    public static GameManager Instance() { return instance; }
    void Awake()
    {
        instance = this;
        if (created) return;
        GameObject data = Instantiate(dataPrefab);
        data.name = "DATA";
        DontDestroyOnLoad(data);
        created = true;
    }

    private void Start()
    {
        playButton.onClick.AddListener(() => Play());
        pauseButton.onClick.AddListener(() => Pause());

        if (CommandData.Instance().GetBuild().Count <= 0) isPlaying = false;
    }

    private void Update()
    {
        programPanelAnim.SetBool("ShowWindow", !isPlaying);
        playButton.gameObject.SetActive(!isPlaying);
        pauseButton.gameObject.SetActive(isPlaying);
    }

    private void Play()
    {
        isPlaying = true;
        SceneManager.LoadScene(mapa);
    }
    private void Pause()
    {
        isPlaying = false;
        SceneManager.LoadScene(mapa);
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }
}
