﻿using System.Collections.Generic;
using PersonAddressLibrary.Framework.Models.Addresses;

namespace PersonAddressLibrary.Framework.Models
{
    public class PersonModel: IPersonModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<IPersonAddressModel> Addresses { get; set; } = new List<IPersonAddressModel>();
        public string DisplayPersonView => $"{FirstName} {LastName} ({Email})";
    }
}
