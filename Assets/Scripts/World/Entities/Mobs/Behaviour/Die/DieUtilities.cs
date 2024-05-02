using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Die {
    public class DieUtilities {
        public LayerMask whatKillsPlayer;

        
        public DieUtilities() {
            whatKillsPlayer = LayerMask.GetMask("WhatKillsPlayer");
        }

        public bool CheckDeath(Vector3 origin) {
            RaycastHit hit;
            if (Physics.Raycast(origin, Vector3.down, out hit, 1f))
                return hit.collider.CompareTag("LethalBlock");
            return false;
        }

    }
}