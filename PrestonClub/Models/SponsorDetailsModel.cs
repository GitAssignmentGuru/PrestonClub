using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestonClub.Models
{
    public class SponsorDetailsModel
    {
        public SponserList spl { get; set; }
        public List<RegistrationDetail> rgf { get; set; }
        public List<AmateurSponserDetail> asi { get; set; }
    }
}