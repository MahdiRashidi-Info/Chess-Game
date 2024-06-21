using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChessGame
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private List<AudioClip> clips;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            SceneManager.sceneLoaded += SceneManagerOnLoaded;

            void SceneManagerOnLoaded(Scene where, LoadSceneMode arg1)
            {
                source.Stop();
                
                var firstOrDefault = clips.FirstOrDefault(x=>x.name.Equals(where.name));
                if (firstOrDefault is not null)
                {
                    source.clip = firstOrDefault;
                    source.loop = true;
                    source.Play();
                }
            }
        }
        
        
    }
}