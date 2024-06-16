using ReHub.Domain.Enums;

namespace ReHub.Domain;

//[Table("client_details")]
public class ClientDetails : BaseReHubModel
{

    //[Required]
    public int ClientId { get; set; }

    //[ForeignKey("ClientId")]
    public virtual Client Client { get; set; }

    public DateTime? Birthday { get; set; }

    public PathologyType? Pathology { get; set; }

    //[MaxLength(250)]
    public string Nationality { get; set; }

    //[MaxLength(250)]
    public string Address { get; set; }

    //[MaxLength(250)]
    public string City { get; set; }

    //[MaxLength(250)]
    public string Province { get; set; }

    //[MaxLength(250)]
    public string Country { get; set; }

    //[MaxLength(250)]
    public string PostalCode { get; set; }

    //[MaxLength(250)]
    public string BirthCity { get; set; }

    //[MaxLength(250)]
    public string BirthCountry { get; set; }

    //[MaxLength(15)]
    public string PhoneNumber { get; set; }

    //[MaxLength(16)]
    public string FiscalCode { get; set; }
}