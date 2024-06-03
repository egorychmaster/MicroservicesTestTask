namespace Service2.Domain
{
    public class User
    {
        public int Id { get; set; }

        /// <summary> 
        /// Имя 
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary> 
        /// Отчество 
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary> 
        /// Фамилия 
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public int? OrganizationId { get; set; }
        public Organization? Organization { get; private set; }


        public void SetOrganization(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));

            OrganizationId = organization.Id;
            Organization = organization;
        }
    }
}
