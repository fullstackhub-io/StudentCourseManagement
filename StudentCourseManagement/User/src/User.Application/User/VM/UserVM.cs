namespace User.Application.User.VM
{
    using System.Collections.Generic;
    using global::User.Application.User.DTO;
    public class UserVM
    {
        public IList<UserDTO> UserList { get; set; }
    }
}
