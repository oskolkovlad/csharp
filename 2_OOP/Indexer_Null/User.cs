namespace Indexer_Null
{
    class User
    {
        string name;
        string phone;
        string email;

        public string this[string field]
        {
            get
            {
                switch (field)
                {
                    case "name": return name;
                    case "phone": return phone;
                    case "email": return email;
                    default: return null;
                }
            }
            set
            {
                if (!field.Equals(null))
                    switch (field)
                    {
                        case "name":
                            name = value;
                            break;
                        case "phone":
                            phone = value;
                            break;
                        case "email":
                            email = value;
                            break;
                    }
            }
        }

        public override string ToString()
        {
            return $"Name: {name};\nPhone: {phone}\nE-mail: {email}";
        }
    }
}
