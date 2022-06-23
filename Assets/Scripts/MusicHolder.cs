 using UnityEngine;
 using System.Collections;
 
 public class MusicHolder : MonoBehaviour
 {
 
     private static MusicHolder instance = null;
     public static MusicHolder Instance
     {
         get { return instance; }
     }
     void Awake()
     {
         if (instance != null && instance != this) {
             Destroy(this.gameObject);
             return;
         } else {
             instance = this;
         }
         DontDestroyOnLoad(this.gameObject);
     }
 }