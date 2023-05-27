using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class LayerTrigger : MonoBehaviour
    {
        [SerializeField] private string _layer;

        private string _stairLayer = "Stairs";

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.isTrigger) { return; }
            Debug.Log($"Layer mask {_layer} layer int {_layer}");
            SetLayerAllChildren(other.gameObject.transform, _layer);
        }

        void SetLayerAllChildren(Transform root, string layer)
        {
            var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = LayerMask.NameToLayer(layer);
            }
        }
    }
}
