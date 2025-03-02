using Sandbox.GameDev.Domain.Models.Enums;

namespace Sandbox.GameDev.Domain.Models;

public class GameInput(Dictionary<string, InputKey> settings)
{
    private readonly Dictionary<string, InputKey> Settings = settings;

    public List<InputKey> Keys { get; private set; } = [];

    public InputKey LastKey
    {
        get { return Keys[0]; }
    }

    public void AddKeyPressed(string key)
    {
        try
        {
            InputKey pressedKey = Settings[key];

            if (Keys.IndexOf(pressedKey) == -1)
            {
                Keys.Insert(0, pressedKey);
            }
        }
        catch (KeyNotFoundException)
        {
        }
    }

    public void RemoveKeyReleased(string key)
    {
        try
        {
            InputKey releasedKey = Settings[key];

            if (Keys.IndexOf(releasedKey) == -1) return;

            Keys.Remove(releasedKey);
        }
        catch (KeyNotFoundException)
        {
        }
    }

}
