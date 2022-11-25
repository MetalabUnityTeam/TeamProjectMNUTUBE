using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;
    int[] platformOrder;

    public int stagePlatformsUnitCount;
    int stageLength;

    public float width; // �÷����� ���� ����

    // �ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ
    Vector2 poolPosition = new Vector2(0, -25);

    public GameObject[] currentPlatforms;
    public int currentIndex;

    public GameObject startPlatform;
    float platformPositionY;

    void Awake()
    {
        width = startPlatform.transform.localScale.x;
        platformPositionY = startPlatform.transform.position.y;
    }

    void OnEnable()
    {
        SetVariables();
        SetOrder();
        SpawnPlatforms();
        RepositionPlatforms();
    }

    void SetVariables()
    {
        stagePlatformsUnitCount = 2;
        stageLength = (stagePlatformsUnitCount * 4) + 1;
        currentIndex = 0;        
    }

    void SetOrder()
    {
        int totalPlatformCount = platforms.Length;
        platformOrder = new int[stageLength];

        for (int i = 1; i < stageLength; i++)
        {
            int randNumber = Random.Range(0, totalPlatformCount);            
            platformOrder[i] = randNumber;            
        }        
    }

    void SpawnPlatforms()
    {
        currentPlatforms = new GameObject[stageLength];
        currentPlatforms[0] = startPlatform;

        for (int i = 1; i < stageLength; i++)
        {
            currentPlatforms[i] = Instantiate(platforms[platformOrder[i]], poolPosition, this.transform.rotation, this.transform);
        }        
    }

    // ��ġ�� ���ġ�ϴ� �޼���
    void Reposition()
    {
        // ���� ��ġ���� ���������� ���� ���� 2�踸ŭ �̵�
        Vector2 offset = new Vector2(width, 0);
        try
        {
            Vector2 position = new Vector2(currentPlatforms[currentIndex + 2].transform.position.x, platformPositionY);
            currentPlatforms[currentIndex + 2].transform.position = position + offset;
            Debug.Log("���� �÷��� ��ġ �ű�");
        }
        catch
        {
            Debug.Log("���� �÷��� ����");
        }        
    }

    void RepositionPlatforms()
    {
        Vector2 offset = new Vector2(width, 0);

        for (int i = 1; i < currentPlatforms.Length; i++)
        {
            Vector2 position = new Vector2(currentPlatforms[i].transform.position.x, platformPositionY);
            currentPlatforms[i].transform.position = position + offset * i;
            Debug.Log("���� �÷��� ��ġ �ű�");
        }        
    }
}
