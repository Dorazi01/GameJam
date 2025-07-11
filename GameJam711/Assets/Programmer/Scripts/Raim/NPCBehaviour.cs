using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroyNPC", 8f);
    }
    void DestroyNPC()
    {
        NPCspawnmanager.instance.isSpawned = false; // NPC�� ���ŵǾ����� ǥ��
        NPCspawnmanager.instance.spawnCooldown = 8f; // ��Ÿ�� �ʱ�ȭ
        Destroy(gameObject);
    }
}
