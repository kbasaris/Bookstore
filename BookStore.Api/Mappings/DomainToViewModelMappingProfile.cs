using AutoMapper;
using BookStore.Api.Models;
using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Api.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Book, BookViewModel>()
                 .ForMember(vm => vm.Barcode, dm => dm.MapFrom(x => x.Stocks.Select(s => s.Barcode)))
                 .ForMember(vm => vm.Reorder, dm => dm.MapFrom(x => x.Stocks.Any(s => s.Reorder)))
                 .ForMember(vm => vm.ReorderAmount, dm => dm.MapFrom(x => x.Stocks.Select(s => s.ReorderAmount)));
        }
    }
}