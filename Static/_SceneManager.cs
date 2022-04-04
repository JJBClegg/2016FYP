using UnityEngine;
using System.Collections;

public static class _SceneManager
{
    static int currentSceneNum = 0;

   public static void JumpToScene(int scenNum)
    {
		currentSceneNum = scenNum;
		//these two if statements act as a check against levels that dont exist. If a level doesn't exist
		//we boot the player back to the main menu.
		if (currentSceneNum > Application.levelCount) 
		{
			currentSceneNum = 0;
		}
		
		if (currentSceneNum < 0) 
		{
			currentSceneNum = 0;
		}

        Application.LoadLevel(scenNum);
        currentSceneNum = scenNum;
    }

    public static void AdvanceScene()
    {
        currentSceneNum++;

		if (currentSceneNum > (Application.levelCount - 1)) 
		{
			currentSceneNum = 0;
		}

		if (currentSceneNum < 0) 
		{
			currentSceneNum = 0;
		}
        Application.LoadLevel(currentSceneNum);
    }

    public static void RegressScene()
    {
        currentSceneNum--;

		if (currentSceneNum > (Application.levelCount -1))
		{
			currentSceneNum = 0;
		}
		
		if (currentSceneNum < 0) 
		{
			currentSceneNum = 0;
		}

        Application.LoadLevel(currentSceneNum);
    }
}
