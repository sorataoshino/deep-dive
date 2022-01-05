using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	static string _settingsDataPath = Application.persistentDataPath + "/Settings.deep";
	static string _highscoreDataPath = Application.persistentDataPath + "/Highscore.deep";

	public static void SaveHighscore(float highscore)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(_highscoreDataPath, FileMode.OpenOrCreate);

		SaveData data = new SaveData(highscore);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static void SaveSettings(float audioVolume, float mouseSensivity)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(_settingsDataPath, FileMode.OpenOrCreate);

		SaveData data = new SaveData(audioVolume, mouseSensivity);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static SaveData Load()
	{
		if (File.Exists(_settingsDataPath))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(_settingsDataPath, FileMode.Open);

			SaveData data = formatter.Deserialize(stream) as SaveData;
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError("Save file not found in" + _settingsDataPath);
			return null;
		}
	}

}
