using AutoMapper;
using EMail.Application.Models;
using EMail.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMail.Application
{
    public class EMailAppMapProfile : Profile
    {
        public EMailAppMapProfile()
        {
            CreateMap<EMailAccountModel, EMailAccountAppModel>()
                .ForMember(a => a.CreatedBy,
                            m => m.MapFrom((src, map) =>
                            {
                                return src.CreatedBy.ToString();
                            }))
                .ForMember(a => a.ModifiedBy,
                            m => m.MapFrom((src, map) =>
                            {
                                return src.ModifiedBy?.ToString();
                            }));
        }
    }
}
