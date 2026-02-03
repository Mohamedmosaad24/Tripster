using BLTripster.ViewModels;
using DATripster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.Mapping
{
    public static class UserProfileMapping
    {
       public static ProfileVM ToProfileVM(this User user)
       => new ProfileVM
       {
           Id = user.Id,
            Name = user.Name,
            Email = user.Email!,
            Location= user.Location,
            Nationality = user.Nationality,
            DateOfBirth = user.DateOfBirth,
            ImageUrl = user.ImageUrl
       };

        public static User ToUser(this ProfileVM profilevm)
       => new User
       {
           Id = profilevm.Id,
           Name = profilevm.Name,
           Email = profilevm.Email!,
           Location = profilevm.Location,
           Nationality = profilevm.Nationality,
           DateOfBirth = profilevm.DateOfBirth,
           ImageUrl = profilevm.ImageUrl
       };

    }

}
