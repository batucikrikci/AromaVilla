namespace Web.Interfaces
{
    public interface IHomeViewService
    {
        Task<HomeViewModel> GetViewModelAsync(int? categoryId, int? brandId, int pageId = 1);
    }
}
