using UnityEngine;

// === 使用するデザインパターン === //
// - シングルトンパターン (Singleton Pattern) -
// このプロジェクト内に、『ただ一つのみ存在するオブジェクト』を作る時に使用するパターン。
// どのオブジェクトからでも即座にアクセスできる！！
public class GameManager : MonoBehaviour
{
    // 静的(static)な変数
    // 👇[static]を付けた変数はどこからでも参照（アクセス）できる！！
    public static GameManager Instance { get; private set; }

    // === 各種変数を宣言 === //
    public BasePlayer[] players;
    public BaseEnemy[] enemies;

    // Start の上位互換 ※Start よりも速く実行される
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;                    // 変数に自身のクラスを代入
        DontDestroyOnLoad( gameObject );    // シーンが変わっても破棄されない設定
    }

    void Start()
    {
        // === 各配列の初期化 === //
        players = new BasePlayer[4];        // プレイヤーを4体で初期化
        enemies = new BaseEnemy[100];       // 敵を100体で初期化
    }

    void Update()
    {
        
    }

    // === オブジェクトを登録するメソッド === //
    public void EnterPlayer (BasePlayer player)
    {
        // 初期化が出来てなければ、何もしない...
        if( players == null || players.Length == 0 )
        {
            Debug.Log("配列の初期化に失敗していますよ...");
            return;     // 強制終了...
        }

        // forループを使って配列の中身を全てチェック
        for( int index = 0; index < players.Length; index++ )
        {
            Debug.Log($"配列の { index } 番目の中身 >> { players[index] }");
            if (players[index] == null)
            {
                Debug.Log($"{ index }番目に中身がない(Null)ので、{ player } を代入します。");
                players[index] = player;
                
                return;     // 入れたら終了
            }
        }

        Debug.Log($"空きがないので、{ player }を設定出来ませんでした...");
    }

    public void EnterEnemy(BaseEnemy enemy)
    {
        if( enemies == null || enemies.Length == 0 )
        {
            return;
        }

        for( int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = enemy;
                return;
            }
        }
    }
}
