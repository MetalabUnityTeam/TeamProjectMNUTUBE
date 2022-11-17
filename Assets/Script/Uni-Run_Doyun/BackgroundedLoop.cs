using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundedLoop : MonoBehaviour
{
    // ���� ������ �̵��� ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ

    float width; // ����� ���� ����

    void Awake()
    {
        // ���� ���̸� �����ϴ� ó��
        // BoxCollider2D ������Ʈ�� Size �ʵ��� x ���� ���� ���̷� ���
        BoxCollider2D backgroundCollider = this.GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;

    void Update()
    {
        // ���� ��ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
        if (this.transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // ��ġ�� ���ġ�ϴ� �޼���
    void Reposition()
    {
        // ���� ��ġ���� ���������� ���� ���� * 2��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        this.transform.position = (Vector2)this.transform.position + offset;
    }
}
