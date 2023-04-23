using AutoMapper;
using ServiceLayer.MapProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapper
{
    public class ObjectMapper
    {
        public static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config=new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();
        });
        public static  IMapper mapper=>lazy.Value;
    }
}
