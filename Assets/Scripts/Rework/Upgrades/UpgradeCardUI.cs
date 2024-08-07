using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.TopDownEngine.Upgrades
{
    public class UpgradeCardUI : MonoBehaviour
    {
        [field: SerializeField] public Image CardIcon { get; private set; }
        [field: SerializeField] public TextMeshProUGUI CardTitle { get; private set; }
        [field: SerializeField] public TextMeshProUGUI CardDescription { get; private set; }
    }
}
