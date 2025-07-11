using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroyNPC", 8f);
    }
    void DestroyNPC()
    {
        NPCspawnmanager.instance.isSpawned = false; // NPC가 제거되었음을 표시
        NPCspawnmanager.instance.spawnCooldown = 8f; // 쿨타임 초기화
        Destroy(gameObject);
    }
}
