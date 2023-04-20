using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VE.Areas.Identity.Data;

// Add profile data for application users by adding properties to the VEUser class
public class VEUser : IdentityUser
{
    [PersonalData]
    public string Prenom { get; set; }
    [PersonalData]
    public string Nom { get; set; } 
}

