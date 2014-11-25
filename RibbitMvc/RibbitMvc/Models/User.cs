using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RibbitMvc.Models
{
    public class User
    {
        public User()
        {
            Ribbits = new List<Ribbit>();
            Followers = new List<User>();
            Followings = new List<User>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Password { get; set; }

        public int UserProfileId { get; set; }

        [ForeignKey("UserProfileId")]
        public virtual UserProfile Profile { get; set; }

        //property for user.rabbits...
        public virtual ICollection<Ribbit> Ribbits { get; set; }
        //property for user.followers
        public virtual ICollection<User>  Followers { get; set; }
        //property for user.followings
        public virtual ICollection<User> Followings { get; set; }
        
    }
}