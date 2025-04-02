using System;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Slide;
using System.Collections.Generic;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<Guid, Slide>
    {
        EditSlide GetDetails(Guid id);
        List<SlideViewModel> GetList();
    }
}
