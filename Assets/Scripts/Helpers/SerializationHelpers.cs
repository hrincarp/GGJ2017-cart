using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SerializationHelpers {

    public static T DeserializeData<T>(byte[] data) {

        T deserializedData = default(T);

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        var memoryStream = new MemoryStream(data);
        using(memoryStream) {
            try {
                deserializedData = (T)binaryFormatter.Deserialize(memoryStream);
            }
            catch {
                deserializedData = default(T);
            }
        }          

        return deserializedData;
    }

    public static byte[] SerializeObject<T>(T serializableObject) {

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        using(memoryStream) {
            binaryFormatter.Serialize(memoryStream, serializableObject);
        }
        return memoryStream.ToArray();
    }

    public static T DeserializeDataFromPlayerPrefs<T>(string key) {

        T deserializedData = default(T);
        String stringData = PlayerPrefs.GetString(key, null);

        if (stringData != null) {

            byte[] data = Convert.FromBase64String(stringData);
            deserializedData = DeserializeData<T>(data);       
        } 
        return deserializedData;
    }
           
    public static void SerializeObjectIntoPlayerPrefs<T>(string key, T serializableObject) {

        byte[] data = SerializeObject(serializableObject);
        PlayerPrefs.SetString(key, Convert.ToBase64String(data));
    }
        
    public static T DeserializeDataFromFile<T>(string filePath) {

        if (!File.Exists(filePath)) {
            return default(T);
        }
        T deserializedData = default(T);

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        try {
            FileStream fileStream = File.Open(filePath, FileMode.Open);
            deserializedData = (T)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
        }
        catch {
            deserializedData = default(T);
        }       

        return deserializedData;
    }

    public static void SerializeObjectToFile<T>(string filePath, T serializableObject) {

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(filePath);
        binaryFormatter.Serialize(fileStream, serializableObject);     
        fileStream.Close();
    }
}
