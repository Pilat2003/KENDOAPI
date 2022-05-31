    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

namespace Kendo.dtos
{
    public class UserWriteDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}

