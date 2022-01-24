using NLayer.Core.Dtos;

namespace NLayer.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("products/GetProductWithcCategory");
            return response.Data;
        }
        public async Task<ProductDto> SaveAsync(ProductDto productDto)
        {
            var response = await _httpClient.PostAsJsonAsync("products",productDto);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responseBody.Data;

        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");
            //if (response.Errors.Any())
            //    return CustomResponseDto<ProductDto>.Fail(500, "error");
            return response.Data;
        }

        public  async Task<bool> UpdateAsync(ProductDto update)
        {
           var response=   await _httpClient.PutAsJsonAsync("products", update);
           
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");

            return response.IsSuccessStatusCode;

        }
    }
}
