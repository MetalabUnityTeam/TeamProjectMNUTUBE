<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file�� ����ϴ� ���ӸŴ���
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file을 담당하는 게임매니저
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)
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
<<<<<<< HEAD
    private static MainGameManager m_instance; //�̱����� �Ҵ�� ����
=======
    private static MainGameManager m_instance; //싱글턴이 할당될 변수
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)

    public int stamina, gauge;
    public int maxStamina, maxGauge;

    public bool isGameover;

    private void OnEnable()
    {
<<<<<<< HEAD
        // ���� �ʱ�ȭ
=======
        // 변수 초기화
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)
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
