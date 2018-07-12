using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StCore21.Models
{
    public interface IPartnerManager
    {
        IList<Partner> GetAllPartners();
        IList<Partner> GetFilteredSliderItems(bool isShowActive);
        Task AddPartnerAsync (Partner item);
        Task<Partner> GetPartnerByIdAsync (string id);
        Task UpdatePartnerAsync(Partner item);
        Task RemovePartnerAsync(Partner item);
    }
}