<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file을 담당하는 게임매니저
=======
癤퓎sing System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file???대떦?섎뒗 寃뚯엫留ㅻ땲?�
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
    private static MainGameManager m_instance; //싱글턴이 할당될 변수
=======
    private static MainGameManager m_instance; //?깃??댁씠 ?좊떦??蹂�??
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)

    public int stamina, gauge;
    public int maxStamina, maxGauge;

    public bool isGameover;

    private void OnEnable()
    {
<<<<<<< HEAD
        // 변수 초기화
=======
        // 蹂�??珥덇린??
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
