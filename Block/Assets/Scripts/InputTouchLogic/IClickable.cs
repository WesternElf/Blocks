using System;

namespace Interfaces
{
    public interface IClickable
    {
        event Action<int> OnPressed;
        event Action OnReleased;
        event Action OnHold;
    }
}