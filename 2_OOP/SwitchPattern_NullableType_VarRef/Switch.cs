namespace SwitchPattern_NullableType_VarRef
{
    class Switch
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Language { get; set; }
        public void Deconstruct(out string name, out string status, out string lang)
        {
            lang = Language;
            status = Status;
            name = Name;
        }
    }
}
