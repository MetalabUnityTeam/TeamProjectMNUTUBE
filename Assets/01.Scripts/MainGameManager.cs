<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file을 담당하는 게임매니저
=======
癤퓎sing System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main Unity scene file�쓣 �떞�떦�븯�뒗 寃뚯엫留ㅻ땲���
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
    private static MainGameManager m_instance; //�떛湲��꽩�씠 �븷�떦�맆 蹂��닔
>>>>>>> parent of 31943a4 (Merge branch 'main' of https://github.com/jkyoung710/TeamProjectMNUTUBE)

    public int stamina, gauge;
    public int maxStamina, maxGauge;

    public bool isGameover;

    private void OnEnable()
    {
<<<<<<< HEAD
        // 변수 초기화
=======
        // 蹂��닔 珥덇린�솕
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
