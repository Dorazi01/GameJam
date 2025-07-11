using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroyNPC", 40f);
    }
    void DestroyNPC()
    {
        NPCspawnmanager.instance.isSpawned = false; // NPC가 제거되었음을 표시
        NPCspawnmanager.instance.spawnCooldown = 5f; // 쿨타임 초기화
        Destroy(gameObject);
    }
}
