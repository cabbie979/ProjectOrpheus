using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveLoad 
{
    public static void SaveCoin(Coin coin)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/coin.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        CoinData data = new CoinData(coin);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CoinData LoadCoin()
    {
        string path = Application.persistentDataPath + "/coin.bin";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CoinData data = formatter.Deserialize(stream) as CoinData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static CoinData DeleteCoin()
    {
        File.Delete(Application.persistentDataPath + "/coin.bin");
        return null;
    }
}
