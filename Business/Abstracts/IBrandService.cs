using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBrandService
    {
       CreateBrandResponse Add(CreateBrandResquest brand);
        List<Brand> GetAll();
    }
}

//responses and requests