using System.Collections.Generic;
using UnityEngine;

public class StoreDatabase : MonoBehaviour
{
    [SerializeField] private string jsonResourcePath = "Store/store_items"; // sem .json
    private Dictionary<string, StoreItemDto> _map;

    [SerializeField] private bool clearOnStart = false; //Clean registros para os testes

    const string PurchasedKey = "STORE_PURCHASED_IDS";

    private void Awake()
    {
        if (clearOnStart)
        {
            PlayerPrefs.DeleteKey(PurchasedKey);
            PlayerPrefs.Save();
        }
    }

    public IReadOnlyList<StoreItemDto> LoadAll()
    {
        TextAsset ta = Resources.Load<TextAsset>(jsonResourcePath);
        if (ta == null) { Debug.LogError("Store JSON não encontrado"); return new List<StoreItemDto>(); }

        var wrapper = JsonUtility.FromJson<StoreItemsWrapper>(ta.text);
        if (wrapper?.items == null) wrapper = new StoreItemsWrapper { items = new List<StoreItemDto>() };

        // Marcar comprados a partir de PlayerPrefs
        var purchasedCsv = PlayerPrefs.GetString(PurchasedKey, "");
        var purchasedSet = new HashSet<string>(purchasedCsv.Split(',', System.StringSplitOptions.RemoveEmptyEntries));

        foreach (var it in wrapper.items)
            it.purchased = purchasedSet.Contains(it.id);

        return wrapper.items;
    }

    public void SavePurchased(string id)
    {
        var purchasedCsv = PlayerPrefs.GetString(PurchasedKey, "");
        var set = new HashSet<string>(purchasedCsv.Split(',', System.StringSplitOptions.RemoveEmptyEntries));
        if (set.Add(id))
        {
            PlayerPrefs.SetString(PurchasedKey, string.Join(",", set));
            PlayerPrefs.Save();
        }
    }
}
