using System.Collections.Generic;
using ChessGame.Models;
using UnityEngine;

namespace ChessGame
{
    public abstract class Utils 
    {
        public static ConfigModel GetConfigValue()
        {
            var textAsset = Resources.Load<TextAsset>("config");
            Debug.Log(textAsset.text);
            return JsonUtility.FromJson<ConfigModel>(textAsset.text);
        }
        public static void ContactSupport()
        {
            Application.OpenURL("https://eitaa.com/majesty_mahdi");
        }
        
        public static void OpenCafeBazaarRateUs()
        {
            var intentClass = new AndroidJavaClass ("android.content.Intent");
            var intentObject = new AndroidJavaObject ("android.content.Intent");
            var uriClass = new AndroidJavaClass ("android.net.Uri");
    
            intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_EDIT"));
            intentObject.Call<AndroidJavaObject> ("setData", uriClass.CallStatic<AndroidJavaObject> ("parse", "bazaar://details?id=com.mahdirashidi.chess"));
            intentObject.Call<AndroidJavaObject> ("setPackage", "com.mahdirashidi.chess");
    
            var unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            var currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
            currentActivity.Call ("startActivity", intentObject);
        }
        public static void OpenMyketRateUs()
        {
            var intentClass = new AndroidJavaClass ("android.content.Intent");
            var intentObject = new AndroidJavaObject ("android.content.Intent");
            var uriClass = new AndroidJavaClass ("android.net.Uri");
            intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_VIEW"));
            intentObject.Call<AndroidJavaObject> ("setData", uriClass.CallStatic<AndroidJavaObject> ("parse", "myket://comment?id=com.mahdirashidi.chess"));
            var unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
            var currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
            currentActivity.Call ("startActivity", intentObject);
        }
        
        public static void RestartApp() {
            if (Application.isEditor) return;

            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
                const int kIntent_FLAG_ACTIVITY_CLEAR_TASK = 0x00008000;
                const int kIntent_FLAG_ACTIVITY_NEW_TASK = 0x10000000;

                var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                var pm = currentActivity.Call<AndroidJavaObject>("getPackageManager");
                var intent = pm.Call<AndroidJavaObject>("getLaunchIntentForPackage", Application.identifier);

                intent.Call<AndroidJavaObject>("setFlags", kIntent_FLAG_ACTIVITY_NEW_TASK | kIntent_FLAG_ACTIVITY_CLEAR_TASK);
                currentActivity.Call("startActivity", intent);
                currentActivity.Call("finish");
                var process = new AndroidJavaClass("android.os.Process");
                int pid = process.CallStatic<int>("myPid");
                process.CallStatic("killProcess", pid);
            }
        }
    }
}