using UnityEngine;

namespace Models
{
    public class ShopManager
    {
        private Material _currentBallMaterial;

        public ShopManager(Material currentBallMaterial)
        {
            _currentBallMaterial = currentBallMaterial;
        }

        public void SetColor(Color color)
        {
            _currentBallMaterial.color = color;
        }
    }
}