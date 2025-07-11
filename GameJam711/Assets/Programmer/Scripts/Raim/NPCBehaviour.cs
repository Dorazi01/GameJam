using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroyNPC", 3f);


        
        UIMananger.instance.ShowRandomDialog(GameManager.instance.npcLevel);

        


    }
    void DestroyNPC()
    {
        NPCspawnmanager.instance.isSpawned = false; // NPC가 제거되었음을 표시
        NPCspawnmanager.instance.spawnCooldown = 5f; // 쿨타임 초기화
        Destroy(gameObject);
    }


    

}
