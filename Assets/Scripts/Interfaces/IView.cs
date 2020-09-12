using UnityEngine;
using UnityEngine.Events;

namespace Interfaces
{
    public interface IView
    {
        void Show(GameObject gameObject);
        
        void Hide(GameObject gameObject);
    }
}