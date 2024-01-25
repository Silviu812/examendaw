using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class User
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Email { get; set; }
    public List<Comanda> Comenzi { get; set; }
}
