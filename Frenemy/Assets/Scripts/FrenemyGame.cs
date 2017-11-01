using UnityEngine;
using System.Collections;

public class FrenemyGame
{
	//------------------------------------------------------------------------
	// Singleton模版
	private static FrenemyGame _instance;
	public static FrenemyGame Instance
	{
		get
		{
			if (_instance == null)			
				_instance = new FrenemyGame();
			return _instance;
		}
	}

	
	// 遊戲系統

    // 界面
		
	private FrenemyGame()
	{}

	// 初始遊戲相關設定
	public void Initinal()
	{
		// 場景狀態控制

		// 遊戲系統

		// 界面

		// 注入到其它系統

		// 載入存檔

	}

	// 釋放遊戲系統
	public void Release()
	{
		// 遊戲系統

		// 界面

		// 存檔

	}

	// 更新
	public void Update()
	{
		// 玩家輸入

        // 遊戲系統更新

        // 玩家界面更新

    }


}
