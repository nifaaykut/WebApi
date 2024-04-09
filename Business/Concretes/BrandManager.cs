using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public CreatedBrandResponse Add(CreateBrandRequest createBrandResquest)
        {
            Brand brand = new();
            brand.Name = createBrandResquest.Name;
            brand.CreatedDate=DateTime.Now;
            _brandDal.Add(brand);

            //mapping -- automapper
            CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
            createdBrandResponse.Name = createBrandResquest.Name;
            createdBrandResponse.Id = 4;
            createdBrandResponse.CreatedDate=brand.CreatedDate;

            return createdBrandResponse;
        }

        public List<GetAllBrandResponse> GetAll()
        {
            List<Brand> brands = _brandDal.GetAll();
            List<GetAllBrandResponse>getAllBrandsResponses = new List<GetAllBrandResponse>();

            foreach (var brand in brands) 
            {
                GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
                getAllBrandResponse.Name = brand.Name;
                getAllBrandResponse.Id=brand.Id;
                getAllBrandResponse.CreatedDate=brand.CreatedDate;

                getAllBrandsResponses.Add(getAllBrandResponse);
            }
            return getAllBrandsResponses;
        }
    }
}
