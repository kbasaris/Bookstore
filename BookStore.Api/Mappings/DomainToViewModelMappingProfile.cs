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
            CreateMap<Item, BookViewModel>()
                  .ForMember(vm => vm.Author, dm => dm.MapFrom(x => x.Book.Author))
                  .ForMember(vm => vm.Title, dm => dm.MapFrom(x => x.Book.Title))
                  .ForMember(vm => vm.Image, dm => dm.MapFrom(x => x.Book.Image));
        }
    }
}