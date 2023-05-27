using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class LayerTrigger : MonoBehaviour
    {
        [SerializeField] public string layer;
        //[SerializeField] public SortingLayer _sortingLayer;

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log($"Layer mask {layer} layer int {layer}");
            SetLayerAllChildren(other.gameObject.transform, layer);
            //other.gameObject.layer = LayerMask.NameToLayer(layer.ToString());

            /*other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = _sortingLayer.ToString();
            SpriteRenderer[] srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach ( SpriteRenderer sr in srs)
            {
                sr.sortingLayerName = _sortingLayer.ToString();
            }*/
        }

        void SetLayerAllChildren(Transform root, string layer)
        {
            var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                //            Debug.Log(child.name);
                child.gameObject.layer = LayerMask.NameToLayer(layer);
            }
        }
    }
}
