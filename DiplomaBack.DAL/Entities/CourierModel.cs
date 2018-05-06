using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomaBack.DAL.Entities
{
    public class CourierModel
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public UserModel Identity { get; set; } 
    }
}
