namespace Dictionary
{
    class Item<TKey, TValue>
    {
        public Item(TKey key, TValue vlaue)
        {
            Key = key;
            Vlaue = vlaue;
        }

        public TKey Key { get; set; }
        public TValue Vlaue { get; set; }

        public override string ToString()
        {
            return $"{Key} - {Vlaue}";
        }
    }
}
