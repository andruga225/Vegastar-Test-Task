using System.ComponentModel.DataAnnotations;

namespace Vegastar_Test_Task.Models
{
    public class UserState
    {
        public int Id { get; init; }
        public StateOption Code { get; init; }
        public string? Description { get; init; }

    }

    public enum StateOption
    {
        Active,
        Blocked
    }
}
