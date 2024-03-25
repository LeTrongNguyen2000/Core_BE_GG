using AutoMapper;
using UserCore.Entities;
using UserCore.Models;

namespace UserCore.Mappings
{
    /// <summary>
    /// MappingProfile
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// MappingProfile
        /// </summary>
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<DonViRequest, DonVi>(MemberList.Source);
            CreateMap<DonVi, DonViResponse>().IgnoreAllNonExisting();

            CreateMap<PhongBanRequest, PhongBan>(MemberList.Source);
            CreateMap<PhongBan, PhongBanResponse>().IgnoreAllNonExisting();

            CreateMap<VaiTroRequest, VaiTro>(MemberList.Source);
            CreateMap<VaiTro, VaiTroResponse>().IgnoreAllNonExisting();

            CreateMap<Quyen, QuyenResponse>().IgnoreAllNonExisting();

            CreateMap<NguoiDungRequest, NguoiDung>(MemberList.Source);
            CreateMap<NguoiDung, NguoiDungFullResponse>().IgnoreAllNonExisting();

            CreateMap<NguoiDungPhongBanRequest, NguoiDungPhongBan>(MemberList.Source);

            CreateMap<NguoiDungVaiTroRequest, NguoiDungVaiTro>(MemberList.Source);

            CreateMap<NguoiDung, NguoiDungFullResponse>().IgnoreAllNonExisting()
                .ForMember(dest => dest.DsNguoiDungPhongBan, opt => opt.MapFrom(src => src.DsNguoiDungPhongBan != null ? src.DsNguoiDungPhongBan : null));
            CreateMap<NguoiDungPhongBan, NguoiDungPhongBanFullResponse>()
                 .IgnoreAllNonExisting()
                 .ForMember(dest => dest.DonVi, opt => opt.MapFrom(src => src.PhongBan != null ? src.PhongBan.DonVi : null))
                 .ForMember(dest => dest.PhongBan, opt => opt.MapFrom(src => src.PhongBan))
                 .ForMember(dest => dest.VaiTro, opt => opt.MapFrom(src => src.NguoiDungVaiTro != null ? src.NguoiDungVaiTro.VaiTro : null));

            CreateMap<VaiTro, VaiTroViewModel>().IgnoreAllNonExisting();
            CreateMap<DonVi, DonViViewModel>().IgnoreAllNonExisting();
            CreateMap<PhongBan, PhongBanViewModel>().IgnoreAllNonExisting();

            CreateMap<NguoiDung, NguoiDungPhongBanResponse>()
                .IgnoreAllNonExisting()
                .ForMember(dest => dest.NguoiDungPhongBan, opt => opt.MapFrom(src => src.DsNguoiDungPhongBan != null ? src.DsNguoiDungPhongBan.FirstOrDefault() : null));


            CreateMap<VaiTro, VaiTroQuyenResponse>().IgnoreAllNonExisting()
                .ForMember(dest => dest.DsQuyen, opt => opt.MapFrom(src => src.DsNguoiDungVaiTro)); ;

            CreateMap<VaiTroQuyen, QuyenViewModel>()
              .IgnoreAllNonExisting()
                .ForMember(dest => dest.MaQuyen, opt => opt.MapFrom(src => src.Quyen.MaQuyen != null ? src.Quyen.MaQuyen : null))
                .ForMember(dest => dest.MoTa, opt => opt.MapFrom(src => src.Quyen.MoTa != null ? src.Quyen.MoTa : null))
                .ForMember(dest => dest.TrangThai, opt => opt.MapFrom(src => src.Quyen.TrangThai));
        }
    }
}
