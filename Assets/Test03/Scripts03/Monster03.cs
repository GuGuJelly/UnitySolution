using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster03 : MonoBehaviour
{
    public void TakeHit()
    {
        // ���ʹ� �ǰݽÿ� �ٷ� �����ǵ���.
        Destroy(gameObject);
    }
}
