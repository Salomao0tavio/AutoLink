using LocadoraAPI.Enums;

namespace LocadoraAPI.Models.CreateModels
{
    public class EmployeeCreateModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EmployePosition Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
