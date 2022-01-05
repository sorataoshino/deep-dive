[System.Serializable]
public class SaveData
{
	public float AudioVolume;
	public float MouseSensivity;
	public float Highscore;

	public SaveData(float highscore)
    {
		Highscore = highscore;
	}

	public SaveData(float audioVolume, float mouseSensivity)
	{
		AudioVolume = audioVolume;
		MouseSensivity = mouseSensivity;
	}
}