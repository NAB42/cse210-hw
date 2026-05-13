class Scripture
{
    private Reference _reference;
    private List<Word> words;

    public Scripture()
    {
        _reference = new Reference();
    }
    public Scripture(Reference reference)
    {
        _reference = reference;
    }

    public Reference DisplayRef()
    {
        return _reference;
    }
}