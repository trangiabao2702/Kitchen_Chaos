using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlatesTimer = 0f;
    private float spawnPlatesTimerMax = 4f;
    private int platesSpawnAmount = 0;
    private int platesSpawnAmountMax = 4;

    private void Update()
    {
        spawnPlatesTimer += Time.deltaTime;
        if (KitchenGameManager.Instance.IsGamePlaying() && spawnPlatesTimer > spawnPlatesTimerMax)
        {
            spawnPlatesTimer = 0;

            if (platesSpawnAmount < platesSpawnAmountMax)
            {
                platesSpawnAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is empty handed
            if (platesSpawnAmount > 0)
            {
                // There's at least one plate here
                platesSpawnAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
