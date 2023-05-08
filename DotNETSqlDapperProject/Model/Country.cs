namespace DotNETSqlDapperProject.Model;
public partial class Country
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }="";
    public bool IsDemocracy { get; set; }
    public int PopulationInMillion { get; set; }
}