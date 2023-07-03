using System.Collections.Generic;
 using Data;
 using Domain;
 using Domain.Operation;
 using UnityEngine;
 
 public class Bootstrapper : MonoBehaviour
 {
     public SceneDataMono SceneData;
 
     public void Awake()
     {
         IRepository repository = new PlayerPrefsRepository();
 
         ServiceContext
             .Container
             .RegistrationSingle
                 <IRepository>(repository);
     }
 }