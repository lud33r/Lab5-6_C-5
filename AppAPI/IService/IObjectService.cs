using AppAPI.ViewModels;

namespace AppAPI.IService
{
    public interface IObjectService
    {
        public Task<List<NhanVienVM>> GetAll();
        public Task<bool> Create(NhanVienVM nv);
        public Task<bool> Update(NhanVienVM nv);
        public Task<bool> Delete(Guid id);
    }
}
