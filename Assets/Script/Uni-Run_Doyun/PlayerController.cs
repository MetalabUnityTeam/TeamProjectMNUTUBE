using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // ��� �� ����� ����� Ŭ��
    public float jumpForce = 700f; // ���� ��

    int jumpCount = 0; // ���� ���� Ƚ��
    bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    bool isDead = false; // ��� ����

    Rigidbody2D playerRigidbody; // ����� ������ٵ� ������Ʈ
    Animator animator; // ����� �ִϸ����� ������Ʈ
    AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ

    int defaultHeart = 3;
    int currentHeart;
    public GameObject heartPanel;
    public GameObject heartPrefab;
    List<GameObject> hearts;
    int maxHeartColumn = 12;

    public GameObject damageZeroEffect;

    void OnEnable()
    {
        currentHeart = 0;
        hearts = new List<GameObject>();
        if (heartPanel)
        {   
            for (int i = 0; i < defaultHeart; i++)
            {
                AddHeart();
            }
        }
    }

    void Start()
    {
        // �ʱ�ȭ
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        playerAudio = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        // ����� �Է��� �����ϰ� �����ϴ� ó��

        if (isDead)
        {
            // ��� �� ó���� �� �̻� �������� �ʰ� ����
            return;
        }

        // ���콺 ���� ��ư�� �������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if (Input.GetMouseButtonDown(0) && jumpCount < 2 && Time.timeScale > 0)
        {
            // ���� Ƚ�� ����
            jumpCount++;
            // ���� ������ �ӵ��� ���������� ����(0, 0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            // ������ٵ� �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // ����� �ҽ� ���
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0 && Time.timeScale > 0)
        {
            // ���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y���� ������(���� ��� ��)
            // ���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        // �ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);
    }

    void Die()
    {
        // ��� ó��
        // �ִϸ������� Die Ʈ���� �Ķ���͸� ��
        animator.SetTrigger("Die");

        // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.clip = deathClip;
        // ��� ȿ���� ���
        playerAudio.Play();

        // �ӵ��� ����(0, 0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        // ��� ���¸� true�� ����
        isDead = true;

        // ���� �Ŵ����� ���ӿ��� ó�� ����
        GameManager.instance.OnPlayerDead();
    }

    void BeAttacked()
    {
        if (isDamageZero == false)
        {
            StartCoroutine("BlinkPlayer");
            DecreaseHeart();
        }        
    }
    
    IEnumerator BlinkPlayer()
    {
        int blinkingNumber = 3;
        float blinkingTime = 0.25f;

        Color32 color32 = this.GetComponent<SpriteRenderer>().color;
        for (int i = 0; i < blinkingNumber*2; i++)
        {
            if (this.GetComponent<SpriteRenderer>().color.a == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(color32.r, color32.g, color32.b, 128);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(color32.r, color32.g, color32.b, 255);
            }
            yield return new WaitForSeconds(blinkingTime);
        }                
    }

    bool isDamageZero = false;
    void DecreaseHeart()
    {
        if (currentHeart > 0)
        {
            currentHeart--;
            Debug.Log(currentHeart.ToString());
            for (int i = 0; i < hearts.Count; i++)
            {
                if (i >= currentHeart && hearts[i].transform.GetChild(0).gameObject.activeSelf == true)
                {
                    hearts[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }

            if (currentHeart == 0)
            {
                Die();
            }
        }        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Ʈ���� �ݶ��̴��� ���� ��ֹ��� �浹�� ����

        if (collision.tag == "Dead" && !isDead)
        {
            // �浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die() ����
            Die();
        }

        if (collision.gameObject.CompareTag("Attack") == true && !isDead)
        {
            BeAttacked();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead") == true && !isDead)
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Attack") == true && !isDead)
        {
            BeAttacked();
        }


        // �ٴڿ� ������� �����ϴ� ó��

        // � �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ������
        if (collision.contacts[0].normal.y > 0.7f)
        {
            // isGrounded�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // �ٴڿ��� ������� �����ϴ� ó��

        // � �ݶ��̴����� ������ ��� isGrounded�� false�� ����
        isGrounded = false;
    }



    public void AddItem(string itemTag)
    {
        string[] tmp = itemTag.Split('_');
        string _itemName = tmp[1];

        switch (_itemName)
        {
            case "HealHeart":
                HealHeart();
                break;
            case "AddHeart":
                AddHeart();
                break;
            case "DamageZero":
                DamageZero();
                break;
            default: break;
        }
    }

    void HealHeart()
    {
        for(int i = 0; i < hearts.Count; i++)
        {
            if (hearts[i].transform.GetChild(0).gameObject.activeSelf == false)
            {
                currentHeart++;
                hearts[i].transform.GetChild(0).gameObject.SetActive(true);
                break;
            }
        }        
    }

    void AddHeart()
    {
        float gap = 5;
        int i = heartPanel.transform.childCount;
        GameObject heart = Instantiate(heartPrefab, heartPanel.transform);        
        float heartWidth = heart.GetComponent<RectTransform>().sizeDelta.x;
        float heartHeight = heart.GetComponent<RectTransform>().sizeDelta.y;
        Vector3 currentPosition = heart.GetComponent<RectTransform>().localPosition;
        float resultPosX = currentPosition.x + (heartWidth + gap) * (i % maxHeartColumn);
        float resultPosY = currentPosition.y - (heartHeight + gap) * (i / maxHeartColumn);
        heart.GetComponent<RectTransform>().localPosition = new Vector3(resultPosX, resultPosY, currentPosition.z);
        hearts.Add(heart);
        heart.transform.GetChild(0).gameObject.SetActive(false);

        HealHeart();
    }

    void DamageZero()
    {
        StartCoroutine("DamageZeroMode");
    }

    IEnumerator DamageZeroMode()
    {
        damageZeroEffect.GetComponent<ParticleSystem>().Play();
        float time = 3f;
        isDamageZero = true;
        yield return new WaitForSeconds(time);
        isDamageZero = false;
        damageZeroEffect.GetComponent<ParticleSystem>().Stop();
    }
}
