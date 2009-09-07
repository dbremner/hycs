class Property
{
    private int m_id = -1;
    private string m_name = string.Empty;

    public Property(int id, string name)
    {
        m_id = id;
        m_name = name;
    }

    public int ID
    {
        get
        {
            return m_id;
        }
        set
        {
            m_id = value;
        }
    }

    public string Name
    {
        get
        {
            return m_name;
        }
    }
    static void Main(string[] args)
    {
        Property cust = new Property(1, "Amelio Rosales");

        System.Console.WriteLine(
            "ID: {0}, Name: {1}",
            cust.ID,
            cust.Name);

        cust.ID = 2;
        // cust.Name = "hhhh"; // Failed!! Readonly.
        System.Console.WriteLine(
            "ID: {0}, Name: {1}",
            cust.ID,
            cust.Name);

        System.Console.ReadKey();
    }
}
