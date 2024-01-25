using System;
using System.Collections.Generic;

public class Comanda
{
    public int Id { get; set; }
    public int UtilizatorId { get; set; }
    public User Utilizator { get; set; }
    public DateTime DataComenzii { get; set; }
}
