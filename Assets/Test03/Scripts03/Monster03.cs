using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster03 : MonoBehaviour
{
    public void TakeHit()
    {
        // 몬스터는 피격시에 바로 삭제되도록.
        Destroy(gameObject);
    }
}
