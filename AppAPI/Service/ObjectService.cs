using AppAPI.IService;
using AppAPI.ViewModels;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Service
{
    public class ObjectService : IObjectService
    {
        private readonly NhanVienDbContext _context;
        public ObjectService(NhanVienDbContext nhanVienDbContext)
        {
            _context = nhanVienDbContext;
        }
        public async Task<bool> Create(NhanVienVM nv)
        {
            try
            {
                NhanVien nvien = new()
                {
                    Id = Guid.NewGuid(),
                    Ten = nv.Ten,
                    Tuoi = nv.Tuoi,
                    Email = nv.Email,
                    Luong = nv.Luong,
                    TrangThai = nv.TrangThai,
                    Role = nv.Role,
                };
                await _context.nhanViens.AddAsync(nvien);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var c = await _context.nhanViens.FindAsync(id);
                if (c == null)
                {
                    throw new Exception("Ko tim thay");
                }
                _context.nhanViens.Remove(c);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public async Task<List<NhanVienVM>> GetAll()
        {
            return await _context.nhanViens
               .Select(i => new NhanVienVM()
               {
                   Id = i.Id,
                   Ten = i.Ten,
                   Tuoi = i.Tuoi,
                   Email = i.Email,
                   Luong = i.Luong,
                   Role = i.Role,
                   TrangThai = i.TrangThai,
               }).ToListAsync();
        }

        public async Task<bool> Update(NhanVienVM nv)
        {
            var x = await _context.nhanViens.FindAsync(nv.Id);
            if (x == null) throw new Exception($"Không thể tim thấy Id:  {nv.Id}");
            x.Ten = nv.Ten;
            x.Tuoi = nv.Tuoi;
            x.Email = nv.Email;
            x.Luong = nv.Luong;
            x.Role = nv.Role;
            x.TrangThai = nv.TrangThai;
            _context.nhanViens.Update(x);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
