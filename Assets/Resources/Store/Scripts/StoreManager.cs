using System;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static event Action<StoreItemDto> OnPurchaseSucceeded;
    public static event Action<StoreItemDto, string> OnPurchaseFailed;

    [SerializeField] private WalletService wallet;
    [SerializeField] private StoreDatabase db;

    public void TryPurchase(StoreItemDto item)
    {
        if (item == null) { OnPurchaseFailed?.Invoke(item, "Item inv�lido."); return; }
        if (item.purchased) { OnPurchaseFailed?.Invoke(item, "Item j� comprado."); return; }

        if (!wallet.CanAfford(item.cost))
        {
            OnPurchaseFailed?.Invoke(item, "Moedas insuficientes.");
            return;
        }

        if (!wallet.TryDebit(item.cost))
        {
            OnPurchaseFailed?.Invoke(item, "Falha ao debitar moedas.");
            return;
        }

        db.SavePurchased(item.id);
        item.purchased = true;

        // (Opcional) Instanciar o prefab comprado, se aplic�vel
        if (!string.IsNullOrEmpty(item.prefabpatch))
        {
            var prefab = Resources.Load<GameObject>(item.prefabpatch);
            if (prefab != null) Instantiate(prefab);
        }

        OnPurchaseSucceeded?.Invoke(item);
    }
}
