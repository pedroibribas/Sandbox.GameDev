using Sandbox.GameDev.Domain.Models.Enums;

namespace Sandbox.GameDev.Domain.Models;

public abstract class GameInput()
{
    protected abstract Dictionary<string, InputKey> Settings { get; }

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
