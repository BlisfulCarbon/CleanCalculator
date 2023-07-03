using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Operation;
using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public class PlayerPrefsRepository : IRepository
    {
        public const string UNFINISHED_PERSISTENT_KEY = "CleanAddition.Calculator.SessionPersistent";
        public const string HISTORY_PERSISTENT_KEY = "CleanAddition.Calculator.HistoryPersistent";

        public void SaveOperationsHistory<TOperand, TResult>(List<ICalculatorOperation<TOperand, TResult>> data)
        {
            var encodeJson = SerializeOperation(data);
            
            PlayerPrefs.SetString(HISTORY_PERSISTENT_KEY, encodeJson);
        }

        public List<TOperations> LoadOperationHistory<TOperations>()
        {
            var encodeJson = PlayerPrefs.GetString(HISTORY_PERSISTENT_KEY);
            var deserializedData = Deserialize<List<TOperations>>(encodeJson);

            return deserializedData;
        }

        public void SaveUnfinishedOperation(string data)
        {
            var encodeJson = Encode(data);
            
            PlayerPrefs.SetString(UNFINISHED_PERSISTENT_KEY, encodeJson);
        }
        
        public string LoadUnfinishedOperation()
        {
          var encodeData =  PlayerPrefs.GetString(UNFINISHED_PERSISTENT_KEY);
          var decodeData = Decode(encodeData);

          return decodeData;
        }

        private static TDeserialize Deserialize<TDeserialize>(string encodeJson)
        {
            var jsonData = Decode(encodeJson);
            var deserializedData = JsonConvert.DeserializeObject<TDeserialize>(jsonData);
         
            return deserializedData;
        }

        private string SerializeOperation<TOperand, TResult>(List<ICalculatorOperation<TOperand, TResult>> data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var encodeJson = Encode(jsonData);
            
            return encodeJson;
        }

        private static string Decode(string encodeJson)
        {
            var decodeJson = Convert.FromBase64String(encodeJson);
            var jsonData = Encoding.UTF8.GetString(decodeJson);
         
            return jsonData;
        }

        private static string Encode(string data)
        {
            var byteJson = Encoding.UTF8.GetBytes(data);
            var encode = Convert.ToBase64String(byteJson);
         
            return encode;
        }
    }
}