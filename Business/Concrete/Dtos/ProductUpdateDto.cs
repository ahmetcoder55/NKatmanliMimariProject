namespace Business.Concrete.Dtos
{
    public record ProductUpdateDto
    {
         public int ProductId { get; init; }

        public String ProductName { get; init; }

        public String? ProductDescripton { get; init; }

        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
    }
}