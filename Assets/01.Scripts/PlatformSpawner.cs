using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;

    public int stagePlatformsUnitCount;

    float width; // �÷����� ���� ����

    // �ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ
    Vector2 poolPosition = new Vector2(0, -25);

    void Awake()
    {
        //width = ;
    }

    void OnEnable()
    {
        SetVariables();
        SetOrder();
    }

    void Update()
    {
        // ���� ��ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
        if (this.transform.position.x <= -width)
        {
            Reposition();
        }
    }

    void SetVariables()
    {
        stagePlatformsUnitCount = 2;
    }

    void SetOrder()
    {
        int totalPlatformCount = platforms.Length;
        
        for(int i = 0; i < stagePlatformsUnitCount*4; i++)
        {
            int randNumber = Random.Range(0, totalPlatformCount);
            Instantiate(platforms[randNumber], poolPosition, this.transform.rotation, this.transform);
        }
        
    }


    void SpawnPlatform()
    {

    }

    // ��ġ�� ���ġ�ϴ� �޼���
    void Reposition()
    {
        // ���� ��ġ���� ���������� ���� ���� * 2��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        this.transform.position = (Vector2)this.transform.position + offset;
    }
}
