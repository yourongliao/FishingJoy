using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

using UnityEngine.Networking;

using XLua;

public class HotFixScript : MonoBehaviour {

    private LuaEnv luaEnv;

    public static Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();

    private void Awake()
    {
        luaEnv = new LuaEnv();

        luaEnv.AddLoader(MyLoader);

        luaEnv.DoString("require 'fish'");
    }

    // Use this for initialization
    void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private byte[] MyLoader(ref string filePath)
    {
        string absPath = @"D:\code\Unity3D\FishingJoy\PlayerGamePackgae\"+filePath+".lua.txt";

        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }

    private void OnDisable()
    {
        luaEnv.DoString("require 'fishDispose'");
    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }


    [LuaCallCSharp]
    public void LoadResource(string resName, string filePath)
    {
        StartCoroutine(LoadResourceCorotine(resName,filePath));

       
    }



    [LuaCallCSharp]
    public static GameObject GetGameObject(string goName)
    {
        
        return prefabDict[goName];

        
    }

    IEnumerator LoadResourceCorotine(string resName,string filePath)
    {
        UnityWebRequest request = UnityWebRequest.GetAssetBundle(@"http://localhost/AssetBundles/" + filePath);

        yield return request.SendWebRequest();


       // AssetBundle ab = AssetBundle.LoadFromFile(@"D:\code\Unity3D\FishingJoy\AssetBundles\" + filePath);

        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;

        GameObject gameObject = ab.LoadAsset<GameObject>(resName);

        prefabDict.Add(resName, gameObject);
    }
}
