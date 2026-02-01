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
            Name = user.Name,
            Email = user.Email!,
            Location= user.Location,
            Nationality = user.Nationality,
            DateOfBirth = user.DateOfBirth,
            ImageUrl = user.ImageUrl
       };


    }

}
