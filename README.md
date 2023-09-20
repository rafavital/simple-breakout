# Simple Breakout

## Screenshots
<img width="1075" alt="image" src="https://github.com/rafavital/simple-breakout/assets/29292002/2eecd596-9bbc-45af-8943-12898949d6ab">
<img width="1074" alt="image" src="https://github.com/rafavital/simple-breakout/assets/29292002/6803a0a0-15b2-450d-be15-2129367965c9">

## Project Architecture
### Assembly Definitions and Conventions
I've divided the project's code in assembly definitions to improve decoupling and to help me create SOLID compliant code.
I've followed simlpe naming conventions:
- `camelCase` for variables, prefixed with `m_` for private variables
- `PascalCase` for method and class names

### Script Communication
In order to avoid script coupling I've used the Observer Design Pattern. 
The `EventBusManager` class is responsible for storing all of the games events and serves as an unified interface on which different scripts can send data around.
I've used the `UnityAction` type for simplicity, but the same could be achieved through C# Events or Delegates.

#### EventBusManager class snippet
```c#
public static class EventBusManager
{
    public static UnityAction OnVictory;
    public static UnityAction OnDefeat;
    public static UnityAction OnBallOutOfBounds;
    public static UnityAction OnReleaseBall;
    public static UnityAction OnPressRestart;
    public static UnityAction<int> OnChangeScore;
    public static UnityAction<int> OnChangeLives;
    public static UnityAction<int> OnGameStateChanged;
    public static UnityAction<float> OnPlayerHorizontalInput;
    public static UnityAction<GameObject> OnBallHitBrick;
    public static UnityAction OnResetStage;

    public static void RaisePlayerHorizontalInput(float value) => OnPlayerHorizontalInput?.Invoke(value);
    public static void RaiseBallOutOfBounds() => OnBallOutOfBounds?.Invoke();
    public static void RaiseBallHitBrick(GameObject brick) => OnBallHitBrick?.Invoke(brick);
    public static void RaiseVictory() => OnVictory?.Invoke();
    public static void RaiseGameStateChanged(int state) => OnGameStateChanged?.Invoke(state);
    public static void RaiseChangeScore(int score) => OnChangeScore?.Invoke(score);
    public static void RaiseReleaseBall() => OnReleaseBall?.Invoke();
    public static void ResetStage() => OnResetStage?.Invoke();
    public static void RaiseRestartKey() => OnPressRestart?.Invoke();
    public static void RaiseChangeLives(int lives) => OnChangeLives?.Invoke(lives);
    public static void RaiseDefeat() => OnDefeat?.Invoke();
}
```

### Managers
I've used the Singleton Design Pattern for the main managers of the game.
In the end it wasn't really necessary, but it helps to create a consistent expected behavior for the managers. That is: there should only be one manager responsible for any given domain.

#### The Singleton Class:
```c#
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<T>();

                if (m_instance == null)
                {
                    GameObject singletonObject = new GameObject($"{typeof(T).Name} Instance");
                    m_instance = singletonObject.AddComponent<T>();
                }
            }
            return m_instance;
        }
    }

    private void OnApplicationQuit()
    {
        m_instance = null;
    }
}
```

## UI
Thanks to the Observer Pattern approach I could easily decouple the UI code from the Gameplay code. 
It only responds to certain data changes, but the UI systems don't need to keep references for gameplay code or even managers.

### Here's the HUD code for example:
```c#
public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private TextMeshProUGUI m_livesText;
    private void OnEnable()
    {
        EventBusManager.OnChangeScore += UpdateScore;
        EventBusManager.OnChangeLives += UpdateLives;
    }

    private void OnDisable()
    {
        EventBusManager.OnChangeScore -= UpdateScore;
        EventBusManager.OnChangeLives -= UpdateLives;
    }

    private void UpdateScore(int score) => m_scoreText.text = $"{score.ToString()}";
    private void UpdateLives(int lives) => m_livesText.text = $"LIVES: {lives.ToString()}";
}
```

## Possible Improvements
- [ ] Add functionality for the EventBusManager to pass around project specific code through it's events
In order to avoid the EventBusManager asmdef from having to reference other asmdefs I couldn't pass around specific data types such as custom enums that weren't defined in a global scope or even custom classes.
- [ ] Create a more abstract Screen component for the Win/Lose screens.
- [ ] Break the scoring from the GameManager into a ScoreManager.
- [ ] Add Game Feel and improve Effects.
- [ ] Add powerups.
- [ ] Improve on visuals.
- [ ] Add sound effects.
- [ ] Adapt the whole project to use a [Singleton Architecture](https://unity-atoms.github.io/unity-atoms/). This would be fun!

## Known Bugs
- [ ] Sometimes the ball get stuck bouncing horizontally.



