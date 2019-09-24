public interface IInteractable
{
    bool isInteractable();
    void Interact();
    void ToggleHighlight(bool newValue);
}