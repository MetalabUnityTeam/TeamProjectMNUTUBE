using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HanSeo
{
    // �������μ� �ʿ��� ������ ���� ��ũ��Ʈ
    public class Platform : MonoBehaviour
    {
        public GameObject[] obstacles; // ��ֹ� ������Ʈ��
        public GameObject[] coins;
        private bool stepped = false; // �÷��̾� ĳ���Ͱ� ��Ҵ°�

        // ������Ʈ�� Ȱ��ȭ�� ������ �Ź� ����Ǵ� �޼���
        private void OnEnable()
        {
            // ������ �����ϴ� ó��
            // ���� ���¸� ����
            stepped = false;

            // ��ֹ��� ����ŭ ����
            for (int i = 0; i < obstacles.Length; i++)
            {
                // ���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ
                if (Random.Range(0, 3) == 0)
                {
                    obstacles[i].SetActive(true);
                }
                else
                {
                    obstacles[i].SetActive(false);
                }
            }

            for (int i = 0; i < coins.Length; i++)
            {

                if (Random.Range(0, 5) == 0)
                {
                    coins[i].SetActive(true);
                }
                else
                {
                    coins[i].SetActive(false);
                }
            }


        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            // �÷��̾� ĳ���Ͱ� �ڽ���
            // ����� �� ������ �߰��ϴ� ó��

            // �浹�� ������ �±װ� Player�̰�
            // ������ �÷��̾� ĳ���Ͱ� ���� �ʾҴٸ�
            if (collision.collider.tag == "Player" && !stepped)
            {
                // ������ �߰��ϰ� ���� ���¸� ������ ����
                stepped = true;
                GameManager.instance.AddScore(1);
            }
        }
    }
}