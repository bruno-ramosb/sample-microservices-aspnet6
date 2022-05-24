using AutoMapper;
using GeekShopping.ProductApi.Data.DTOs;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PgsqlContext _context;
        private IMapper _mapper;
        public ProductRepository(PgsqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(long id)
        {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Create(ProductDTO dto)
        {
            Product product = _mapper.Map<Product>(dto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<ProductDTO> Update(ProductDTO dto)
        {
            Product product = _mapper.Map<Product>(dto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
