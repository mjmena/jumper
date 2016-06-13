using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public PlayerCharacter player;
    public Text hp_counter;

    public void Update()
    {
        hp_counter.text = (Mathf.Ceil(player.CurrentHealth * 2) / 2).ToString();
        hp_counter.color = new Color(2.0f * (1 - player.CurrentHealth / player.MaxHealth), 2.0f * player.CurrentHealth/player.MaxHealth, 0);

    }
}
