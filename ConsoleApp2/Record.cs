using System;

[Serializable]
public class Record : IComparable<Record>
{
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public Record(string surname, string phoneNumber, string address)
    {
        Surname = surname;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public int CompareTo(Record other)
    {
        return this.Surname.CompareTo(other.Surname);
    }

    public override string ToString()
    {
        return $"Прiзвище: {Surname}, Номер телефону: {PhoneNumber}, Адреса: {Address}";
    }
}