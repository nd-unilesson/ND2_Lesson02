using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 👇 GameManagerのInstanceは静的変数なので、GameManager.Instance で直接参照出来る。
        Debug.Log($"エネミーから { GameManager.Instance } へアクセス。");
        GameManager.Instance.EnterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
