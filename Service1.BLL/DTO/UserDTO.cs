namespace Service1.BLL.DTO
{
    public record UserDTO
    {
        public int Id { get; init; }

        public string Name { get; init; }
        public string? MiddleName { get; init; }
        public string Surname { get; init; }

        public string Email { get; init; }
    }
}
