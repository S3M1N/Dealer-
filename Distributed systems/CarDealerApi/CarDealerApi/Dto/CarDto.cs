namespace CarDealerApi.Dto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public DateTime Year { get; set; }
        public Decimal Price { get; set; }
        public bool Stat { get; set; }
    }
}
