public class PromptManager
{
    // Attributes:
    private List<string> _list;
    private List<int> _usedIndices = new List<int>();
    private Random _random = new Random();

    // Constructors:
    public PromptManager(List<string> prompts)
    {
        _list = prompts;
    }

    // Methods:
    public string GetNextUniquePrompt()
    {
        if (_usedIndices.Count == _list.Count)
        {
            _usedIndices.Clear();
        }
        int index;
        do
        {
            index = _random.Next(_list.Count);
        }
        while (_usedIndices.Contains(index));
        _usedIndices.Add(index);
        return _list[index];
    }
}