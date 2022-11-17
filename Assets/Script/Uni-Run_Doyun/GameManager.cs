using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// ���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���� �Ŵ���
// ������ �� �ϳ��� ���� �Ŵ����� ������ �� ����
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public bool isGameover = false; // ���ӿ��� ����
    public TextMeshProUGUI scoreText; // ������ ����� UI �ؽ�Ʈ
    public TextMeshProUGUI gameoverUI; // ���ӿ��� �� Ȱ��ȭ�� UI ���� ������Ʈ

    int score = 0; // ���� ����


    bool isAdded = false;
    float addedTime;
    float scoreScale = 1f;

    public GameObject countDownNumber;
    int count = 3;
    int currentCount;
    List<string> coList;

    public Image timeBar;
    bool isCountDown = false;

    // ���� ���۰� ���ÿ� �̱����� ����
    void Awake()
    {
        currentTimeScale = 1f;
        Time.timeScale = 0;

        // �̱��� ���� instance�� ��� �ִ°�?
        if (instance == null)
        {
            // instance�� ��� �ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            // ���� �� �� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        isAdded = false;
        addedTime = 0f;
        scoreScale = 1f;
    }

    void Start()
    {
        CountDownSeconds();
    }

    void Update()
    {
        // ���ӿ��� ���¿��� ������ ������� �� �ְ� �ϴ� ó��
        if (isGameover && Input.GetMouseButton(0))
        {
            // ���ӿ��� ���¿��� ���콺 ���� ��ư�� Ŭ���ϸ� ���� �� �����
            RestartGame();
        }

        if (isAdded == true)
        {            
            addedTime -= Time.deltaTime;
            if (addedTime <= 0f)
            {
                isAdded = false;
                addedTime = 0f;
                scoreScale = 1f;
            }
        }

        if (isCountDown == true)
        {
            timeBar.fillAmount -= Time.unscaledDeltaTime;
        }
    }

    // ������ ������Ű�� �޼���
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴ϶��
        if (!isGameover)
        {
            // ������ ����
            score += (int)(newScore*scoreScale);
            scoreText.text = $"Score : {score}";

            // �߰� ������ ȹ���� �� �ִ� �ð� �ο�
            SetAddedTime();
        }
    }

    // �÷��̾� ĳ���� ��� �� ���ӿ����� �����ϴ� �޼���
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.gameObject.SetActive(true);
    }



    void SetAddedTime()
    {
        scoreScale *= 1.5f;
        addedTime = 1f;
        isAdded = true;
    }

    float currentTimeScale;
    public void ToggleMenuPanel(GameObject menuPanel)
    {
        if (Time.timeScale != 0)
        {
            currentTimeScale = Time.timeScale;
            OnMenuPanel(menuPanel);
        }
        else
        {
            OffMenuPanel(menuPanel);
        }
    }    

    void OnMenuPanel(GameObject menuPanel)
    {
  
        Time.timeScale = 0;
        menuPanel.SetActive(true);
    }

    void OffMenuPanel(GameObject menuPanel)
    {        
        menuPanel.SetActive(false);        
        CountDownSeconds();        
    }

    void CountDownSeconds()
    {
        coList = new List<string>();
        currentCount = count;        
        StartCoroutine("CountDown");                        
    }
    
    IEnumerator CountDown()
    {
        if (coList.Count == 0)
        {
            coList.Add("CountDown");
            countDownNumber.SetActive(true);
            for (int i = 0; i < count; i++)
            {
                ResetCountDownBar();
                ChangeCountDownNumber();
                ChangeCountDownBar();
                yield return new WaitForSecondsRealtime(1f);
            }            
            Time.timeScale = currentTimeScale;
            countDownNumber.SetActive(false);
            isCountDown = false;
            coList.Clear();
        }        
    }

    void ChangeCountDownNumber()
    {
        countDownNumber.GetComponentInChildren<TextMeshProUGUI>().text = currentCount--.ToString();
    }

    
    void ResetCountDownBar()
    {
        timeBar.fillAmount = 1f;
    }

    void ChangeCountDownBar()
    {
        isCountDown = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
