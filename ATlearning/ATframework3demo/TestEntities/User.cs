public class User
{
    public User(List<string> userData = null)
    {
        if (userData != null && userData.Count != 4)
        {
            throw new ArgumentException("Invalid argument: userData list should contain exactly 4 elements.");
        }
        if (userData != null)
        {
            this.Name = userData[0];
            this.Surname = userData[1];
            this.eMail = userData[2];
            this.Password = userData[3];
        }
        
    }

    public string eMail { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}