using System;

namespace mantis_auto
{
    public class AccountData : IEquatable<AccountData>, IComparable<AccountData>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }

        public AccountData(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
        public AccountData()
        {
        }
        public int CompareTo(AccountData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public bool Equals(AccountData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == ((AccountData)other).Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}