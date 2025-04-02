using _0_Framework.Application;
using System;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Remove(Guid id);
        OperationResult Restore(Guid id);
        EditSlide GetDetails(Guid id);
        List<SlideViewModel> GetList();
    }
}
