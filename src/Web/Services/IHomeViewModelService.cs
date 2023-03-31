namespace Web.Services
{
    public interface IHomeViewModelService
    {
        Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int? brandId, int pageId = 1);
    }
}