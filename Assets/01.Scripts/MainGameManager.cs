using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file�� ����ϴ� ���ӸŴ���
public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<MainGameManager>();
            }

            return m_instance;
        }
    }
    private static MainGameManager m_instance; //�̱����� �Ҵ�� ����

    public int stamina, gauge;
    public int maxStamina, maxGauge;

    public bool isGameover;

    private void OnEnable()
    {
        // ���� �ʱ�ȭ
        SetVariables();
    }

    void SetVariables()
    {
        stamina = 100;
        gauge = 0;
        maxStamina = stamina;
        maxGauge = gauge;

        isGameover = false;
    }
}
