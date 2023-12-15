using UnityEngine;
using System.Collections;
using Chaotic_Company.Helpers;
using Unity.Netcode;

namespace Chaotic_Company.Managers
{
    public class PlayerSwapManager : NetworkBehaviour
    {
        public float minSwapInterval = 5f;
        public float maxSwapInterval = 15f;

        private void Start()
        {
            if (IsServer)
            {
                StartCoroutine(SwapPlayersCoroutine());
            }
        }

        private IEnumerator SwapPlayersCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minSwapInterval, maxSwapInterval));
                RequestSwapPlayersServerRpc();
            }
        }

        [ServerRpc]
        private void RequestSwapPlayersServerRpc()
        {
            SwapPlayerPositions();
        }

        private void SwapPlayerPositions()
        {
            var players = Helper.Players;
            if (players == null || players.Length <= 1)
                return;

            // Shuffle the players
            System.Random rng = new System.Random();
            int n = players.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var temp = players[k];
                players[k] = players[n];
                players[n] = temp;
            }

            // Teleport each player to the next player's position
            Vector3 firstPlayerPosition = players[0].transform.position;
            Vector3 previousPlayerPosition = firstPlayerPosition;

            for (int i = 1; i < players.Length; i++)
            {
                Vector3 currentPlayerPosition = players[i].transform.position;
                players[i].transform.position = previousPlayerPosition;
                previousPlayerPosition = currentPlayerPosition;
            }

            // Teleport the first player to the last player's original position
            players[0].transform.position = previousPlayerPosition;
        }
    }
}
