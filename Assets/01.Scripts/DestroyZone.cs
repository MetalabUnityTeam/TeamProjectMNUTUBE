using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DestroyZone�� ���������� ���ӿ�����Ʈ�� �ı��Ǵ� ��ũ��Ʈ
public class DestroyZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false)
        {
            Destroy(collision.gameObject);
        }
    }
}
