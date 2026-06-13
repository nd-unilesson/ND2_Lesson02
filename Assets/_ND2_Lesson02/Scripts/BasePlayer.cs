using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // GameManagerに自身(BasePlayer)の情報を登録
        // GameManager.Instance.players = new BasePlayer[] { this };
        GameManager.Instance.EnterPlayer( this );

        // 👇 GameManagerのInstanceは静的変数なので、GameManager.Instance で直接参照出来る。
        Debug.Log($"プレイヤーから { GameManager.Instance } へアクセス。");
        Debug.Log($"敵の座標は { GameManager.Instance.enemies[0].transform.position } にいる！！");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
