using Microsoft.EntityFrameworkCore;
using SoftwareVillage.Data;
using System;

namespace SoftwareVillage.Services
{
    public class LayoutService
    {
        private readonly SoftwareVillageDbContext _context;

        public LayoutService(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string,string>> GetSettingAsync()
        {
            Dictionary<string,string> setting = await _context.layout_Services.ToDictionaryAsync(s=>s.Key, s=>s.Value);
            return setting;
        }
    }
}
