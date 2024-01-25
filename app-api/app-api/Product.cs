using System.Collections.Generic;

public class Produs
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public decimal Pret { get; set; }
    public List<ProdusComanda> ProduseComanda { get; set; }
}
