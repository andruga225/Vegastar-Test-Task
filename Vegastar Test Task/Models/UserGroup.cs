    using System.ComponentModel.DataAnnotations;

    namespace Vegastar_Test_Task.Models
    {
        public class UserGroup
        {
            public int Id { get; init; }
            public GroupOption Code { get; init; }
            public string? Discription { get; init; }
        }

        public enum GroupOption
        {
            Admin,
            User
        }
    }
