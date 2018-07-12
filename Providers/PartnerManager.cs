using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StStore21.Data;

namespace StCore21.Models
{
    public class PartnerManager : IPartnerManager
    {
        private ApplicationDbContext _context;

        public PartnerManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPartnerAsync(Partner item)
        {
            await _context.Partners.AddAsync(item);
            _context.SaveChanges();
        }

        public IList<Partner> GetAllPartners()
        {
            return _context.Partners
                    .OrderBy(c => c.OrderNumber).ToList();
        }

        public IList<Partner> GetFilteredSliderItems(bool isShowActive)
        {
            return _context.Partners
                    .Where(c => isShowActive == true? c.IsActive == true : true)
                    .OrderBy(c => c.OrderNumber).ToList();
        }

        public async Task<Partner> GetPartnerByIdAsync(string id)
        {
            return await _context.Partners.Where(c => c.PartnerId == id)
                        .FirstOrDefaultAsync();
        }

        public async Task RemovePartnerAsync(Partner item)
        {
            _context.Partners.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePartnerAsync(Partner item)
        {
            _context.Partners.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}