using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StCore21.Models
{
    public interface ISliderItemManager
    {
        IList<SliderItem> GetAllSliderItems();
        IList<SliderItem> GetFilteredSliderItems(bool isShowExpired, bool isShowActive);
        Task AddSliderItemAsync (SliderItem item);
        Task<SliderItem> GetSliderItemByIdAsync (string id);
        Task UpdateSliderItemAsync(SliderItem item);
        Task RemoveTagAsync(SliderItem item);
    }
}