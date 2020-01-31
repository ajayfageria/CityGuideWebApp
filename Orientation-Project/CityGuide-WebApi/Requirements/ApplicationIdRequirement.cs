using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Models
{
    public class ApplicationIdRequirement:IAuthorizationRequirement
    {
        public ApplicationIdRequirement(Guid appId)
        {
            ApplicationId = appId;        
        }
        public Guid ApplicationId { get; set; }
    }
}
