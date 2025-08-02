public class PromptManager
{
    private List<string> _list;
    private List<int> _usedIndices = new List<int>();
    private Random _random = new Random();

    // Constructor initializes the list of prompts or questions
    public PromptManager(List<string> prompts)
    {
        _list = prompts;
    }

    // Returns a random prompt or question that hasn't been used in the current round
    public string GetNextUniquePrompt()
    {
        // Reset if all prompts have been used
        if (_usedIndices.Count == _list.Count)
        {
            _usedIndices.Clear();
        }

        int index;
        do
        {
            index = _random.Next(_list.Count);
        } while (_usedIndices.Contains(index));

        _usedIndices.Add(index);
        return _list[index];
    }
}
