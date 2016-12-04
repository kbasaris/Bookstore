using AutoMapper;
using BookStore.Utilities.Models;
using BookStore.Data.Entities;

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
                  .ForMember(vm => vm.ImageUrl, dm => dm.Ignore())
                  .ForMember(vm => vm.Image, dm => dm.Ignore())
                  .ForMember(vm => vm.ImageName, dm => dm.Ignore());
                 


        }
    }
}